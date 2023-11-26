using eTicket.DataAccess.Services.IRepositories;
using eTicket.DataAccess.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCart.ShoppingCartId = HttpContext.Session.GetString("CartId");
            var items = _shoppingCart.GetShoppingCartItems().Count();

            return View(items);
        }
    }
}
