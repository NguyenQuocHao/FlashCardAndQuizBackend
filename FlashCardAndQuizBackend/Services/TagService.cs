using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlashCardAndQuizBackend.Services
{
    public class TagService
    {
        private readonly TagRepository _tagRepo;
        public TagService(TagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        public async Task CreateTag(CreateTagRequest request)
        {
            Tag tag = new Tag()
            {
                Name = request.TagName,
            };

            await _tagRepo.AddTag(tag);
        }

        public async Task<List<GetTagResponse>> GetAllTags()
        {
            var tags = await _tagRepo.GetAllTags();

            return tags
                .Select(tag => new GetTagResponse(tag.Id,
                    tag.Name))
                .ToList();
        }

        public async Task<GetTagResponse?> GetTagById(int id)
        {
            var tag = await _tagRepo.GetTagById(id);

            if (tag != null)
                return new GetTagResponse(tag.Id,
                    tag.Name);

            return null;
        }

        public async Task UpdateTag(int tagId, UpdateTagRequest request)
        {
            var tag = await _tagRepo.GetTagById(tagId);

            if (tag != null)
            {
                tag.Name = request.TagName;
                await _tagRepo.UpdateTag(tag);
            }
        }

        public async Task UpdateTagsOfMeaning(Meaning meaning, IEnumerable<string> tags)
        {
            // Delete tags
            List<Tag> obsoleteTags = meaning.Tags
                .Where(t => !tags.Contains(t.Name))
                .ToList();
            foreach (Tag obsoleteTag in obsoleteTags)
            {
                meaning.DeleteTag(obsoleteTag);
            }

            // Add tags that already exist
            List<Tag> existingTags = await _tagRepo.GetAllTags();
            List<Tag> overlappingTags = existingTags
                .Where(t => tags.Contains(t.Name))
                .ToList();
            foreach (Tag tag in overlappingTags)
            {
                meaning.AddTag(tag);
            }

            // Add completely new tags
            List<string> newTagNames = tags
                .Except(overlappingTags.Select(t => t.Name))
                .ToList();
            foreach (string newTag in newTagNames)
            {
                Tag newTagObj = new()
                {
                    Name = newTag,
                };

                await _tagRepo.AddTag(newTagObj);
                meaning.AddTag(newTagObj);
            }
        }

        public async Task DeleteTag(int id)
        {
            var tag = await _tagRepo.GetTagById(id);
            if (tag == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            await _tagRepo.DeleteTag(tag);
        }
    }
}