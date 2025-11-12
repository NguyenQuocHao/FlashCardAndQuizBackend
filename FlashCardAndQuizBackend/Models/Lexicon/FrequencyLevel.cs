using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Models
{
    public class FrequencyLevel
    {
        //public int Id { get; set; }

        public required Frequency Level { get; set; }
        public string Label { get; set; }
    }
}
