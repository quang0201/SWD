using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = default!;
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

        public async Task<Account> Login(LoginModel account)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Username == account.username && a.Password == account.password);
                    return user;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<bool> Register(Account account)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    await dbContext.Accounts.AddAsync(account);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<bool> GetUserByUserName(string userName)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Username == userName);
                    if(user == null)
                    {
                        return false;
                    }
                    return true;    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
