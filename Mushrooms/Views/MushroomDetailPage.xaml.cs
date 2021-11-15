using Mushrooms.Utils;
using Xamarin.Forms;

namespace Mushrooms.Views
{
  //[QueryProperty(nameof(Id), "Id")]
  public partial class MushroomDetailPage : ContentPage
  {
    //public string Id
    //{
    //  set
    //  {
    //    LoadAnimal(value);
    //  }
    //}

    public MushroomDetailPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.MushroomDetailVM;
    }
  }
}