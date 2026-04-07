using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models.DomainModels
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames {  get; set; }
     }
}
