using Common.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService :IService<UserDto>
    {
        public Task<UserDto> GetUserByEmailAndPassword(string email,string password);
        //public Task<UserDto> RemoveFavorite(int recipeId, int userId);
        //public Task<UserDto> AddFavorite(int recipeId, int userId);


    }
}
