using Microsoft.AspNetCore.Mvc;
using ShoppingCartLab.Extensions;
using ShoppingCartLab.Models;

using ShoppingCartLab.ViewModels;

namespace ShoppingCartLab.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.GetObject<CartViewModel>("ShoppingCart");
            int itemCount = cart?.ItemCount ?? 0;
            return View(itemCount);
        }
    }
}
