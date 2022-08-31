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
    public class ShoeSizeRepository : IShoeSizeRepository
    {
        private readonly AppDbContext _context;

        public ShoeSizeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ShoeSize shoeSize)
        {
            await _context.ShoeSizes.AddAsync(shoeSize);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ShoeSize shoeSize)
        {
            _context.Remove(shoeSize);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoeSizeModel>> GetAll()
        {
            var shoeSizes = await GetAllQuery().ToListAsync();
            var list = new List<ShoeSizeModel>();
            foreach (var shoeSize in shoeSizes)
            {
                var shoeSizeModel = new ShoeSizeModel
                {
                    Id = shoeSize.Id,
                    Quantity = shoeSize.Quantity,
                    Size = shoeSize.Size,
                    ShoeId = shoeSize.ShoeId
                };
                list.Add(shoeSizeModel);
            }
            return list;
        }

        public IQueryable<ShoeSize> GetAllQuery()
        {
            var query = _context.ShoeSizes.AsQueryable();
            return query;
        }

        public async Task<ShoeSize> GetById(int id)
        {
            var shoeSize = await _context.ShoeSizes.FindAsync(id);
            return shoeSize;
        }

        public async Task Update(ShoeSize shoeSize)
        {
            _context.ShoeSizes.Update(shoeSize);
            await _context.SaveChangesAsync();
        }
    }
}
