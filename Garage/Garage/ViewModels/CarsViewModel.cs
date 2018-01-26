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
        //public IDataStore<Car> DataStore => DependencyService.Get<IDataStore<Car>>();
        private DbContext db = new DbContext();

        private ObservableCollection<Car> items;

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
        public Command LoadItemsCommand { get; set; }

        public CarsViewModel()
        {
            Title = "Гараж";
            Items = new ObservableCollection<Car>();
            ExecuteLoadCarsCommand();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCarsCommand());

            MessagingCenter.Subscribe<EditCarPage, Car>(this, "EditCar", async (obj, item) =>
            {
                var car = item as Car;
                db.SaveCar(car);
                await ExecuteLoadCarsCommand();
            });
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