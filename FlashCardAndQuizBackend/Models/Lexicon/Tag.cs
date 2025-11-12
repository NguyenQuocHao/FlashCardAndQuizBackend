namespace FlashCardAndQuizBackend.Models
{
    public class Tag
    {
        private readonly List<Meaning> _meanings;
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<Meaning> Meanings => _meanings.AsReadOnly();
    }
}
