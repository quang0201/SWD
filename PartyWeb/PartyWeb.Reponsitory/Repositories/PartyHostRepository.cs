using BusinessObjects.Models;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class PartyHostRepository : IPartyHostRepository
    {
        public Task<bool> AddNewPartyHostModel(PartyHost partyHost)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePartyHostModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PartyHost> GetPartyHostModelById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePartyHostModel(PartyHost partyHost)
        {
            throw new NotImplementedException();
        }
    }
}
