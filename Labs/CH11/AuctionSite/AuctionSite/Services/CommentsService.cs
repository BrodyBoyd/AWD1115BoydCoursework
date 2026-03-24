using AuctionSite.Data;
using AuctionSite.Models;

namespace AuctionSite.Services
{
    public class CommentsService(ApplicationDbContext context) : ICommentsService
    {
        public async Task Add(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
        }
    }
}
