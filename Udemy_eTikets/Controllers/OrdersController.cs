using Microsoft.AspNetCore.Mvc;
using Udemy_eTikets.Data.Cart;
using Udemy_eTikets.Data.Services;
using Udemy_eTikets.Data.ViewModels;

namespace Udemy_eTikets.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM();
            response.ShoppingCart = _shoppingCart;
            response.ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal();



            return View(response);
        }
    }
}
