using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mushrooms.Models;
using Mushrooms.Services;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  internal class MushroomLibraryVM : BaseViewModel
  {
    private MushroomDataService _mushroomDataService;
    private ObservableCollection<Mushroom> _mushroomList;
    public ObservableCollection<Mushroom> MushroomList
    {
      get => _mushroomList;
      set
      {
        _mushroomList = value;
        OnPropertyChanged("MushroomList");
      }
    }
    public ICommand PieSelectedCommand { get; }
    public ICommand AddCommand { get; }

    public MushroomLibraryVM(MushroomDataService mushroomDataService)
    {
      _mushroomDataService = mushroomDataService;

      AddCommand = new Command(OnAddCommand);
     // PieSelectedCommand = new Command<Pie>(OnPieSelectedCommand);

      MushroomList = new ObservableCollection<Mushroom>();
    }

    public async Task OnAppearing()
    {
      //IsBusy = true;
      //todo verify is ok to return void for delegates?
      MushroomList = new ObservableCollection<Mushroom>(await _mushroomDataService.GetAsync());
    }


    private void OnMushroomSelectedCommand(Mushroom mushroom)
    {
      //  _navigationService.NavigateTo("PieDetailView", pie);
    }

    private void OnAddCommand()
    {
      //App.NavigationService.NavigateTo("PieDetailView");
      // _navigationService.NavigateTo("PieDetailView");
    }
    //private void OnPieChanged(PieDetailViewModel sender, Pie pie)
    //{
    //  //Pies = new ObservableCollection<Pie>(PieRepository.Pies);
    //  //Pies = new ObservableCollection<Pie>(App.PieDataServie.GetAllPies());
    //  Pies = new ObservableCollection<Pie>(_pieDataService.GetAllPies());
    //}
  }
}