using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> allCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", desc = "Совеременный вид транспорта" },
                    new Category()
                        { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего згорания" }
                };
            }
        }
    }
}

