using System.ComponentModel.DataAnnotations;

namespace Projectwebapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}
