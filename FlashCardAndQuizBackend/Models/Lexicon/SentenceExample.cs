using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class SentenceExample
    {
        public int Id { get; set; }
        public Meaning Meaning { get; set; }
        public int MeaningId { get; set; }
        public string Sentence { get; set; }
    }
}
