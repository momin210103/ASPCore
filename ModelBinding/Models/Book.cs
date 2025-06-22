namespace ModelBinding.Models
{
    public class Book
    {
        public int? BookId { get; set; }
        public string Character { get; set; }
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"Character: {Character},Book ID: {BookId}, Author: {Author}";
        }
    }
}
