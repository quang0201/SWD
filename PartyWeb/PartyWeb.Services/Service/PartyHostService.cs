using AutoMapper;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class PartyHostService : IFeedbackService
    {
        private readonly IPartyHostRepository _repo;
        private readonly IMapper _mapper;

        public PartyHostService(IPartyHostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public Task<bool> AddNewFeedbackModel(FeedbackModel feedback)
        {

            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        public Task<bool> DeleteFeedbackModel(int id)
        {

            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        public Task<FeedbackModel> GetFeedbackModelById(int id)
        {

            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }

        public Task<bool> UpdateFeedbackModel(FeedbackModel feedback)
        {

            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }
    }
}
