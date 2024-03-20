using AutoMapper;
using BusinessObjects.Models;
using ModelViews.Models;
using Net.payOS.Types;
using Reponsitories.Interface;
using Reponsitories.Repositories;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        IUserRepository _userRepository;
        IPaymentRepository _waymentRepo = default!;
        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository,
            IMapper mapper, IRoomRepository roomRepo, IFoodRepository foodRepo, IDecorRepository decorRepo, IPaymentRepository waymentRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepository;
            _roomRepo = roomRepo;
            _foodRepo = foodRepo;
            _decorRepo = decorRepo;
            _userRepository = userRepository;
            _waymentRepo = waymentRepo;
        }
        public async Task<CreatePaymentResult> Add(OrderModel model, string userId)
        {
            try
            {
                List<OrderFood> foods=new List<OrderFood>();
                List<OrderDecor> decors =new List<OrderDecor>();
                decimal total = 0;
                var room = await _roomRepo.GetById(model.orderRooms.IdRoom);
                Console.WriteLine(room == null);
                if (room == null)
                {
                    throw new Exception("Not found room");
                }
                if (Validation.Instance.CheckDateTime(model.orderRooms.StartDate, model.orderRooms.EndDate))
                {
                    throw new Exception("The day not alivable");
                }
                var checkDate = await _orderRepo.CheckDateOrder(room.Id, model.orderRooms.StartDate, model.orderRooms.EndDate);
                if (checkDate)
                {
                    throw new Exception("The day exist book");
                }
                TimeSpan duration = model.orderRooms.EndDate.Subtract(model.orderRooms.StartDate);
                int numberOfDays = duration.Days+1;
                total += (numberOfDays * room.Price ?? 0);

                var roomOrder = new OrderRoom
                {
                    IdRoom = room.Id,
                    Status = 2,
                    StartDate = model.orderRooms.StartDate,
                    EndDate = model.orderRooms.EndDate,
                    TotalPrice = (numberOfDays * room.Price ?? 0),
                };

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
                    var decor = await _decorRepo.GetById(item.Id);
                    if (decor == null)
                    {
                        throw new Exception("Not found decor");
                    }
                    total += item.Quality * decor.Price ?? 0;
                    var orderItem = new OrderDecor
                    {
                        IdDecor = item.Id,
                        Quality = item.Quality,
                        TotalPrice = item.Quality * decor.Price ?? 0,
                        Status = 2
                    };
                    decors.Add(orderItem);
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
                    var food = await _foodRepo.GetById(item.Id);
                    if (food == null)
                    {
                        throw new Exception("Not found food");
                    }
                    total += item.Quatity * food.Price ?? 0;
                    var orderItem = new OrderFood
                    {
                        IdFood = item.Id,
                        Quality = item.Quatity,
                        TotalPrice = item.Quatity * food.Price ?? 0,
                        Status = 2
                    };
                    foods.Add(orderItem);
                }


                var user = await _userRepository.GetUserById(int.Parse(userId));
                if (user == null)
                {
                    throw new Exception("not found your account");
                }
                int totalPayment = await _waymentRepo.GetTotalPayment();

                var payment = await PayOSPayment.Instance.CreatePayment(user,(int)total, totalPayment);
                var paymentOs = new Payment()
                {
                    CreatedBy = user.Id,
                    Status = 2,
                    Amount = (int)total,
                    TimeCreate = DateTime.Now,
                    TransIdSystem = payment.paymentLinkId
                };
                await _waymentRepo.Add(paymentOs);
                var order = new Order()
                {
                    Status = 2,
                    CreatedTime = DateTime.Now,
                    CreatedBy = user.Id,
                    OrderDecors = decors,
                    OrderFoods = foods,
                    OrderRoom = roomOrder,
                    Price = total
                };
                var result = await _orderRepo.Add(order);

                if (!result)
                {
                    throw new Exception("Error create order");
                }
                return payment;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
