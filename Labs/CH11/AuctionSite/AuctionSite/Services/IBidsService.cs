using AuctionSite.Models;

namespace AuctionSite.Services
{
    public interface IBidsService
    {
        Task AddBid(Bid bid);

        IQueryable<Bid> GetAll();
    }
}
