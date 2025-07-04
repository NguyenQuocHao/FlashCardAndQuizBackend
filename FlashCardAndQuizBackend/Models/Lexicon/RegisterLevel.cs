using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class RegisterLevel
    {
        //public int Id { get; set; }
        public required Register FormalityLevel { get; set; }
        public string Label { get; set; }
    }
}
