using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Models;

namespace NewsSite.Repository.IRepostiory
{
    public interface IAuthRepository
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model); // login
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
