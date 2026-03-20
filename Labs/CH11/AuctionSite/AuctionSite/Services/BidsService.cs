using AuctionSite.Data;
using AuctionSite.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionSite.Services
{
    public class BidsService(ApplicationDbContext context) : IBidsService
    {
        public async Task AddBid(Bid bid)
        {
            context.Bids.Add(bid);
            await context.SaveChangesAsync();
        }

        public IQueryable<Bid> GetAll()
        {
            return context.Bids.Include(b => b.Listing).ThenInclude(b => b.User);
        }
    }
}
