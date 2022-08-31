using ProiectDaw.BLL.Interfaces;
using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _repo;

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateOrder(OrderModel model)
        {
            var order = new Order
            {
                Address = model.Address,
                City = model.City,
                Distributor = model.Distributor,
                Price = model.Price,
                OrderDate = model.OrderDate,
                ShippingDate = model.ShippingDate
            };

            await _repo.Create(order);
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await _repo.GetById(id);
            if (order == null)
            {
                return -1;
            }

            await _repo.Delete(order);
            return 1;
        }

        public async Task<List<OrderModel>> GetAll()
        {
            var orders = await _repo.GetAll();
            return orders;
        }

        public async Task UpdateOrder(OrderModel model)
        {
            var order = await _repo.GetById(model.Id);
            if (order == null)
            {
                throw new Exception();
            }

            order.Address = model.Address;
            order.City = model.City;
            await _repo.Update(order);
        }
    }
}
