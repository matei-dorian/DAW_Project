using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<User> GetById(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<IQueryable<User>> GetAllQuery();
    }
}
