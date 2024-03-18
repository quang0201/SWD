using AutoMapper;
using BusinessObjects.Models;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
         
        }

        public Task<bool> AddNewAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }
    }
}
