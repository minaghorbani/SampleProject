using Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IOrdersRepository
    {

        Task<vmPersonOrders> GetByPersonId(int id);
        Task<List<vmPersonOrders>> GetAll();
    }
}
