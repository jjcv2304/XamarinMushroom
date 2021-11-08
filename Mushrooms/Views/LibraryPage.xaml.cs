using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MushroomLibraryPage : ContentPage
  {
    private readonly MushroomsVM _mushroomsViewModel;
    public MushroomLibraryPage()
    {
      InitializeComponent();
      BindingContext = _mushroomsViewModel = new MushroomsVM();
    }
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      _mushroomsViewModel.OnAppearing();
    }
  }
}