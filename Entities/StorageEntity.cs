using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string StorageId { get; set; }

        [StringLength(10)]
        [Required]
        public string ProductId { get; set; }

        [StringLength(50)]
        [Required]
        public string WareHouseId { get; set; }

        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual WarehouseEntity Warehouse { get; set; }
    }
}
