﻿using BusinessObjects.Models;
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
                return await _dbContext.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<List<Account>> GetAllRegisterHost()
        {
            try
            {
                var items = await _dbContext.Accounts.Where(x => x.Role == 0 && x.Status == 2).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
        public async Task<List<Account>> GetRegisterHostPagging(int index, int max, string search)
        {
            try
            {
                var items = await _dbContext.Accounts
                    .Where(x => x.Role == 0 && x.Status == 2)
                    .Skip((index - 1) * max)
                    .Take(max)
                    .ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<Account> Login(LoginModel login)
        {
            try
            {
                var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Username == login.UserName && a.Password == login.Password);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
