using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IOrderManager
    {
        Task CreateOrder(OrderModel model);
        Task<int> DeleteOrder(int id);
        Task<List<OrderModel>> GetAll();
        Task UpdateOrder(OrderModel model);
    }
}
