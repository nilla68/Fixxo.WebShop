using Fixxo.WebShop.DomainModel.Abstractions;
using Fixxo.WebShop.Dtos;
using Fixxo.WebShop.ProductService.DataAccess;
using Fixxo.WebShop.ProductService.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo.WebShop.ProductService.Controllers
{
    /// <summary>
    /// Single Responsibility Principle: This controller handles the CRUD operations for categories only. 
    /// Dependency Inversion Principle: High-level modules should not depend on low-level modules. Both should depend on abstractions.
    /// Design Decision: Separate controller for each DomainModel object.
    /// The implementation of the ILogger and ICategoryRepository can be changed without changing the controller.
    /// If we want to use another database the controller does not need to change, the only thing that needs to be added to the code base is another implementation of the ICategoryRepository interface.  
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var categoryModel = createCategoryDto.MapToModel();
            var createdCategoryModel = await _categoryRepository.CreateCategory(categoryModel);

            var createdCategoryDto = createdCategoryModel.MapToDto();

            return CreatedAtAction("GetCategoryById", new { id = createdCategoryDto.Id }, createdCategoryDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            try
            {
                var model = await _categoryRepository.GetCategoryById(id);
                return Ok(model.MapToDto());
            }
            catch (CategoryNotFoundException)                              
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetAllCategories()
        {
            try
            {
                var models = await _categoryRepository.GetAllCategories();
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