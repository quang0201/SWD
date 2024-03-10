using AutoMapper;
using BusinessObjects.Models;
using ModelViews.Models;
using Reponsitories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools.Tool;

namespace Services.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo = default!;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _mapper = mapper;
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
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var itemsMapper = _mapper.Map<List<OrderDecor>>(model.orderDecors);
                
               
                return null;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
