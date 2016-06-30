using System.Linq;

using Xamarin.Forms;

using XLabs.Forms.Controls;

namespace PickerSample {
    public partial class MainView : ContentPage {
        public MainView() {
            // ExtendedPicker picker = new ExtendedPicker(); // Workaround if error: System.IO.FileNotFoundException: Could not load file or assembly 'XLabs.Forms' or one of its dependencies

            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            var viewModel = new MainViewModel();
            viewModel.HealthyFoodCategories.Add(new FoodCategory { Id = 1, Name = "Fruits" });
            viewModel.HealthyFoodCategories.Add(new FoodCategory { Id = 2, Name = "Vegetables" });
            viewModel.SelectedCategory = viewModel.HealthyFoodCategories.First(); // Comment out this line, and the second picker will stay empty
            BindingContext = viewModel;
        }
    }
}