using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> Add(Order order) => OrderDAO.Instance.Add(order);

        public Task<bool> CheckDateOrder(int id, DateTime startDate, DateTime endDate)
            => OrderDAO.Instance.CheckRoomDateBook(id, startDate, endDate);
    }
}
