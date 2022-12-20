using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.Dtos;
using Fixxo.WebShop.ProductService.DataAccess.Entities;

namespace Fixxo.WebShop.ProductService.Mappings
{
    /// <summary>
    /// Single Resposiblity Principle: Collect all mapping methods to convert to domain model classes in one class.
    /// Open/Closed Principle: Adds methods to the DTO and Entity classes to convert them to domain model objects.
    /// Design Decision: All methods to convert between the different models (DTO, DomainModel and Entity) are collected in one place.
    /// The different model classes are kept clean from converting logic.
    /// </summary>
    public static class ModelMappings
    {
        public static ProductModel MapToModel(this CreateProductDto productDto)
        {
            var productModel = new ProductModel
            {
                Brand = productDto.Brand,
                Category = new CategoryModel { Id = productDto.CategoryId },
                Color = productDto.Color,
                Description = productDto.Description,
                Name = productDto.Name,
                Price = productDto.Price,
                Rating = 0,
                Size = productDto.Size,
                Sku = productDto.Sku,
                Image = productDto.Image
            };

            return productModel;
        }

        public static ProductModel MapToModel(this ProductDto productDto)
        {
            var productModel = new ProductModel
            {
                Id = productDto.Id,
                Brand = productDto.Brand,
                Category = productDto.Category.MapToModel(),
                Color = productDto.Color,
                Description = productDto.Description,
                Name = productDto.Name,
                Price = productDto.Price,
                Rating = productDto.Rating,
                Size = productDto.Size,
                Sku = productDto.Sku,
                Image = productDto.Image
            };

            return productModel;
        }

        public static ICollection<ProductModel> MapToModels(this ICollection<ProductDto> productDtos)
        {
            return productDtos.Select(p => p.MapToModel()).ToList();
        }

        public static ProductModel MapToModel(this ProductEntity productEntity)
        {
            var productModel = new ProductModel
            {
                Id = productEntity.Id,
                Brand = productEntity.Brand,
                Color = productEntity.Color,
                Description = productEntity.Description,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Rating = productEntity.Rating,
                Size = productEntity.Size,
                Sku = productEntity.Sku,
                Image = productEntity.Image,
                Category = productEntity.Category.MapToModel(),
            };

            return productModel;
        }

        public static CategoryModel MapToModel(this CategoryEntity categoryEntity)
        {
            var categoryModel = new CategoryModel
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name
            };

            return categoryModel;
        }

        public static ICollection<CategoryModel> MapToModels(this ICollection<CategoryEntity> categoryEntities)
        {
            return categoryEntities.Select(c => c.MapToModel()).ToList();
        }

        public static ICollection<ProductModel> MapToModels(this ICollection<ProductEntity> productEntities)
        {
            return productEntities.Select(p => p.MapToModel()).ToList();
        }

        public static CategoryModel MapToModel(this CategoryDto categoryDto)
        {
            var categoryModel = new CategoryModel
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };

            return categoryModel;
        }

        public static CategoryModel MapToModel(this CreateCategoryDto categoryDto)
        {
            var categoryModel = new CategoryModel
            {
                Name = categoryDto.Name
            };

            return categoryModel;
        }
    }
}
