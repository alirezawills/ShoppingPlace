using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.BaseClass.BaseDtoes
{
    public class BaseClaseGeneralDto<TKey> : BaseEntityDto<TKey>
    {

        //[Required(ErrorMessage = ErrorMessage.DataIsRequired)]
        //[MaxLength(500)]
        //[Display(Name = LabelName.Title)]
        //public string Title { get; set; }
        //[Required(ErrorMessage = ErrorMessage.DataIsRequired)]
        //[MaxLength(50)]
        //[Display(Name = LabelName.Code)]

        //public string Code { get; set; }

        //[MaxLength(int.MaxValue)]
        //[Display(Name = LabelName.Description)]

        //public string Description { get; set; }
    }
}
