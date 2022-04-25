using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item =await _movieService.GetMovieByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
