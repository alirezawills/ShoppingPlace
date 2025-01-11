using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.General
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key);
    }
}
