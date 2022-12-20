namespace Fixxo.WebShop.Dtos
{
    /// <summary>
    /// Single Resposiblity Principle: This class is only used to transfer data over the wire when retrieving a category.
    /// Open/Closed Principle: This class extends the CreateCategoryDto class.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: This class adds the Id property when getting data, the Id property is not needed when creating a new Category.
    /// An inheritance is choosen to minimize code repetition (DRY).
    /// The DTOs project is used by both, the Service and Blazor projects.
    /// </summary>
    public class CategoryDto : CreateCategoryDto
    {
        public required Guid Id { get; set; }
    }

    /// <summary>
    /// Single Resposiblity Principle: This class is only used to transfer data over the wire when creating a new category.
    /// Liskov Substitution Priciple: CreateCategoryDto is substitutable with CategoryDto.
    /// Interface Segregation Principle: Clients should not be forced to depend on methods they do not use.
    /// Design Decision: This class only contains the information needed to create a Category.
    /// The CategoryDto class is used for retriving data.
    /// The DTOs project is used by both, the Service and Blazor projects.
    /// </summary>
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
    }
}