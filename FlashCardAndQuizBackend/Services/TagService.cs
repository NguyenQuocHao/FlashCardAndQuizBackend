using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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