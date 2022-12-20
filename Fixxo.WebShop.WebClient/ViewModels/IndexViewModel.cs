using Fixxo.WebShop.Dtos;
using Fixxo.WebShop.WebClient.Mappings;
using System.Net.Http.Json;

namespace Fixxo.WebShop.WebClient.ViewModels
{
    /// <summary>
    /// Dependency Inversion Principle: The configured HttpClient is injected. The base url for the HttpClient is set in Program.cs.
    /// Design Decision: This class is the ViewModel for the Index page according to the MVVM pattern.
    /// </summary>
    public class IndexViewModel
    {
        private readonly HttpClient _httpClient;

        public IndexViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ICollection<ProductCardViewModel> Products { get; set; } = new List<ProductCardViewModel>();

        public async Task LoadProductsAsync()
        {
            var products = await _httpClient.GetFromJsonAsync<ICollection<ProductDto>>("api/products");
            Products = products.MapToViewModels().Take(8).ToList();
        }
    }
}


