using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using Microsoft.AspNetCore.Http;

namespace eTicket.Models
{
    public class CreateMovieVM
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
        public double Price { get; set; }
        [MaxLength(250)]
        public string ImageURL { get; set; }
        public Genre Genre { get; set; }
        public int CinemaID { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CinemaList { get; set; } = Enumerable.Empty<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public int ProducerID { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ProducerList { get; set; } = Enumerable.Empty<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public List<int> ActorId { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Actors { get; set; } = Enumerable.Empty<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
    }
}
