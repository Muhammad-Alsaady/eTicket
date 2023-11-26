using eTicket.DataAccess.Services.IRepositories;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await context.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie)
                .Where(n => n.UserId == userId).ToListAsync();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmail,
            };
            await context.Orders.AddAsync(order);
            // We have to save changes here also, so that the OrderId is saved before it's been used at the next step.
            await context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    MovieId = item.Movie.Id,
                    Amount = item.Amount,
                    Price = item.Movie.Price,
                    OrderId = order.Id,
                };
                context.OrderItems.Add(orderItem);
            }
            await context.SaveChangesAsync();
        }
    }
}
