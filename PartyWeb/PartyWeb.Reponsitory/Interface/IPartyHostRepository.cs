using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IPartyHostRepository
    {
        Task<PartyHost> GetPartyHostById(int id);
        Task<bool> AddNewPartyHost(PartyHost partyHost);
        Task<bool> DeletePartyHost(int id);
        Task<bool> UpdatePartyHost(PartyHost partyHost);
    }
}
