using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IDescriptionManager
    {
        Task CreateDescription(DescriptionModel model);
        Task<DescriptionModel> GetById(int id);
        Task<int> DeleteDescription(int id);
        Task<List<DescriptionModel>> GetAll();
        Task UpdateDescription(DescriptionModel model);
    }
}
