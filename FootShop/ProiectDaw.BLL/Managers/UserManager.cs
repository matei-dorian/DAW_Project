using ProiectDaw.BLL.Interfaces;
using ProiectDaw.DAL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repo;

        public UserManager(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> DeleteUser(int id)
        {
            var user = await _repo.GetById(id);
            if (user == null)
            {
                return -1;
            }

            await _repo.Delete(user);
            return 1;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await _repo.GetAll();
            return users;
        }
    }
}
