namespace Catalog.Api.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public DateTime Created { get; set; }
        public CategoryDto Category { get; set; }
    }
}