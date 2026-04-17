namespace PeePal.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalBathrooms { get; set; }
        public int TotalReviews { get; set; }
        public double AverageReviewsPerBathroom { get; set; }

        public List<ZipCodeStats> PopularZipCodes { get; set; }
        public ReviewerStats MostActiveReviewer { get; set; }

        // Charts
        public List<string> ReviewMonths { get; set; } = new();
        public List<int> ReviewCountsByMonth { get; set; } = new();

        public List<string> PopularZipLabels { get; set; } = new();
        public List<int> PopularZipReviewCounts { get; set; } = new();
    }

    public class ZipCodeStats
    {
        public string ZipCode { get; set; }
        public int ReviewCount { get; set; }
    }

    public class ReviewerStats
    {
        public string UserName { get; set; }
        public int ReviewCount { get; set; }
    }


}
