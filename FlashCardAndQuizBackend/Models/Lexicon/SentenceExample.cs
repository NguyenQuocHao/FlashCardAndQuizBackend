using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class SentenceExample
    {
        private List<Meaning> _meanings = new();

        public int Id { get; set; }

        public IReadOnlyCollection<Meaning> Meanings => _meanings.AsReadOnly();
        //public int MeaningId { get; set; }
        public string Sentence { get; set; }

        public void AddMeanings(Meaning meaning) {
            _meanings.Add(meaning);
        }
    }
}
