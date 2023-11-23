using eTicket.DataAccess.Services.Repositories;
using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;
using eTicket.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.Graph.Models.CallRecords;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult ShoppingCart()
        {
            var cartItems = unitOfWork.ShoppingCart.GetShoppingCartItems();
            return View(cartItems);
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var movie = unitOfWork.Movie.GetMovieById(id);
            if(movie != null)
            {
                unitOfWork.ShoppingCart.AddItemtoCart(movie);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public IActionResult TestSession()
        {
            //HttpContext.Session.SetString("TestKey", "TestValue");
            //var testValue = HttpContext.Session.GetString("TestKey");
            string cartId = HttpContext.Session.GetString("CartId") ?? Guid.NewGuid().ToString();
            HttpContext.Session.SetString("CartId", cartId);
            var id = HttpContext.Session.GetString("CartId");
            return Content($"TestValue: {id}");
        }
    }
}
