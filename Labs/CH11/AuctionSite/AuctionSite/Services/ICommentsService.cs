using AuctionSite.Models;

namespace AuctionSite.Services
{
    public interface ICommentsService
    {
        Task Add(Comment comment);
    }
}
