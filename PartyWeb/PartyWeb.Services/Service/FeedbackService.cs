using AutoMapper;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;

namespace Services.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repo;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository repo, IMapper mapper)
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
