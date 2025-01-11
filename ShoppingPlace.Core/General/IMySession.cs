using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingPlace.Core.General
{
    public interface IMySession
    {
        long? UserId { get; }
        string Email { get; }
    }
}
