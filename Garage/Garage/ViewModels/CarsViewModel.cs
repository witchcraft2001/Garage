using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Garage.Helpers;
using Garage.Models;
using Garage.Views;

using Xamarin.Forms;
using Garage.Services;

namespace Garage.ViewModels
{
    public class CarsViewModel : BaseViewModel
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Car> DataStore => DependencyService.Get<IDataStore<Car>>();

        public ObservableRangeCollection<Car> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CarsViewModel()
        {
            Title = "Гараж";
            Items = new ObservableRangeCollection<Car>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCarsCommand());

            MessagingCenter.Subscribe<EditCarPage, Car>(this, "AddCar", async (obj, item) =>
            {
                var _item = item as Car;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadCarsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}