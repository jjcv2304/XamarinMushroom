using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.Data;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  public partial class MushroomsPage : ContentPage
  {
    private readonly MushroomsVM _mushroomsViewModel;
    public MushroomsPage()
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