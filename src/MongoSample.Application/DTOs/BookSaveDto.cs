namespace MongoSample.Application.DTOs
{
    public class BookSaveDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
