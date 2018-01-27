using Garage.Models;
using Garage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garage.ViewModels
{
    public class EditCarViewModel : BaseViewModel
    {
        private IEditCarPage view;
        private Car item;

        public Car Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }

        public Command SaveCommand { get; set; }

        public EditCarViewModel(IEditCarPage view, Car item)
        {
            this.Item = item;
            this.view = view;
            if (item.Id == 0)
            {
                Title = "Новая машина";
            }  else
            {
                Title = item.Name;
            }
            SaveCommand = new Command(c => DoSaveCommand());
        }

        private void DoSaveCommand()
        {
            MessagingCenter.Send(this, "EditCar", Item);
            view.CloseView();
        }
    }
}
