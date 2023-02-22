using System.Collections;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string currCategory { get; set; }
    }
}