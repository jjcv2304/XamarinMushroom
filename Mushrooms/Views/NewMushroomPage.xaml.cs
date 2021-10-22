using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.Models;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  public partial class NewMushroomPage : ContentPage
  {
    private NewMushroomVM _newMushroomVM;

    public NewMushroomPage()
    {
      InitializeComponent();
      BindingContext = _newMushroomVM = new NewMushroomVM();
    }
  }
}