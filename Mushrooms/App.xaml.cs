using Mushrooms.Services;
using Xamarin.Forms;

namespace Mushrooms
{
  public partial class App : Application
  {

    public static MushroomDataService MushroomDataService { get; } = new MushroomDataService();
    public static MessageBoxService MessageBoxService { get; } = new MessageBoxService();

    public App()
    {
      InitializeComponent();

      //DependencyService.Register<MockMushroomDataStore>();
    MainPage = new AppShell();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
