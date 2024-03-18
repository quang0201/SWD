using AutoMapper;
using BusinessObjects.Models;
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

        public async Task<bool> AddNewFeedback(FeedbackModel feedback)
        {

            try
            {
                Feedback acc = _mapper.Map<Feedback>(feedback);
                return await _repo.AddNewFeedback(acc);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<bool> DeleteFeedback(int id)
        {

            try
            {
                return await _repo.DeleteFeedback(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }

        public async Task<FeedbackModel> GetFeedbackById(int id)
        {
            try
            {
                Feedback feedback = await _repo.GetFeedbackById(id);
                return _mapper.Map<FeedbackModel>(feedback);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new FeedbackModel();


        }

        public async Task<bool> UpdateFeedback(FeedbackModel feedback)
        {

            try
            {
                Feedback acc = _mapper.Map<Feedback>(feedback);
                return await _repo.UpdateFeedback(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return false;
            }
        }
    }
}
