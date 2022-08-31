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
    public class ShoeOrderManager : IShoeOrderManager
    {
        private readonly IShoeOrderRepository _repo;

        public ShoeOrderManager(IShoeOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateShoeOrder(ShoeOrderModel model)
        {
            var shoeOrder = new ShoeOrder
            {
                ShoeId = model.ShoeId,
                OrderId = model.OrderId,
                Quantity = model.Quantity
            };

            await _repo.Create(shoeOrder);
        }

        public async Task<int> DeleteShoeOrder(int id)
        {
            var shoeOrder = await _repo.GetById(id);
            if (shoeOrder == null)
            {
                return -1;
            }

            await _repo.Delete(shoeOrder);
            return 1;
        }

        public async Task<List<ShoeOrderModel>> GetAll()
        {
            var shoeOrders = await _repo.GetAll();
            return shoeOrders;
        }

        public async Task UpdateShoeOrder(ShoeOrderModel model)
        {
            var shoeOrder = await _repo.GetById(model.Id);
            if (shoeOrder == null)
            {
                throw new Exception();
            }

            shoeOrder.Quantity = shoeOrder.Quantity;
            await _repo.Update(shoeOrder);
        }

        public List<Shoe> GetOrderItems(int id)
        {
            var shoeOrders = _repo.GetFullList().Where(x => x.OrderId == id).Select(x => x.Shoe).ToList();
            if (shoeOrders == null)
                throw new Exception();
            return shoeOrders;

        }
    }
}
