using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private readonly SwdContext _dbContext;
        public AccountDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new SwdContext();
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
        public async Task<List<Account>> GetAll()
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var accountList = await dbContext.Accounts.ToListAsync();
                    Console.WriteLine(accountList.Count);
                    if (accountList.Count == 0)
                    {
                        Console.WriteLine("Danh sách không có phần tử.");
                    }
                    return accountList;
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception("Loi here");
            }
        }
    }
}
