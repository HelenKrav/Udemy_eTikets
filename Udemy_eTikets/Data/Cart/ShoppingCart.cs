using Microsoft.EntityFrameworkCore;
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

        public void AddItemCart(Movie movie)
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


        public void DeletItemCart(Movie movie)
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


        public double GetShoppingCartItem()
        {
            var total = _context.ShoppingCartItems
                .Where(n=>n.ShoppingCartId == ShoppingCartId)
                .Select(n=>n.Movie.Price * n.Amount)
                .Sum();

            return total;
        }

    }
}
