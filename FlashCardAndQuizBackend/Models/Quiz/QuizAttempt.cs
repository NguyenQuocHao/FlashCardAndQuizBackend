namespace FlashCardAndQuizBackend.Models
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int WordId { get; set; }
        public bool Correct { get; set; }
        public string UserAnswer { get; set; }
        public int QuizType { get; set; }
    }
}
