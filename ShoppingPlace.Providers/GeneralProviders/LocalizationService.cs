using Microsoft.Extensions.Localization;
using ShoppingPlace.Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Providers.GeneralProviders
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(LocalizationService); // یا هر نوع دلخواهی
            _stringLocalizer = factory.Create(type);
        }

        public string GetLocalizedString(string key)
        {
           return _stringLocalizer[key];
        }
    }
}
