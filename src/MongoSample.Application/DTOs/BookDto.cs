namespace MongoSample.Application.DTOs
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public List<string> Categories { get; set; }
    }
}
