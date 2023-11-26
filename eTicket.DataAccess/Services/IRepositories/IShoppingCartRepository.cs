using eTicket.DataAccess.Services.Repositories;
using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IShoppingCartRepository
    {
        public string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        IEnumerable<ShoppingCartItem> GetShoppingCartItems();
        void AddItemtoCart(Movie movie);
        void RemoveItemFromCart(Movie movie);
        double ShoppingCartTotal();
        Task ClearShoppingCartAsync();
    }
}
