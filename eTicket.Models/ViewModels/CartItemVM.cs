
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class CartItemVM
    {
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
