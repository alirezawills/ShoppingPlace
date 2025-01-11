using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.BaseClass
{
    public abstract class BaseClaseGeneral<TKey> : BaseEntity<TKey>
    {
        [Required]
        [MaxLength(500)]
        public required string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Code { get; set; }

        [MaxLength(int.MaxValue)]
        public required string Description { get; set; }
    }
}
