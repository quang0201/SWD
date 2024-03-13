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
        IRoomRepository _roomRepo = default!;
        IFoodRepository _foodRepo = default!;
        IDecorRepository _decorRepo = default!;
        public OrderService(IOrderRepository orderRepository,IMapper mapper, IRoomRepository roomRepo, IFoodRepository foodRepo, IDecorRepository decorRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepository;
            _roomRepo = roomRepo;
            _foodRepo = foodRepo;
            _decorRepo = decorRepo;
        }
        public async Task<bool> Add(OrderModel model, string user)
        {
            try
            {
                List<OrderFood> foods = default!;
                List<OrderDecor> decors = default!;
                if(Validation.Instance.CheckDateTime(model.orderRooms.StartDate,model.orderRooms.EndDate))
                {
                    throw new Exception("The day not alivable");
                }
                var room = await _roomRepo.GetById(model.orderRooms.IdRoom);
                Console.WriteLine(room == null);
                if (room == null)
                {
                    throw new Exception("Not found room");
                }
                var roomOrder = _mapper.Map<OrderRoom>(model.orderRooms);
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
                    if(_decorRepo.GetById(item.Id) == null)
                    {
                        throw new Exception("Not found decor");
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
                    if (_foodRepo.GetById(item.Id) == null)
                    {
                        throw new Exception("Not found food");
                    }
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }

                var order = new Order()
                {
                    Status = 2,
                    CreatedTime = DateTime.Now,
                    CreatedBy = account.Id,
                };
                var result = await _orderRepo.Add(order);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
