using Mushrooms.Utils;
using Xamarin.Forms;

namespace Mushrooms.Views
{
  public partial class MushroomEditPage : ContentPage
  {

    public MushroomEditPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.MushroomEditVM; ;
    }
  }
}