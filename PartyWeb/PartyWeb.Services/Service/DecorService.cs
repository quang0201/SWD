using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelViews;
using BusinessObjects.Models;
using Reponsitories.Interface;
using Tools.Tool;
using System.Text.Json;

namespace Services.Service
{
    public class DecorService : IDecorService
    {
        private readonly IDecorRepository _DecorRepo;

        public DecorService(IDecorRepository DecorRepository)
        {
            _DecorRepo = DecorRepository;
        }

        public async Task<Tuple<string, bool>> AddDecor(DecorModel Decor, Account account)
        {
            if (!RegexString.Instance.ValidateInputVietnamese(Decor.Name))
            {
                return Tuple.Create("Tên không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputVietnamese(Decor.Content))
            {
                return Tuple.Create("Nội dung không phù hợp", false);
            }
            if (!RegexString.Instance.ValidateInputDigitsLengthMinMax(Decor.Price, 1, 15))
            {
                return Tuple.Create("Giá tiền không phù hợp", false);
            }
            if (int.Parse(Decor.Price) < 0)
            {
                return Tuple.Create("Nhập một số hợp lệ", false);
            }
            var DecorDTO = new Decor()
            {
                Name = Decor.Name,
                Content = Decor.Content,
                Price = int.Parse(Decor.Price),
                CreatedBy = account.Id,
                Status = 2,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            };
            //status 
            //1 là active
            //0 là delete
            //2 là chờ approve
            var result = await _DecorRepo.Add(DecorDTO);
            if (!result)
            {
                return Tuple.Create("Lỗi", false);
            }
            return Tuple.Create(JsonSerializer.Serialize(Decor), true);
        }


    }
}
