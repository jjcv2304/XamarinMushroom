using Mushrooms.Utils;
using Xamarin.Forms;

namespace Mushrooms.Views
{
  public partial class NewMushroomPage : ContentPage
  {

    public NewMushroomPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.NewMushroomVM; ;
    }
  }
}