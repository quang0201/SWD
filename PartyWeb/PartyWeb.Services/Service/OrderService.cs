using ModelViews.Models;
using Reponsitories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tool;

namespace Services.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo = default!;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        public Task<OrderModel> Add(OrderModel model, string user)
        {
            try
            {
                if(Validation.Instance.CheckDateTime(model.orderRooms.StartDate,model.orderRooms.EndDate))
                {
                    throw new Exception("The day not alivable");
                }

                foreach (var item in model.orderDecors)
                {
                    if (item.Id < 0)
                    {
                        throw new Exception("id must integer number");
                    }
                    if (item.Quality < 0)
                    {
                        throw new Exception("Quatity must integer number");
                    }
                }
                foreach (var item in model.orderFoods)
                {
                    if (item.Id < 0)
                    {
                        throw new Exception("id must integer number");
                    }
                    if (item.Quatity < 0)
                    {
                        throw new Exception("Quatity must integer number");
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
