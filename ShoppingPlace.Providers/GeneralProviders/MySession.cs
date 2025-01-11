using Microsoft.AspNetCore.Http;
using ShoppingPlace.Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Providers.GeneralProviders
{
    public class MySession : IMySession
    {
        private IHttpContextAccessor _httpContextAccessor;

        public MySession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long? UserId
        {
            get
            {
                return _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier) == null
                     ? null : long.Parse(_httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            }
        }

        public string Email
        {
            get
            {
                return _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email) == null
                     ? null : _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            }
        }
    }
}
