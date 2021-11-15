using Mushrooms.Utils;
using Xamarin.Forms;

namespace Mushrooms.Views
{
  public partial class AboutPage : ContentPage
  {
    public AboutPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.AboutVM; ;
    }
  }
}