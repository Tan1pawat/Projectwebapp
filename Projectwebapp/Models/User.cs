using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projectwebapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Secid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Pass { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}