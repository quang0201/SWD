﻿using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<int> Add(Order order) => OrderDAO.Instance.Add(order);

        public Task<bool> CheckDateOrder(int id, DateTime startDate, DateTime endDate)
            => OrderDAO.Instance.CheckRoomDateBook(id, startDate, endDate);

        public Task<List<Order>> Pagging(int id, int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc)
            => OrderDAO.Instance.PaggingOrder(id, index,pageSize,sortDateAsc, sortPriceAsc);

        public Task<List<Food>> PaggingHost(int id, int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc)
            => OrderDAO.Instance.PaggingOrderHost(id, index, pageSize, sortDateAsc, sortPriceAsc);
    }
}
