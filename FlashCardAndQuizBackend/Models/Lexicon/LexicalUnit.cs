using System.ComponentModel.DataAnnotations;

namespace FlashCardAndQuizBackend.Models
{
    public class LexicalUnit
    {
        private List<Meaning> _meanings = new();

        public int Id { get; set; }
        public required string Text { get; set; }
        public FlashCard? FlashCard { get; set; }
        public int? FlashCardId { get; set; }

        public IReadOnlyCollection<Meaning> Meanings => _meanings.AsReadOnly();
    }
}
