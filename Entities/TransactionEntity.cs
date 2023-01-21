using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class TransactionEntity
    {
        [Key]
        [StringLength(50)]
        public string TransactionId { get; set; }

        [StringLength(50)]
        [Required]
        public string StorageId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateTransaction { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool isInput { get; set; }
        public virtual StorageEntity Storage { get; set; }

    }
}
