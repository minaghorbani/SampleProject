using Domain.ViewModels.Order;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderApplication
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _OrderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger, IOrdersRepository orderRepository)
        {
            _OrderRepository = orderRepository;
            _logger = logger;

        }
        public Task<List<vmPersonOrders>> GetAll()
        {
            try
            {
                _logger.LogInformation("select PersonOrders");
                return _OrderRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderService Error: {ex.Message}");
                return null;
            }
        }
    }
}
