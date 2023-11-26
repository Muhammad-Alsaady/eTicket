using eTicket.DataAccess.Services.Repositories;
using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;
using eTicket.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.Graph.Models.CallRecords;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContext;
        public OrderController(IUnitOfWork unitOfWork, IHttpContextAccessor context)
        {
            this.unitOfWork = unitOfWork;
            this.httpContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders =  await unitOfWork.Order.GetOrdersByUserIdAsync(""); // No User Id yet
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            unitOfWork.ShoppingCart.ShoppingCartId = HttpContext.Session.GetString("CartId");
            var cartItems = unitOfWork.ShoppingCart.GetShoppingCartItems();
            unitOfWork.ShoppingCart.ShoppingCartItems = cartItems.ToList();
            return View(unitOfWork.ShoppingCart.ShoppingCartItems);
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var movie = unitOfWork.Movie.GetMovieById(id);
            if(movie != null)
            {
                unitOfWork.ShoppingCart.ShoppingCartId = HttpContext.Session.GetString("CartId");
                unitOfWork.ShoppingCart.AddItemtoCart(movie);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var movie = unitOfWork.Movie.GetMovieById(id);
            if (movie != null)
            {
                unitOfWork.ShoppingCart.ShoppingCartId = HttpContext.Session.GetString("CartId");
                unitOfWork.ShoppingCart.RemoveItemFromCart(movie);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            unitOfWork.ShoppingCart.ShoppingCartId = HttpContext.Session.GetString("CartId");
            var items = unitOfWork.ShoppingCart.GetShoppingCartItems().ToList();
            string userId = "", email = "";
            await unitOfWork.Order.StoreOrderAsync(items, userId, email);
            await unitOfWork.ShoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");

        }

        //public IActionResult TestSession()
        //{
        //    //HttpContext.Session.SetString("TestKey", "TestValue");
        //    //var testValue = HttpContext.Session.GetString("TestKey");
        //    string cartId = HttpContext.Session.GetString("CartId") ?? Guid.NewGuid().ToString();
        //    HttpContext.Session.SetString("CartId", cartId);
        //    var id = HttpContext.Session.GetString("CartId");
        //    return Content($"TestValue: {id}");
        //}
    }
}
