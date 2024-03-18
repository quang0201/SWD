using BusinessObjects.Models;

namespace Reponsitories.Interface
{
    public interface IFeedbackRepository
    {
        Task<Feedback> GetFeedbackModelById(int id);
        Task<bool> AddNewFeedbackModel(Feedback feedback);
        Task<bool> DeleteFeedbackModel(int id);
        Task<bool> UpdateFeedbackModel(Feedback feedback);
    }
}
