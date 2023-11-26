using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IOrderRepository
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task <List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
