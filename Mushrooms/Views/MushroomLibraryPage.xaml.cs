using Mushrooms.Utils;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MushroomLibraryPage : ContentPage
  {
    private MushroomLibraryVM _mushroomLibraryVM;
    public MushroomLibraryPage()
    {
      InitializeComponent();
      _mushroomLibraryVM = ViewModelLocator.MushroomLibraryVM;
      this.BindingContext = _mushroomLibraryVM;
    }
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      await _mushroomLibraryVM.OnAppearing();
    }
    //todo to add busy parameter?
  }
}