using Mushrooms.Services;
using Mushrooms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms
{
  public partial class App : Application
  {

    public static MushroomDataService MushroomDataService { get; } = new MushroomDataService();

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
