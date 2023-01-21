using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductEntity
    {
        [Key]
        [StringLength(10)]
        public string ProductId { get; set; }
        [StringLength(50)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(600)]
        public string Description { get; set; }
        
        public int TotalQuantity { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual ICollection<StorageEntity> Storage { get; set; }
    }
}
