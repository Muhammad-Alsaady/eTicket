using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class ActorDetailsVM
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [MaxLength(250)]
        [Display(Name = "Profile Picture")]
        public string ProfilePhotoURL { get; set; }
        [MaxLength(2500)]
        public string Bio { get; set; }
        public List<string> Movies { get; set; } = new List<string>();
    }
}
