using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.ControllerDAO
{
    public class PartyPostDAO
    {
        private static PartyPostDAO instance = default!;
        public static PartyPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartyPostDAO();
                }
                return instance;
            }
        }

        public async Task<PartyPost> GetPartyPostById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyPost = await dbContext.PartyPosts.FirstOrDefaultAsync(u => u.PartyPostId == id);
                    return partyPost;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<bool> AddPartyPost(PartyPost newPartyPost)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    dbContext.PartyPosts.Add(newPartyPost);
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

        public async Task<bool> UpdatePartyPost(PartyPost newPartyPost)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyPost = await dbContext.PartyPosts.FirstOrDefaultAsync(u => u.PartyPostId == newPartyPost.PartyPostId);

                    if (partyPost != null)
                    {
                        partyPost.PartyPostTitle = newPartyPost.PartyPostTitle;
                        partyPost.PartyPostDetails = newPartyPost.PartyPostDetails;
                        partyPost.CreatedTime = newPartyPost.CreatedTime;
                        partyPost.CreatedBy = newPartyPost.CreatedBy;

                        dbContext.PartyPosts.Update(partyPost);
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

        public async Task<bool> DeletePartyPost(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyPost = await dbContext.PartyPosts.FirstOrDefaultAsync(u => u.PartyPostId == id);

                    if (partyPost != null)
                    {
                        dbContext.Remove(partyPost);
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
