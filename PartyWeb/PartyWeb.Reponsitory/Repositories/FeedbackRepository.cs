using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task<bool> AddNewFeedback(Feedback feedback) => FeedbackDAO.Instance.AddFeedback(feedback);
        public Task<bool> DeleteFeedback(int id) => FeedbackDAO.Instance.DeleteFeedback(id);
        public Task<Feedback> GetFeedbackById(int id) => FeedbackDAO.Instance.GetFeedbackById(id);

        public Task<bool> UpdateFeedback(Feedback feedback) => FeedbackDAO.Instance.UpdateFeedback(feedback);
    }
}
