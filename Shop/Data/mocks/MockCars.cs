using System.Collections.Generic;
using System.Linq;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla", 
                        shortDesc = "Быстрый автомобиль", 
                        logDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla", 
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavourite = true,
                        available = true, 
                        Category = _categoryCars.allCategories.First()
                    },
                    new Car
                    {
                        name = "BMW M3", 
                        shortDesc = "Дерзкий и стильный", 
                        logDesc = "Удобный автомобиль для городской жизни", 
                        img = "/img/bmwm3.jpg", 
                        price = 65000, 
                        isFavourite = true,
                        available = true, 
                        Category = _categoryCars.allCategories.Last()
                    }
                };
            }
        }

        public IEnumerable<Car> getFavCars { get; set; }
        
        public Car getObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}