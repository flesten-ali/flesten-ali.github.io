using Microsoft.AspNetCore.Identity;

namespace MCV.net.Models
{
    public class ApplicationUser:IdentityUser
    {

         public List<Project> projects { get; set; }
    }
}
