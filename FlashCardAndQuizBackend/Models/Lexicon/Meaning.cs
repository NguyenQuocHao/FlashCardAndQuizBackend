using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class Meaning
    {
        private List<Tag> _tags = new();
        private List<SentenceExample> _sentenceExample = new();

        public int Id { get; set; }
        public LexicalUnit Word { get; set; }
        public int LexicalUnitId { get; set; }
        public WordType Type { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public Difficulty DifficultyLevel { get; set; }
        public Frequency FrequencyLevel { get; set; }
        public Importance ImportanceLevel { get; set; }
        public Register RegisterLevel { get; set; }

        //public RegisterLevel Register { get; set; }
        //public int RegisterLevelId { get; set; }
        //public FrequencyLevel Frequency { get; set; }
        //public int FrequencyLevelId { get; set; }
        //public ImportanceLevel Importance { get; set; }
        //public int ImportanceLevelId { get; set; }
        //public DifficultyLevel Difficulty { get; set; }
        //public int DifficultyLevelId { get; set; }
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
        public IReadOnlyCollection<SentenceExample> SentenceExamples => _sentenceExample.AsReadOnly();
    }
}
