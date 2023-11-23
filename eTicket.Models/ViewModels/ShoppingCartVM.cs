using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public List<CartItemVM> CartItems { get; set; }
        public double CartItemTotal { get; set; }
    }
}
