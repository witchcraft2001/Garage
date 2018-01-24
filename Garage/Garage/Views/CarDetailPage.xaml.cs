
using Garage.ViewModels;

using Xamarin.Forms;

namespace Garage.Views
{
    public partial class CarDetailPage : ContentPage
    {
        CarDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CarDetailPage()
        {
            InitializeComponent();
        }

        public CarDetailPage(CarDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
