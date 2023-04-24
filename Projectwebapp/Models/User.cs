using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projectwebapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="กรุณาใส่ข้อมูล")]
        [RegularExpression(@"^64010462$|^6401047[5-6]$|^64010479$|^64010512$|^64010516$|^6401051[8-9]$|^64010522$|^64010526$|^64010529$|^64010543$|^64010546$|^64010552$|^6401057[4-5]$|^64010591$|^64010597$|^64010599$|^6401060[5-6]$|
        ^64010609$|^64010627$|^64010633$|^64010635$|^64010646$|^64010659$|^64010670$|^64010681$|^64010683$|^64010718$|^64010720$|^64010724$|^64010726$|^64010736$|^64010745$|^64010755$|^64010757$|^64010759$|^64010761$|^64010765$|^64010790$|
        ^64010792$|^64010801$|^64010806$|^64010808$|^64010813$|^64010815$|^64010818$|^6401082[3-4]$|^64010827$|^64010842$|^6401084[5-6]$|^64010850$|^64010860$", ErrorMessage = "ไม่มี Student ID นี้ใน sec19")]
        public string Secid { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [MaxLength(50)]
        public string Pass { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ข้อมูล")]
        [Compare("Pass", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
        public string ConfirmPassword { get; set; }
    }
}