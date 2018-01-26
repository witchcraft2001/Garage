using System;

using Garage.Models;
using Garage.ViewModels;

using Xamarin.Forms;

namespace Garage.Views
{
    public partial class CarsPage : ContentPage
    {
        CarsViewModel viewModel;

        public CarsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CarsViewModel(this);
        }


        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCarPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
