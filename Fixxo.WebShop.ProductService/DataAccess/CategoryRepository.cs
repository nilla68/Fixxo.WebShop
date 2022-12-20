using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.DomainModel.Abstractions;
using Fixxo.WebShop.ProductService.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Fixxo.WebShop.ProductService.DataAccess
{
    /// <summary>
    /// Single Responsibility Principle: This repository handles the CRUD operations for Categories only. 
    /// Dependency Inversion Principle: The ProductDbContext is injected.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: Separate repository for each domain model object.
    /// The DbContext object is configured in Program.cs to use SQL Server. 
    /// The database can easily be replaced with another database supported by Entity Framework Core.
    /// If a data store not supported by Entity Framework Core will be used, a new repository implementation is required.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FixxoDbContext _dbContext;

        public CategoryRepository(FixxoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel categoryModel)
        {
            var categoryEntity = categoryModel.MapToEntity();

            _dbContext.Categories.Add(categoryEntity);
            await _dbContext.SaveChangesAsync();

            return categoryEntity.MapToModel();
        }

        public async Task<ICollection<CategoryModel>> GetAllCategories()
        {
            var categoryEntities = await _dbContext.Categories.ToListAsync();

            return categoryEntities.MapToModels();
        }

        public async Task<CategoryModel> GetCategoryById(Guid id)
        {
            var categoryEntity = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryEntity is null)
            {
                throw new CategoryNotFoundException();
            }

            return categoryEntity.MapToModel();
        }
    }
}