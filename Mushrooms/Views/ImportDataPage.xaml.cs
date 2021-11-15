using Mushrooms.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ImportDataPage : ContentPage
  {
    public ImportDataPage()
    {
      InitializeComponent();
      this.BindingContext = ViewModelLocator.ImportDataVM; ;
    }
  }
}