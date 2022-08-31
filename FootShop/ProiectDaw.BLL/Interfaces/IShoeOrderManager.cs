using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IShoeOrderManager
    {
        Task CreateShoeOrder(ShoeOrderModel model);
        Task<int> DeleteShoeOrder(int id);
        Task<List<ShoeOrderModel>> GetAll();
        Task UpdateShoeOrder(ShoeOrderModel model);
        List<Shoe> GetOrderItems(int id);
    }
}
