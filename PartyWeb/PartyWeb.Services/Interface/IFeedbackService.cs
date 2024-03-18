using ModelViews.ModelView;

namespace Services.Interface
{
    public interface IFeedbackService
    {
        Task<FeedbackModel> GetFeedbackById(int id);
        Task<bool> AddNewFeedback(FeedbackModel feedback);
        Task<bool> DeleteFeedback(int id);
        Task<bool> UpdateFeedback(FeedbackModel feedback);
    }
}
