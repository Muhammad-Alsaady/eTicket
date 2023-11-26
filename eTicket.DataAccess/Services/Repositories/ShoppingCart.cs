using eTicket.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace eTicket.DataAccess.Services.Repositories
{
    public class ShoppingCart: IShoppingCartRepository
    {
        private readonly ApplicationDbContext context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = context.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId)
                .Include(m => m.Movie).ToList());
        }

        public void AddItemtoCart(Movie movie)
        {
            var shoppingCartItem = context.ShoppingCartItems.FirstOrDefault(m => m.Movie.Id == movie.Id && m.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else shoppingCartItem.Amount++;
            context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = context.ShoppingCartItems.FirstOrDefault(m => m.Movie.Id == movie.Id && m.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                    shoppingCartItem.Amount--;
                else
                    context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            context.SaveChanges();
        }

        public double ShoppingCartTotal()
        {
            return context.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Select(m => m.Movie.Price * m.Amount).Sum();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await context.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).ToListAsync();
            context.ShoppingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}
