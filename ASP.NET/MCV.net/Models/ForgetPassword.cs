using System.ComponentModel.DataAnnotations;

namespace MCV.net.Models
{
    public class ForgetPassword
    {


        [Key]
        [Required,EmailAddress, Display(Name ="Registred  Email adress")]  
        public string Email { get; set; }
        public bool isEmailSent { get; set; }
 

    }
}
