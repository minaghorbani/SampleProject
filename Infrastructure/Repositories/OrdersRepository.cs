using Domain.ViewModels.Order;
using Infrastructure.DapperRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ILogger<OrdersRepository> _logger;

        public OrdersRepository(ILogger<OrdersRepository> logger)
        {
            _logger = logger;
        }

        public async Task<List<vmPersonOrders>> GetAll()
        {

            try
            {
                var res = await DataAccess.SelectList<vmPersonOrders>("Exec GetOrders @Id_Person=@Id_Person", new { @Id_Person = 1 });

                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderRepository Error: {ex.Message}");
                return null;
            }
        }

        public Task<vmPersonOrders> GetByPersonId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
