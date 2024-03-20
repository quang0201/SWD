using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using ModelViews.Models;

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
        public async Task<bool> IsExistedEmail(string email)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var count = await dbContext.Accounts.Where(x => x.Email == email).CountAsync();
                    if (count > 0) return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }
        public async Task<List<Account>> GetAccounts()
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    return await dbContext.Accounts.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return new List<Account>();
        }

        public async Task<bool> IsExistedUsername(string username)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var count = await dbContext.Accounts.Where(x => x.Username == username).CountAsync();
                    if (count > 0) return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }

        public async Task<Account> Login(LoginModel account)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.Where(x => x.Status == 1).FirstOrDefaultAsync(a => a.Username == account.Username && a.Password == account.Password);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return null;
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
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }
        public async Task<bool> GetUserByUserName(string userName)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Username == userName);
                    if (user == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;

        }
        public async Task<Account> GetUserByUserId(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Id == id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return null;
        }

        public async Task<Account> GetAccountById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Id == id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return new Account();
        }

        public async Task<bool> AddAccount(Account account)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == account.Email);

                    if (user == null)
                    {
                        dbContext.Accounts.Add(account);
                        if (dbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == account.Email);

                    if (user != null)
                    {
                        user.Address = account.Address;
                        user.Username = account.Username;
                        user.CreatedTime = account.CreatedTime;
                        user.DeletedTime = account.DeletedTime;
                        user.Password = account.Password;
                        user.Infomation = account.Infomation;
                        user.Dob = account.Dob;
                        user.Fullname = account.Fullname;
                        user.Status = account.Status;
                        user.Role = account.Role;
                        user.UpdatedTime = account.UpdatedTime;
                        dbContext.Accounts.Update(user);
                        if (dbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var user = await dbContext.Accounts.FirstOrDefaultAsync(u => u.Id == id);
                    if (user != null)
                    {
                        var orders = dbContext.Orders.Where(x => x.CreatedBy == user.Id).ToList();
                        var decors = dbContext.Decors.Where(x => x.CreatedBy == user.Id).ToList();
                        var foods = dbContext.Foods.Where(x => x.CreatedBy == user.Id).ToList();
                        var rooms = dbContext.Rooms.Where(x => x.CreatedBy == user.Id).ToList();

                        foreach (var item in orders)
                        {
                            var orderDecors = dbContext.OrderDecors.Where(x => x.IdOrder == item.Id).ToList();
                            var orderFoods = dbContext.OrderFoods.Where(x => x.IdOrder == item.Id).ToList();
                            var orderRooms = dbContext.OrderRooms.Where(x => x.IdOrder == item.Id).ToList();

                            dbContext.RemoveRange(orderDecors);
                            dbContext.RemoveRange(orderFoods);
                            dbContext.RemoveRange(orderRooms);
                        }

                        dbContext.RemoveRange(orders);
                        dbContext.RemoveRange(decors);
                        dbContext.RemoveRange(foods);
                        dbContext.RemoveRange(rooms);
                        dbContext.Remove(user);
                        if (dbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xảy ra: " + ex.ToString());
            }
            return false;
        }
    }
}
