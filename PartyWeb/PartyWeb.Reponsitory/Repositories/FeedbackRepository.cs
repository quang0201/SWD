using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using Reponsitories.Interface;

namespace Reponsitories.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public async Task<bool> AddNewFeedback(Feedback feedback) => await FeedbackDAO.Instance.AddFeedback(feedback);
        public async Task<bool> DeleteFeedback(int id) => await FeedbackDAO.Instance.DeleteFeedback(id);
        public async Task<Feedback> GetFeedbackById(int id) => await FeedbackDAO.Instance.GetFeedbackById(id);
        public async Task<bool> UpdateFeedback(Feedback feedback) => await FeedbackDAO.Instance.UpdateFeedback(feedback);
    }
}
