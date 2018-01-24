﻿using Garage.Models;

namespace Garage.ViewModels
{
    public class CarDetailViewModel : BaseViewModel
    {
        public Car Item { get; set; }
        public CarDetailViewModel(Car item = null)
        {
            Title = item.Name;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}