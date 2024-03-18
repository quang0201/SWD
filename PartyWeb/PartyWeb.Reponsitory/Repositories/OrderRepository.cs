using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> Add(Order order) => OrderDAO.Instance.Add(order);
    }
}
