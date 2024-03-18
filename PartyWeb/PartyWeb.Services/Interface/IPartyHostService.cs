using ModelViews.ModelView;

namespace Services.Interface
{
    public interface IPartyHostService
    {
        Task<PartyHostModel> GetPartyHostById(int id);
        Task<bool> AddNewPartyHost(PartyHostModel partyHost);
        Task<bool> DeletePartyHost(int id);
        Task<bool> UpdatePartyHost(PartyHostModel partyHost);
    }
}
