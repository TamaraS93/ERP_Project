namespace ERP.Models
{
    public class ProductSearchViewModel
    {
        public string SearchTerm { get; set; }
        public string Category { get; set; }
        public List<Product> Products { get; set; }
        public List<string> Categories { get; set; }
    }
}
