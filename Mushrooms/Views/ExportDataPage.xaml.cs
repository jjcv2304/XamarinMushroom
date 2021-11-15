using Mushrooms.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ExportDataPage : ContentPage
  {
    public ExportDataPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.ExportDataVM; ;
    }
  }
}