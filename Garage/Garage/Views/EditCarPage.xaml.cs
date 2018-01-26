using System;

using Garage.Models;

using Xamarin.Forms;

namespace Garage.Views
{
    public partial class EditCarPage : ContentPage
    {
        public Car Item { get; set; }

        public EditCarPage()
            :this(new Car { Name = "Название", Description = "Описание", Year = DateTime.Now.Year })
        {
        }

        public EditCarPage(Car item)
        {
            InitializeComponent();

            Item = item;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditCar", Item);
            await Navigation.PopToRootAsync();
        }
    }
}