using BusinessObjects.Models;

namespace Server.Interface
{
    public interface IRoom
    {
        public Task<Room> GetAll();
        public Task<Room> AddOne(Room room);
        public List<Task<Room>> AddMany(List<Room> rooms);
        public Task<bool> Update(Room room);
        public Task<bool> Delete(Room room);
        public List<Task<Room>> Pagging(int page, int pageSize);
    }
}
