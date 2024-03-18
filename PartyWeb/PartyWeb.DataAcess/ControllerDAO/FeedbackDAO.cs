using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.ControllerDAO
{
    public class FeedbackDAO
    {
        private static FeedbackDAO instance = default!;
        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackDAO();
                }
                return instance;
            }
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var feedback = await dbContext.Feedbacks.FirstOrDefaultAsync(u => u.FeedbackId == id);
                    return feedback;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<bool> AddFeedback(Feedback newFeedback)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    dbContext.Feedbacks.Add(newFeedback);
                    if (await dbContext.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.ToString());
            }
        }

        public async Task<bool> UpdateFeedback(Feedback newFeedback)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var feedback = await dbContext.Feedbacks.FirstOrDefaultAsync(u => u.FeedbackId == newFeedback.FeedbackId);

                    if (feedback != null)
                    {
                        feedback.Stars = newFeedback.Stars;
                        feedback.Content = newFeedback.Content;
                        feedback.CreatedDate = newFeedback.CreatedDate;
                        feedback.CreatedBy = newFeedback.CreatedBy;

                        dbContext.Feedbacks.Update(feedback);
                        if (dbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.ToString());
            }
        }

        public async Task<bool> DeleteFeedback(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var feedback = await dbContext.Feedbacks.FirstOrDefaultAsync(u => u.FeedbackId == id);

                    if (feedback != null)
                    {
                        dbContext.Remove(feedback);
                        if (dbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.ToString());
            }
        }

    }
}
