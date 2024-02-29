using BusinessObjects.Models;

namespace Server.Interface
{
    public interface IUser
    {
        public Task<Account> GetAll();
        public Task<Account> AddOne(Account decor);
        public List<Task<Account>> AddMany(List<Account> decors);
        public Task<bool> Update(Account decor);
        public Task<bool> Delete(Account decor);
        public List<Task<Account>> Pagging(int page, int pageSize);

    }
}
