using System.ComponentModel.DataAnnotations;

namespace MCV.net.Models
{
    public class MusicModle
    {
         
         [Required(ErrorMessage ="This is a required field")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
