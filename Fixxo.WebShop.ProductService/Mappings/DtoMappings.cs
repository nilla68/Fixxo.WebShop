using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.Dtos;

namespace Fixxo.WebShop.ProductService.Mappings
{
    /// <summary>
    /// Single Resposiblity Principle: Collect all mapping methods to convert to DTO classes in one class.
    /// Open/Closed Principle: Adds methods to the domain model objects to convert them to DTO objects.
    /// Design Decision: All methods to convert between the different models (DTO, DomainModel and Entity) are collected in one place.
    /// The different model classes are kept clean from converting logic.
    /// </summary>
    public static class DtoMappings
    {
        public static ProductDto MapToDto(this ProductModel productModel)
        {
            var productDto = new ProductDto()
            {
                Id = productModel.Id,
                Brand = productModel.Brand,
                Color = productModel.Color,
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                Size = productModel.Size,
                Sku = productModel.Sku,
                Rating = productModel.Rating,
                Image = productModel.Image,
                Category = productModel.Category.MapToDto()
            };

            return productDto;
        }

        public static ICollection<ProductDto> MapToDtos(this ICollection<ProductModel> productModels)
        {
            return productModels.Select(p => p.MapToDto()).ToList();
        }

        public static CategoryDto MapToDto(this CategoryModel categoryModel)
        {
            var categoryDto = new CategoryDto()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name
            };

            return categoryDto;
        }

        public static ICollection<CategoryDto> MapToDtos(this ICollection<CategoryModel> categoryModels)
        {
            return categoryModels.Select(c => c.MapToDto()).ToList();
        }
    }
}
