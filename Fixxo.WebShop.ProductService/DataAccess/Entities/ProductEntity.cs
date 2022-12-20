using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fixxo.WebShop.ProductService.DataAccess.Entities
{
    /// <summary>
    /// Single Resposiblity Principle: Describes a Product in the database model.
    /// Design Decision: An entity class is used only for persisting or retriveing data from the data base.
    /// </summary>
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        public int Rating { get; set; }        
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }                
        public CategoryEntity Category { get; set; }        
    }
}