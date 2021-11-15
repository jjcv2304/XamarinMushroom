using Mushrooms.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MushroomDiaryPage : ContentPage
  {
    public MushroomDiaryPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.MushroomDiaryVM;
    }
  }
}