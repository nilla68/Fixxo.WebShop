using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.DomainModel.Abstractions;
using Fixxo.WebShop.ProductService.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fixxo.WebShop.ProductService.DataAccess
{
    /// <summary>
    /// Single Responsibility Principle: This repository handles the CRUD operations for Products only. 
    /// Dependency Inversion Principle: The ProductDbContext is injected.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: Separate repository for each domain model object.
    /// The DbContext object is configured in Program.cs to use SQL Server. 
    /// The database can easily be replaced with another database supported by Entity Framework Core.
    /// If a data store not supported by Entity Framework Core will be used, a new repository implementation is required.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly FixxoDbContext _dbContext;

        public ProductRepository(FixxoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            var entity = productModel.MapToEntity();
            _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync();

            var createdEntity = await _dbContext.Products.Include(p => p.Category).FirstAsync(p => p.Id == entity.Id);

            return createdEntity.MapToModel();
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var entity = await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null)
            {
                throw new ProductNotFoundException();
            }

            return entity.MapToModel();
        }

        public async Task<ICollection<ProductModel>> GetAllProducts()
        {
            var productEntities = await _dbContext.Products.Include(p => p.Category).ToListAsync();

            return productEntities.MapToModels();
        }
    }
}