using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Shop.Data.Interfaces;
using Shop.Data.Repository;
using Shop.Data.Models;
using ShopCart = Shop.Data.Models.ShopCart;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private  IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel() { ShopCart = _shopCart };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(string idCart, int idCar)
        {
            _shopCart.DeleteCart(idCart, idCar);
            return RedirectToAction("Index");
        }
        
        public IActionResult GoBackToIndex()
        {
            return RedirectToAction("Index");
        }
    }
}