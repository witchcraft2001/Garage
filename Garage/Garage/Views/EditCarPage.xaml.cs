using System;

using Garage.Models;
using Garage.ViewModels;
using Xamarin.Forms;

namespace Garage.Views
{
    public partial class EditCarPage : ContentPage, IEditCarPage
    {
        public EditCarPage()
            :this(new Car { Name = "Название", Description = "Описание", Year = DateTime.Now.Year })
        {
        }

        public EditCarPage(Car item)
        {
            InitializeComponent();
            
            BindingContext = new EditCarViewModel(this, item);
        }

        async void IEditCarPage.CloseView()
        {
            await Navigation.PopToRootAsync();
        }        
    }
}