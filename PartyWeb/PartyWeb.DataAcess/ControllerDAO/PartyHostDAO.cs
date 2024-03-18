using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.ControllerDAO
{
    public class PartyHostDAO
    {
        private static PartyHostDAO instance = default!;
        public static PartyHostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartyHostDAO();
                }
                return instance;
            }
        }

        public async Task<PartyHost> GetPartyHostById(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyHost = await dbContext.PartyHosts.FirstOrDefaultAsync(u => u.PartyHostId == id);
                    return partyHost;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<bool> AddPartyHost(PartyHost newPartyHost)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    dbContext.PartyHosts.Add(newPartyHost);
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

        public async Task<bool> UpdatePartyHost(PartyHost newPartyHost)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyHost = await dbContext.PartyHosts.FirstOrDefaultAsync(u => u.PartyHostId == newPartyHost.PartyHostId);

                    if (partyHost != null)
                    {
                        partyHost.PartyHostTitle = newPartyHost.PartyHostTitle;
                        partyHost.PartyHostDetails = newPartyHost.PartyHostDetails;
                        partyHost.StartedTime = newPartyHost.StartedTime;
                        partyHost.EndedTime = newPartyHost.EndedTime;
                        partyHost.NumberOfPeople = newPartyHost.NumberOfPeople;
                        partyHost.CreatedBy = newPartyHost.CreatedBy;

                        dbContext.PartyHosts.Update(partyHost);
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

        public async Task<bool> DeletePartyHost(int id)
        {
            try
            {
                using (var dbContext = new SwdContext())
                {
                    var partyHost = await dbContext.PartyHosts.FirstOrDefaultAsync(u => u.PartyHostId == id);

                    if (partyHost != null)
                    {
                        dbContext.Remove(partyHost);
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
