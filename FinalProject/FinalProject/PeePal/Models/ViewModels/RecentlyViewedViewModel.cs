using System.Collections.Generic;
using PeePal.Models.DTOs;

namespace PeePal.Models.ViewModels
{
    public class RecentlyViewedViewModel
    {
        public List<RecentBathroomDTO> RecentlySeenBathrooms { get; set; } = new List<RecentBathroomDTO>();
    }
}
