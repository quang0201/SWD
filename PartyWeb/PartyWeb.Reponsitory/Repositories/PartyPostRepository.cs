using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class PartyPostRepository : IPartyPostRepository
    {
        public async Task<bool> AddNewPartyPost(PartyPost partyPost) => await PartyPostDAO.Instance.AddPartyPost(partyPost);
        public async Task<bool> DeletePartyPost(int id) => await PartyPostDAO.Instance.DeletePartyPost(id);
        public async Task<PartyPost> GetPartyPostById(int id) => await PartyPostDAO.Instance.GetPartyPostById(id);
        public async Task<bool> UpdatePartyPost(PartyPost partyPost) => await PartyPostDAO.Instance.UpdatePartyPost(partyPost);
    }
}
