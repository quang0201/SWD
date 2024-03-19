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

        public async Task<bool> AddNewAccount(AccountModel account)
        {
            try
            {
                Account acc = _mapper.Map<Account>(account);
                return await _repo.AddNewAccount(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> DeleteAccount(string email)
        {
            try
            {
                return await _repo.DeleteAccount(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<AccountModel> GetAccountByEmail(string email)
        {

            try
            {
                Account acc = await _repo.GetAccountByEmail(email);
                return _mapper.Map<AccountModel>(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return new AccountModel();
            }
        }

        public async Task<bool> UpdateAccount(AccountModel account)
        {

            try
            {
                Account acc = _mapper.Map<Account>(account);
                return await _repo.UpdateAccount(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }
    }
}
