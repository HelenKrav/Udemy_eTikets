using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _appDbContext;

        public OrderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _appDbContext.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(m => m.Movie)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order();
            order.UserId = userId;
            order.Email= userEmailAddress;

            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };

               await _appDbContext.OrderItems.AddAsync(orderitem);
            }

            await _appDbContext.SaveChangesAsync();
            
        }
    }
}
