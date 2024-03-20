using AutoMapper;
using BusinessObjects.Models;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class PartyPostService : IPartyPostService
    {
        private readonly IPartyPostRepository _repo;
        private readonly IMapper _mapper;

        public PartyPostService(IPartyPostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<bool> AddNewPartyPost(PartyPostModel partyPost)
        {

            try
            {
                PartyPost acc = _mapper.Map<PartyPost>(partyPost);
                return await _repo.AddNewPartyPost(acc);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> DeletePartyPost(int id)
        {

            try
            {
                return await _repo.DeletePartyPost(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<PartyPostModel> GetPartyPostById(int id)
        {
            try
            {
                PartyPost partyPost = await _repo.GetPartyPostById(id);
                return _mapper.Map<PartyPostModel>(partyPost);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new PartyPostModel();


        }

        public async Task<bool> UpdatePartyPost(PartyPostModel partyPost)
        {

            try
            {
                PartyPost acc = _mapper.Map<PartyPost>(partyPost);
                return await _repo.UpdatePartyPost(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }
    }
}
