using AutoMapper;
using Common.Entity;
using Repository.Entity;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        private readonly IRepository<Recipe> recipeRepository;
        public UserService(IRepository<User> repository, IMapper mapper, IRepository<Recipe> recipeRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.recipeRepository = recipeRepository;
        }
        public async Task<UserDto> AddItemAsync(UserDto item)
        {

            return mapper.Map<UserDto>(await repository.AddItemAsync(mapper.Map<User>(item)));

            //await repository.AddItemAsync(mapper.Map<User>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetAsyncById(int id)
        {
            return mapper.Map<UserDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return mapper.Map<List<UserDto>>(await repository.GetAllAsync());
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto item)
        {
            return mapper.Map<UserDto>(await repository.UpdateAsync(id, mapper.Map<User>(item)));

           
        }
        public async Task<UserDto> GetUserByEmailAndPassword(string email, string password)
        {

            List<User> users = await repository.GetAllAsync();
            
                User user =  users.FirstOrDefault(x => x.Email == email&&x.Password==password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
                return mapper.Map<UserDto>(user);

        }
        //public async Task<UserDto> AddFavorite(int recipeId, int userId)
        //{

        //    List<User> users = await repository.GetAllAsync();
        //    List<Recipe> recipes = await recipeRepository.GetAllAsync();

        //    User user = users.FirstOrDefault(x => x.Id == userId);
        //    Recipe recipe = recipes.FirstOrDefault(x => x.Id == recipeId);

        //    if (user != null&&recipe!=null)
        //    {
        //        user.FavoriteRecipes.Add(recipe);
        //    }
        //    else
        //        throw new Exception("User not found");

        //    await repository.UpdateAsync(user.Id,user);
        //    return mapper.Map<UserDto>(user);


        //}
        //public async Task<UserDto> RemoveFavorite(int recipeId, int userId)
        //{

        //    List<User> users = await repository.GetAllAsync();
        //    List<Recipe> recipes = await recipeRepository.GetAllAsync();

        //    User user = users.FirstOrDefault(x => x.Id == userId);
        //    Recipe recipe = recipes.FirstOrDefault(x => x.Id == recipeId);

        //    if (user != null && recipe != null)
        //    {
        //        user.FavoriteRecipes.Remove(recipe);
        //    }
        //    else
        //        throw new Exception("User not found");

        //    await repository.UpdateAsync(user.Id, user);
        //    return mapper.Map<UserDto>(user);


        //}

    }
}

