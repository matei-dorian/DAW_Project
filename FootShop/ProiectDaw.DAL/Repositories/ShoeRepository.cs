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
    public class ShoeRepository : IShoeRepository
    {
        private readonly AppDbContext _context;

        public ShoeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Shoe shoe)
        {
            await _context.Shoes.AddAsync(shoe);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Shoe shoe)
        {
            _context.Remove(shoe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoeModel>> GetAll()
        {
            var shoes = await GetAllQuery().ToListAsync();
            var list = new List<ShoeModel>();
            foreach (var shoe in shoes)
            {
                var shoeModel = new ShoeModel
                {
                     Id = shoe.Id,
                     Name = shoe.Name,
                     Brand = shoe.Brand,
                     Price = shoe.Price,
                     Colour = shoe.Colour,
                     Category = shoe.Category, 
                     Type = shoe.Type,
                     Image = shoe.Image,
                     Rating = shoe.Rating
    };
                list.Add(shoeModel);
            }
            return list;
        }

        public IQueryable<Shoe> GetAllQuery()
        {
            var query = _context.Shoes.AsQueryable();
            return query;
        }

        public async Task<Shoe> GetById(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            return shoe;
        }

        public async Task Update(Shoe shoe)
        {
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }
        
        public IQueryable<ShoeModel> GetWithOffers()
        {
            var offers = _context.Offers.Where(x => x.EndDate >= DateTime.Now);
            var join = _context.Shoes.Join(offers, x => x.Id, y => y.ShoeId, (x, y) => new ShoeModel
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                Price = x.Price + y.Discount * x.Price / 100,
                Colour = x.Colour,
                Category = x.Category,
                Type = x.Type,
                Image = x.Image,
                Rating = x.Rating,
                Promo = true
            });
            return join;
        }
    }
}
