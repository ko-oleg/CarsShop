using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Category.Any()) content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla", 
                        shortDesc = "Быстрый автомобиль", 
                        logDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla", 
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavourite = true,
                        available = true, 
                        Category = Categories["Электромобили"]
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
                        Category = Categories["Классические автомобили"]
                    });
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", desc = "Совеременный вид транспорта" },
                        new Category
                        {
                            categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего згорания"
                        }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list) category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}