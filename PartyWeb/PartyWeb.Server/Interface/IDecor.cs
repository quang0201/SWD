using BusinessObjects.Models;

namespace Server.Interface
{
    public interface IDecor
    {
        List<Decor> GetAll();
        Task<bool> AddOne(Decor decor);
        Task<bool> AddMany(List<Decor> decors);
        Task<bool> Update(Decor decor);
        Task<bool> Delete(Decor decor);
        List<Decor> Pagging(int page, int pageSize);
        Decor GetById(int id);
    }
}
