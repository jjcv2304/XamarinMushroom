using Mushrooms.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MushroomLibraryPage : ContentPage
  {
    public MushroomLibraryPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.MushroomLibraryVM;
    }
    //protected override async void OnAppearing()
    //{
    //  base.OnAppearing();
    //  _mushroomsViewModel.OnAppearing();
    //}
    //todo to add busy parameter?
  }
}