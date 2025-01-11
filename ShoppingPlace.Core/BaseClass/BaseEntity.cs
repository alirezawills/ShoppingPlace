using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.BaseClass
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public required TKey Id { get; set; }
        public long TenantId { get; set; }
        public long? InsertBy { get; set; }
        public long? UpdateBy { get; set; }
        public long? DeleteBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        protected BaseEntity()
        {
            InsertDate = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
        }
    }
}
