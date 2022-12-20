using Fixxo.WebShop.DomainModel;
using Fixxo.WebShop.Dtos;
using System.Net.Http.Json;
using Fixxo.WebShop.WebClient.Mappings;
using System.Linq;

namespace Fixxo.WebShop.WebClient.ViewModels
{
    /// <summary>
    /// Dependency Inversion Principle: The configured HttpClient is injected. The base url for the HttpClient is set in Program.cs.
    /// Design Decision: This class is the ViewModel for the Index page according to the MVVM pattern.
    /// </summary>
    public class ProductDetailsViewModel
    {
        private readonly HttpClient _httpClient;

        public ProductDetailsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ProductCardViewModel Product { get; set; } 
        public ICollection<ProductCardViewModel> RelatedProducts { get; set; }

        public async Task LoadProductAsync(Guid id)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");
            Product = product.MapToViewModel();

            var rnd = new Random();
            var allProducts = await _httpClient.GetFromJsonAsync<List<ProductDto>>($"api/products");

            var relatedProducts = allProducts.OrderBy(x => rnd.Next()).Take(4).ToList();

            RelatedProducts = new List<ProductCardViewModel>();
            foreach (var prod in relatedProducts)
            {
                RelatedProducts.Add(prod.MapToViewModel());
            }
        }
    }
}
