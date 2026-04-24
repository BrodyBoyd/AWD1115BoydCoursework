using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PeePal.Models
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public List<Review> Reviews {  get; set; } = new();
        public List<Bathroom> Favorites { get; set; } = new();

        public string? FullName { get; set; }
        public string? ProfileUsername { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
