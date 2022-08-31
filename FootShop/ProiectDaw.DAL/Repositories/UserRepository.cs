using Microsoft.EntityFrameworkCore;
using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await (await GetAllQuery()).ToListAsync();
            var list = new List<UserModel>();
            foreach (var user in users)
            {
                var userModel = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.PasswordHash
                };
                list.Add(userModel);
            }
            return list;
        }

        public async Task<IQueryable<User>> GetAllQuery()
        {
            var query = _context.Users.AsQueryable();
            return query;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

}

