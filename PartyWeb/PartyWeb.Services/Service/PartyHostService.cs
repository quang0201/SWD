using AutoMapper;
using BusinessObjects.Models;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class PartyHostService : IPartyHostService
    {
        private readonly IPartyHostRepository _repo;
        private readonly IMapper _mapper;

        public PartyHostService(IPartyHostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<bool> AddNewPartyHost(PartyHostModel partyHost)
        {

            try
            {
                PartyHost acc = _mapper.Map<PartyHost>(partyHost);
                return await _repo.AddNewPartyHost(acc);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> DeletePartyHost(int id)
        {

            try
            {
                return await _repo.DeletePartyHost(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<PartyHostModel> GetPartyHostById(int id)
        {
            try
            {
                PartyHost partyHost = await _repo.GetPartyHostById(id);
                return _mapper.Map<PartyHostModel>(partyHost);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new PartyHostModel();


        }

        public async Task<bool> UpdatePartyHost(PartyHostModel partyHost)
        {

            try
            {
                PartyHost acc = _mapper.Map<PartyHost>(partyHost);
                return await _repo.UpdatePartyHost(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }
    }
}
