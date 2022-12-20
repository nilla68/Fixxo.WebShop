namespace Fixxo.WebShop.DomainModel
{
    /// <summary>
    /// Single Resposiblity Principle: Describes a Product in the domain model.
    /// Design Decision: This is the domain model class for Product.
    /// I choose to create a DomainModel project to follow the DRY rule. 
    /// The DomainModel project is used by both, the Service and the Blazor projects.
    /// </summary>
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public CategoryModel Category { get; set; }
    }
}
