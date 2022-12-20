using Fixxo.WebShop.Dtos;
using Fixxo.WebShop.WebClient.ViewModels;

namespace Fixxo.WebShop.WebClient.Mappings
{
    /// <summary>
    /// Single Resposiblity Principle: Collect all mapping methods to convert to ViewModel classes in one class.
    /// Open/Closed Principle: Adds methods to the DTO classes to convert them to ViewModel objects.
    /// Design Decision: All methods to convert between the different models (DTO, DomainModel and ViewModel) are collected in one place.
    /// The different model classes are kept clean from converting logic.
    /// </summary>
    public static class ViewModelMappings
    {
        public static ICollection<ProductCardViewModel> MapToViewModels(this ICollection<ProductDto> productDtos)
        {
            var productModels = productDtos.MapToModels();
            var productViewModels = productModels.Select(productModel => new ProductCardViewModel(productModel)).ToList();
            
            return productViewModels;
        }

        public static ProductCardViewModel MapToViewModel(this ProductDto productDto)
        {
            var productModel = productDto.MapToModel();
            var productViewModel = new ProductCardViewModel(productModel);

            return productViewModel;
        }
    }
}
