using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Garage.Helpers;
using Garage.Models;
using Garage.Views;

using Xamarin.Forms;
using Garage.Services;
using Garage.DB;
using System.Collections.ObjectModel;

namespace Garage.ViewModels
{
    public class CarsViewModel : BaseViewModel
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        private DbContext db = new DbContext();

        private ObservableCollection<Car> items;

        private Car selectedItem;

        private CarsPage view;

        public ObservableCollection<Car> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ObservableCollection<Car>();
                }
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public Car SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public Command LoadItemsCommand { get; set; }
        public Command EditCarCommand { get; set; }
        public Command DetailCarCommand { get; set; }

        public CarsViewModel(CarsPage view)
        {
            this.view = view;
            Title = "Гараж";
            Items = new ObservableCollection<Car>();
            ExecuteLoadCarsCommand();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCarsCommand());
            DetailCarCommand = new Command<Car>(c => DoDetailCarCommand(c));
            EditCarCommand = new Command<Car>(c => DoEditCar(c));

            MessagingCenter.Subscribe<EditCarViewModel, Car>(this, "EditCar", async (obj, item) =>
            {
                var car = item as Car;
                db.SaveCar(car);
                await ExecuteLoadCarsCommand();
            });
        }

        private async void DoDetailCarCommand(Car item)
        {
            await view.Navigation.PushAsync(new CarDetailPage(new CarDetailViewModel(item)));
            SelectedItem = null;
        }

        private async void DoEditCar(Car item)
        {
            await view.Navigation.PushAsync(new EditCarPage(item));
            SelectedItem = null;
        }

        async Task ExecuteLoadCarsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await Task.Run(() => db.GetCars()).ConfigureAwait(false);
                Items = new ObservableCollection<Car>(items);
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