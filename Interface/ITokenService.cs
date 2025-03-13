using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Entities;

namespace AuthApi.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}