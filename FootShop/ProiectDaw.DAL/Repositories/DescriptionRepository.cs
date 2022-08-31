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
    public class DescriptionRepository : IDescriptionRepository
    {
        private readonly AppDbContext _context;

        public DescriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Description desc)
        {
            await _context.Descriptions.AddAsync(desc);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Description desc)
        {
            _context.Remove(desc);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DescriptionModel>> GetAll()
        {
            var descriptions = await GetAllQuery().ToListAsync();
            var list = new List<DescriptionModel>();
            foreach (var description in descriptions)
            {
                var descModel = new DescriptionModel
                {
                    Id = description.Id,
                    Desc = description.Desc,
                    LastUpdate = description.LastUpdate
                   
                };
                list.Add(descModel);
            }
            return list;
        }
        public IQueryable<Description> GetAllQuery()
        {
            var query = _context.Descriptions.AsQueryable();
            return query;
        }

        public async Task<Description> GetById(int id)
        {
            var offer = await _context.Descriptions.FindAsync(id);
            return offer;
        }

        public async Task Update(Description desc)
        {
            _context.Descriptions.Update(desc);
            await _context.SaveChangesAsync();
        }
    }
}
