namespace Fixxo.WebShop.Dtos
{
    /// <summary>
    /// Design Decision: DRY rule
    /// </summary>
    public class ProductDtoBase
    {
        public required string Name { get; set; }
        public required string Sku { get; set; }
        public required string Brand { get; set; }
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public required string Size { get; set; }
        public required string Color { get; set; }
        public required string Image { get; set; }
    }

    /// <summary>
    /// Single Resposiblity Principle: This class is only used to transfer data over the wire when retireveing a product.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: This class adds the Id, Rating and Category property when getting data, neither of these properties are needed when creating a new Product.
    /// An inheritance is choosen to minimize code repetition (DRY).
    /// The DTOs project is used by both, the Service and Blazor projects.
    /// </summary>
    public class ProductDto : ProductDtoBase  
    {
        public Guid Id { get; set; }  
        public int Rating { get; set; }
        public required CategoryDto Category { get; set; } 
    }

    /// <summary>
    /// Single Resposiblity Principle: This class is only used to transfer data over the wire when creating a new product.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: This class only contains the information needed to create a Product.
    /// The ProductDto class is used for retriving data.
    /// The DTOs project is used by both, the Service and Blazor projects.
    /// </summary>
    public class CreateProductDto : ProductDtoBase
    {
        public required Guid CategoryId { get; set; } 
    }
}