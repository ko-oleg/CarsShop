using System;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);
            //Нужно добавить сохранение в базу иначе выбивает ошибку и не сохраняет
            appDbContent.SaveChanges();
            var items = shopCart.listShopItems;
            
            foreach (var el in items)
            {
                
                var orderDeteil = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appDbContent.OrderDetail.Add(orderDeteil);
                
               
            }
          
            appDbContent.SaveChanges();
        }
    }
}