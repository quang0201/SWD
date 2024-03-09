using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObjects.Models;
using ModelViews;
using Reponsitories.Interface;
using Services.Interface;
using Tools.Tool;

namespace Services.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _RoomRepo;

        public RoomService(IRoomRepository RoomRepository)
        {
            _RoomRepo = RoomRepository;
        }

        public async Task<Tuple<string, bool>> AddRoom(RoomModel Room, Account account)
        {
            if (!RegexString.Instance.ValidateInputVietnamese(Room.Name))
            {
                return Tuple.Create("Tên không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputVietnamese(Room.Content))
            {
                return Tuple.Create("Nội dung không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputDigitsLengthMinMax(Room.Price, 1, 15))
            {
                return Tuple.Create("Giá tiền không phù hợp", false);
            }
            if (int.Parse(Room.Price) < 0)
            {
                return Tuple.Create("Nhập một số hợp lệ", false);
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
            var result = await _RoomRepo.Add(RoomDTO);
            if (!result)
            {
                return Tuple.Create("Lỗi", false);
            }
            return Tuple.Create(JsonSerializer.Serialize(Room), true);
        }

    }
}
