namespace Fixxo.WebShop.DomainModel.Abstractions
{
    /// <summary>
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: Because there are two different controllers, ProductsController and CategoriesController there are two different Repository interfaces.
    /// That means each controller is only depending on the methods provided by the separate Repository interfaces.
    /// </summary>
    public interface IProductRepository
    {
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ICollection<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(Guid id);
    }
}
