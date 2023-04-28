using System.ComponentModel.DataAnnotations;

namespace Projectwebapp.Models
{
    public class Sender
    {

        [Key]
        public int OrderID { get; set; } = 0;

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string FoodStore { get; set; } = string.Empty;
        [Required]
        public string FoodMenu_Option { get; set; } = string.Empty;
        [Required]
        public string RecipientName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string RecipientAddress { get; set; } = string.Empty;
    }
}