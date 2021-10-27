using Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderApplication
{
    public interface IOrderService
    {
        Task<List<vmPersonOrders>> GetAll();
    }
}
