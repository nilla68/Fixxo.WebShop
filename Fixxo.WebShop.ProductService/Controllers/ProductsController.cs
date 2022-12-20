using Fixxo.WebShop.DomainModel.Abstractions;
using Fixxo.WebShop.Dtos;
using Fixxo.WebShop.ProductService.DataAccess;
using Fixxo.WebShop.ProductService.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo.WebShop.ProductService.Controllers
{
    /// <summary>
    /// Single Responsibility Principle: This controller handles the CRUD operations for products only. 
    /// Dependency Inversion Principle: High-level modules should not depend on low-level modules. Both should depend on abstractions.
    /// Design Decision: Separate controller for each DomainModel object.
    /// The implementation of the ILogger and IProductRepository can be changed without changing the controller.
    /// If we want to use another database the controller does not need to change, the only thing that needs to be added to the code base is another implementation of the IProductRepository interface.  
    /// </summary>
    [Route("api/products")]
    [ApiController]             
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                var createProductModel = createProductDto.MapToModel();
                var createdProductModel = await _productRepository.CreateProduct(createProductModel);
                var productDto = createdProductModel.MapToDto();

                _logger.LogInformation($"Product: {productDto.Name} created.");

                return CreatedAtAction("GetProductById", new { id = productDto.Id }, productDto);
            }
            catch (Exception)
            {
                _logger.LogError("Could not create product");

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            try
            {
                var productModel = await _productRepository.GetProductById(id);

                return Ok(productModel.MapToDto());
            }
            catch (ProductNotFoundException)                                  
            {
                _logger.LogInformation($"Product was not found.");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDto>>> GetAllProducts()
        {
            try
            {
                var models = await _productRepository.GetAllProducts();
                var dtos = models.MapToDtos();

                return Ok(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}