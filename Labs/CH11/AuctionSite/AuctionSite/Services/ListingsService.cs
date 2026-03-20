using AuctionSite.Data;
using AuctionSite.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionSite.Services
{
    public class ListingsService(ApplicationDbContext context) : IListingsService
    {
        public async Task Add(Listing listing)
        {
            context.Listings.Add(listing);
            await context.SaveChangesAsync();
        }

        public IQueryable<Listing> GetAll()
        {
            var allListings = context.Listings.Include(l => l.User);
            return allListings;
        }

        public async Task<Listing> GetById(int? id)
        {
            var listing = await context.Listings
                .Include(l => l.User)
                .Include(l => l.Comments)
                .ThenInclude(c => c.User)
                .Include(l => l.Bids)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync(l => l.ListingId == id);
            return listing;
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
