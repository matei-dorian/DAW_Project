using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order order);
        Task Update(Order order);
        Task Delete(Order order);
        Task<IQueryable<Order>> GetAllQuery();
    }
}
