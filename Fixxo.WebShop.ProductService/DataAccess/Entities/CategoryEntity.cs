using System.ComponentModel.DataAnnotations;

namespace Fixxo.WebShop.ProductService.DataAccess.Entities
{
    /// <summary>
    /// Single Resposiblity Principle: Describes a Category in the database model.
    /// Design Decision: An entity class is used only for persisting or retriveing data from the data base.
    /// </summary>
    public class CategoryEntity                 
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
