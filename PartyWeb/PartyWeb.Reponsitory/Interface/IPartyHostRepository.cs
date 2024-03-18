using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IPartyHostRepository
    {
        Task<PartyHost> GetPartyHostModelById(int id);
        Task<bool> AddNewPartyHostModel(PartyHost partyHost);
        Task<bool> DeletePartyHostModel(int id);
        Task<bool> UpdatePartyHostModel(PartyHost partyHost);
    }
}
