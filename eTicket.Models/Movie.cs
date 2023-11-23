using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public  double Price { get; set; }
        [MaxLength(250)]
        public string ImageURL { get; set; }
        public Genre Genre { get; set; }

        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } = new HashSet<MovieActor>();
    }
}
