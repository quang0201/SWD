using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class PartyHostRepository : IPartyHostRepository
    {
        public async Task<bool> AddNewPartyHost(PartyHost partyHost) => await PartyHostDAO.Instance.AddPartyHost(partyHost);
        public async Task<bool> DeletePartyHost(int id) => await PartyHostDAO.Instance.DeletePartyHost(id);
        public async Task<PartyHost> GetPartyHostById(int id) => await PartyHostDAO.Instance.GetPartyHostById(id);
        public async Task<bool> UpdatePartyHost(PartyHost partyHost) => await PartyHostDAO.Instance.UpdatePartyHost(partyHost);
    }
}
