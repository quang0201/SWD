using BusinessObjects.Models;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task<bool> AddNewFeedbackModel(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeedbackModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetFeedbackModelById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFeedbackModel(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
