

namespace playwrightFinalPractice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ProductType productType { get; set; }

        public enum ProductType 
        {
                   CPU,
                   MONITOR,
                   PERIPHARALS,
                   EXTERNAL
        }

    }
}
