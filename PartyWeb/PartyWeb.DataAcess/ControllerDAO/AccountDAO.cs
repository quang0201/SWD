using BusinessObjects.Models;
using BusinessObjects.RequestModels;
using BusinessObjects.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly SwdContext dbContext = null;
        public AccountDAO()
        {
            if (dbContext == null)
            {
                dbContext = new SwdContext();
            }
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await dbContext.Accounts.ToListAsync();
        }
        public async Task<Account> GetAccount(string username, string password)
        {
            var user = await dbContext.Accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<Account> Login(LoginRequest request)
        {
            var user = await dbContext.Accounts.SingleOrDefaultAsync(a => a.Email == request.Email && a.Password == request.Password);
            if (user == null)
            {
                return null;
            }
            Account result = new Account
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                CreatedBy = user.CreatedBy,
                CreatedTime = user.CreatedTime,
                Id = user.Id,
                Infomation = user.Infomation,
            };
            return result;
        }
        public async Task<int> CreateAccount(Account account)
        {
            var user = await dbContext.Accounts.SingleOrDefaultAsync(a => a.Username == account.Username || a.Email == account.Email);
            if (user != null)
            {
                return -1;
            }
            else
            {
                await dbContext.Accounts.AddAsync(account);
            }
            await dbContext.SaveChangesAsync();
            return 0;
        }
    }
}
