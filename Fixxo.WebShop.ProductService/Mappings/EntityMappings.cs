using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.ProductService.DataAccess.Entities;

namespace Fixxo.WebShop.ProductService.Mappings
{
    /// <summary>
    /// Single Resposiblity Principle: Collect all mapping methods to convert to Entity classes in one class.
    /// Open/Closed Principle: Adds methods to the domain model objects to convert them to Entity objects.
    /// Design Decision: All methods to convert between the different models (DTO, DomainModel and Entity) are collected in one place.
    /// The different model classes are kept clean from converting logic.
    /// </summary>
    public static class EntityMappings
    {
        public static ProductEntity MapToEntity(this ProductModel productModel)
        {
            var productEntity = new ProductEntity
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Sku = productModel.Sku,
                Brand = productModel.Brand,
                Color = productModel.Color,
                Size = productModel.Size,
                Rating = productModel.Rating,
                Image = productModel.Image,
                CategoryId = productModel.Category.Id 
            };

            return productEntity;
        }

        public static CategoryEntity MapToEntity(this CategoryModel categoryModel)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
            };

            return categoryEntity;
        }

        public static ICollection<ProductEntity> MapToModels(this ICollection<ProductModel> products)
        {
            return products.Select(p => p.MapToEntity()).ToList();
        }
    }
}
