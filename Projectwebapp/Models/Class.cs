using System.ComponentModel.DataAnnotations;

namespace foodde.Models
{
    public class Sender
    {

        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
        public string Store { get; set; }
        public string Menu { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}