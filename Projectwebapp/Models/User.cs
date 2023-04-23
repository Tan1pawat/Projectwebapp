using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projectwebapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="กรุณาใส่ข้อมูล")]
        [RegularExpression(@"^64010462$|^6401047[5-6]$|^64010479$|^6401051[2-689]$|^640105[1-9][1-9]$|^6401060[5-6]$|^64010609$|^6401062[7-9]$|^640107[1-9][0-9]$|^6401080[1-68]$|^64010813$|^6401081[5-8]$|^6401082[3-4]$|^64010827$|^6401084[25]|^64010846$|^6401085[0-9]$",ErrorMessage = "ไม่มี Student ID นี้ใน sec19")]
        public int Secid { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [MaxLength(50)]
        public string Pass { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Compare("Password", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
        public string ConfirmPassword { get; set; }
    }
}