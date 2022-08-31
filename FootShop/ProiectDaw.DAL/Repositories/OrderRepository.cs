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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderModel>> GetAll()
        {
            var orders = await (await GetAllQuery()).ToListAsync();
            var list = new List<OrderModel>();
            foreach (var order in orders)
            {
                var orderModel = new OrderModel
                {
                    Id = order.Id,
                    Address = order.Address,
                    City = order.City,
                    Distributor = order.Distributor,
                    Price = order.Price,
                    OrderDate = order.OrderDate,
                    ShippingDate = order.ShippingDate,
                    UserId = order.UserId
                   
                };
                list.Add(orderModel);
            }
            return list;
        }

        public async Task<IQueryable<Order>> GetAllQuery()
        {
            var query = _context.Orders.AsQueryable();
            return query;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
