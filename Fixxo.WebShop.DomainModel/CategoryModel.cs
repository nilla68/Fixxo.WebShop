namespace Fixxo.WebShop.DomainModel
{
    /// <summary>
    /// Single Resposiblity Principle: Describes a Category in the domain model.
    /// Design Decision: This is the domain model class for Category.
    /// I choose to create a DomainModel project to follow the DRY rule. 
    /// The DomainModel project is used by both, the Service and the Blazor projects.
    /// </summary>
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}