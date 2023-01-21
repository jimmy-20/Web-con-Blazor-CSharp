using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CategoryEntity
    {
        [Key]
        [StringLength(50)]
        public string CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
