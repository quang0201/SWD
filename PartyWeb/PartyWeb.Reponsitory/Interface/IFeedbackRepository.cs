using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IFeedbackRepository
    {
        Task<Feedback> GetFeedbackById(int id);
        Task<bool> AddNewFeedback(Feedback feedback);
        Task<bool> DeleteFeedback(int id);
        Task<bool> UpdateFeedback(Feedback feedback);
    }
}
