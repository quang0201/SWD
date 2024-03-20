using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IPartyPostRepository
    {
        Task<PartyPost> GetPartyPostById(int id);
        Task<bool> AddNewPartyPost(PartyPost partyPost);
        Task<bool> DeletePartyPost(int id);
        Task<bool> UpdatePartyPost(PartyPost partyPost);
    }
}
