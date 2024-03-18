using ModelViews.ModelView;

namespace Services.Interface
{
    public interface IPartyHostService
    {
        Task<PartyHostModel> GetPartyHostModelById(int id);
        Task<bool> AddNewPartyHostModel(PartyHostModel partyHost);
        Task<bool> DeletePartyHostModel(int id);
        Task<bool> UpdatePartyHostModel(PartyHostModel partyHost);
    }
}
