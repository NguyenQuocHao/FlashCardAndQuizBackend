using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class Meaning
    {
        private List<Tag> _tags = new();
        private List<SentenceExample> _sentenceExamples = new();

        public int Id { get; set; }
        public LexicalUnit LexicalUnit { get; set; }
        public int LexicalUnitId { get; set; }
        public WordType Type { get; set; }

        public string Description { get; set; }
        public string Note { get; set; }

        public Difficulty DifficultyLevel { get; set; }
        public Frequency FrequencyLevel { get; set; }
        public Importance ImportanceLevel { get; set; }
        public Register RegisterLevel { get; set; }

        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
        public IReadOnlyCollection<SentenceExample> SentenceExamples => _sentenceExamples.AsReadOnly();
        public void AddTag(Tag tag)
        {
            if (_tags.Contains(tag))
            {
                return;
            }

            _tags.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            if (!_tags.Contains(tag))
            {
                return;
            }

            _tags.Remove(tag);
        }

        public void AddExample(SentenceExample example)
        {
            if (_sentenceExamples.Contains(example))
            {
                return;
            }

            _sentenceExamples.Add(example);
        }

        public void DeleteExample(SentenceExample example)
        {
            if (!_sentenceExamples.Contains(example))
            {
                return;
            }

            _sentenceExamples.Remove(example);
        }
    }
}
