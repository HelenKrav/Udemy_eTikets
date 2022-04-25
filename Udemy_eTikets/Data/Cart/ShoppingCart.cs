using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public string ShoppingCartId { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }



        //
        public static ShoppingCart GetShoppingCart(IServiceProvider services)   // IServiceProvider - Определяет механизм получения сервисного объекта; то есть объекта, который обеспечивает пользовательскую поддержку других объектов.
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;  //хранит данные пользователя, пока тот просматривает веб-приложение. Состояние сеанса использует хранилище, поддерживаемое приложением, для сохранения данных во время запросов от клиента. Данные сессии поддерживаются кэшем и считаются эфемерными данными.
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }


        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                    .FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem();
                shoppingCartItem.ShoppingCartId = ShoppingCartId;
                shoppingCartItem.Movie = movie;
                shoppingCartItem.Amount = 1;

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();           

        }


        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                   .FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                } 
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                                                               .Where(n=>n.ShoppingCartId == ShoppingCartId)
                                                               .Include(m=>m.Movie)
                                                               .ToList());
        }


        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(n=>n.ShoppingCartId == ShoppingCartId)
                .Select(n=>n.Movie.Price * n.Amount)
                .Sum();

            return total;
        }

    }
}
