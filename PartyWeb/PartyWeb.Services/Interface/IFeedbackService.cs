using ModelViews.ModelView;

namespace Services.Interface
{
    public interface IFeedbackService
    {
        Task<FeedbackModel> GetFeedbackModelById(int id);
        Task<bool> AddNewFeedbackModel(FeedbackModel feedback);
        Task<bool> DeleteFeedbackModel(int id);
        Task<bool> UpdateFeedbackModel(FeedbackModel feedback);
    }
}
