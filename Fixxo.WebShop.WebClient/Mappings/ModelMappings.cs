using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.Dtos;

namespace Fixxo.WebShop.WebClient.Mappings
{
    /// <summary>
    /// Single Resposiblity Principle: Collect all mapping methods to convert to domain model classes in one class.
    /// Open/Closed Principle: Adds methods to the DTO and Entity classes to convert them to domain model objects.
    /// Design Decision: All methods to convert between the different models (DTO, DomainModel) are collected in one place.
    /// The different model classes are kept clean from converting logic.
    /// </summary>
    public static class ModelMappings
    {
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

        public static CategoryModel MapToModel(this CategoryDto categoryDto)
        {
            var categoryModel = new CategoryModel
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };

            return categoryModel;
        }
    }
}
