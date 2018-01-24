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

            BindingContext = viewModel = new CarsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Car;
            if (item == null)
                return;

            await Navigation.PushAsync(new CarDetailPage(new CarDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
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
