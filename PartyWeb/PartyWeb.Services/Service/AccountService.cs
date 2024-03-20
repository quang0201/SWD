using AutoMapper;
using BusinessObjects.Models;
using ModelViews.ModelView;
using ModelViews.ModelView.Accounts;
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

        public async Task<bool> AddNewAccount(AddNewAccountModel account)
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

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                return await _repo.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<ViewAccountModel> GetAccountById(int id)
        {

            try
            {
                Account acc = await _repo.GetAccountById(id);
                return _mapper.Map<ViewAccountModel>(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return new ViewAccountModel();
            }
        }

        public async Task<List<ViewAccountModel>> GetAccounts()
        {
            try
            {
                List<Account> accounts = await _repo.GetAccounts();
                List<ViewAccountModel> vms = _mapper.Map<List<ViewAccountModel>>(accounts);
                return vms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return new List<ViewAccountModel>();
            }
        }

        public async Task<bool> IsExistAccountEmail(string email)
        {
            try
            {
                return await _repo.IsExistAccountEmail(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> IsExistAccountUsername(string username)
        {
            try
            {
                return await _repo.IsExistAccountUsername(username);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> UpdateAccount(UpdateAccountModel account)
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
