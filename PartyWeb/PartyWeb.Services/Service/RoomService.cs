using AutoMapper;
using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews.Models;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Reponsitories.Repositories;
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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _RoomRepo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public RoomService(IRoomRepository RoomRepository, IMapper mapper, IUserRepository userRepo)
        {
            _RoomRepo = RoomRepository;
            _mapper = mapper;
            _userRepository = userRepo;
        }

        public async Task<bool> AddRoom(RoomModel Room, string userId)
        {
            try
            {
                if (!Validation.Instance.CheckStringMinMax(Room.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Room.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(Room.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Room.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(Room.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(Room.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(userId);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                if (account.Role == 0)
                {
                    throw new Exception("you not role host");
                }
                var RoomDTO = new Room()
                {
                    Name = Room.Name,
                    Content = Room.Content,
                    Price = int.Parse(Room.Price),
                    CreatedBy = account.Id,
                    Status = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow
                };
                //status 
                //1 là active
                //0 là delete
                //2 là chờ approve
                //3 là bị từ chối
                var result = await _RoomRepo.Add(RoomDTO);
                if (!result)
                {
                    throw new Exception("Add Fail");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<bool> Update(UpdateRoomModel Room, string user)
        {
            try
            {

                if (!Validation.Instance.CheckStringMinMax(Room.Room.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Room.Room.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(Room.Room.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Room.Room.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(Room.Room.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(Room.Room.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var RoomDTO = await _RoomRepo.GetById(Room.Id);
                if (RoomDTO == null)
                {
                    throw new Exception("Room not found");
                }
                if (RoomDTO.Status != 1)
                {
                    throw new Exception("Room not active");
                }
                if (account.Role != 1)
                {
                    if (RoomDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Room not yours");
                    }
                }
                RoomDTO.Name = Room.Room.Name;
                RoomDTO.Price = int.Parse(Room.Room.Price);
                RoomDTO.Content = Room.Room.Content;
                RoomDTO.UpdatedTime = DateTime.Now;
                var result = await _RoomRepo.Update(RoomDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }


        public async Task<bool> Delete(int id, string user)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var RoomDTO = await _RoomRepo.GetById(id);
                if (RoomDTO == null)
                {
                    throw new Exception("Room not found");
                }
                if (RoomDTO.Status != 1)
                {
                    throw new Exception("Room not active");
                }
                if (account.Role != 1)
                {
                    if (RoomDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Room not yours");
                    }
                }
                RoomDTO.Status = 0;
                RoomDTO.DeletedTime = DateTime.Now;
                var result = await _RoomRepo.Update(RoomDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<List<RoomViewModel>> PaggingRoom(int index, int pageSize, string? search, bool? sortDate, bool? sortPrice, bool? sortName)
        {
            try
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("index must be >= 0");
                }
                if (pageSize < 0 || pageSize > 100)
                {
                    throw new ArgumentOutOfRangeException("range 1-100");
                }

                var items = await RoomDAO.Instance.PaggingRoom(index, pageSize, search, sortDate, sortPrice, sortName);
                var itemsMapper = _mapper.Map<List<RoomViewModel>>(items);
                return itemsMapper; // Trả về dữ liệu thành công
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
        public async Task<Room> Approve(int id, string userId)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("number invaild");
                }
                var user = await _userRepository.GetUserById(int.Parse(userId));
                if (user == null)
                {
                    throw new Exception("not found your account");
                }
                if (user.Role == 0)
                {
                    throw new Exception("you have access");
                }
                var roomDTO = await _RoomRepo.GetById(id);
                if (roomDTO == null)
                {
                    throw new Exception("Food not found");
                }
                if (roomDTO.Status == 1)
                {
                    throw new Exception("Food is actived");
                }
                if (user.Role != 1)
                {
                    throw new Exception("Dont Access");
                }
                roomDTO.Status = 1;
                roomDTO.UpdatedTime = DateTime.Now;
                var result = await _RoomRepo.Update(roomDTO);
                return roomDTO;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
