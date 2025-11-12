using Microsoft.AspNetCore.Mvc;

namespace FlashCardAndQuizBackend.Models
{
    public class FlashCard
    {
        public int Id { get; set; }
        public LexicalUnit LexicalUnit { get; set; }
        public int LexicalUnitId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
