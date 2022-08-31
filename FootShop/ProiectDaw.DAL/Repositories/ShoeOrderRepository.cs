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
    public class ShoeOrderRepository : IShoeOrderRepository
    {
        private readonly AppDbContext _context;

        public ShoeOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ShoeOrder shoeOrder)
        {
            await _context.ShoeOrders.AddAsync(shoeOrder);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ShoeOrder shoeOrder)
        {
            _context.Remove(shoeOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoeOrderModel>> GetAll()
        {
            var objs = await (await GetAllQuery()).ToListAsync();
            var list = new List<ShoeOrderModel>();
            foreach (var obj in objs)
            {
                var model = new ShoeOrderModel
                {
                    Id = obj.Id,
                    ShoeId = obj.ShoeId,
                    OrderId = obj.OrderId,
                    Quantity = obj.Quantity
                };
                list.Add(model);
            }
            return list;
        }

        public async Task<IQueryable<ShoeOrder>> GetAllQuery()
        {
            var query = _context.ShoeOrders.AsQueryable();
            return query;
        }
        public IQueryable<ShoeOrder> GetFullList()
        {
            var query = _context.ShoeOrders.Include(x => x.Shoe).AsQueryable();
            return query;
        }

        public async Task<ShoeOrder> GetById(int id)
        {
            var shoeOrder = await _context.ShoeOrders.FindAsync(id);
            return shoeOrder;
        }

        public async Task Update(ShoeOrder shoeOrder)
        {
            _context.ShoeOrders.Update(shoeOrder);
            await _context.SaveChangesAsync();
        }
    }
}
