using ModelViews.ModelView;

namespace Services.Interface
{
    public interface IPartyPostService
    {
        Task<PartyPostModel> GetPartyPostById(int id);
        Task<bool> AddNewPartyPost(PartyPostModel partyPost);
        Task<bool> DeletePartyPost(int id);
        Task<bool> UpdatePartyPost(PartyPostModel partyPost);
    }
}
