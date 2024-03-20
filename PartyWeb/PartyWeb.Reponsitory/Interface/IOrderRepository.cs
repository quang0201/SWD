using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitories.Interface
{
    public interface IOrderRepository
    {
        public Task<int> Add(Order order);
        public Task<bool> CheckDateOrder(int id,DateTime startDate,DateTime endDate);
        public Task<List<Order>> Pagging(int id, int index, int pageSize, bool? sortDateAsc, bool? sortPriceAsc);
    }
}
