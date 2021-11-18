using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mushrooms.Models;
using Mushrooms.Services;
using Mushrooms.Views;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  internal class MushroomLibraryVM : BaseViewModel
  {
    private readonly IMushroomDataService _mushroomDataService;
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

    public MushroomLibraryVM(IMushroomDataService mushroomDataService)
    {
      _mushroomDataService = mushroomDataService;

      AddMushroomCommand = new Command(OnAddMushroomCommand);
      DeleteMushroomCommand = new Command<Mushroom>(OnDeleteMushroomCommand);
      UpdateMushroomCommand = new Command<Mushroom>(OnUpdateMushroomCommand);
      MushroomSelectedCommand = new Command<Mushroom>(OnMushroomSelectedCommand);

      _mushroomList = new ObservableCollection<Mushroom>();
    }

    public async Task OnAppearing()
    {
      //IsBusy = true;
      //todo verify is ok to return void for delegates?
      MushroomList = new ObservableCollection<Mushroom>(await _mushroomDataService.GetAsync());
    }

    public ICommand MushroomSelectedCommand { get; }
    private async void OnMushroomSelectedCommand(Mushroom mushroom)
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomDetailPage)}?Id={mushroom.Id}");
    }

    public ICommand AddMushroomCommand { get; }
    private async void OnAddMushroomCommand()
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }

    public ICommand DeleteMushroomCommand { get; }
    private async void OnDeleteMushroomCommand(Mushroom mushroom)
    {
      //todo add confirmation dialog
      await _mushroomDataService.DeleteAsync(mushroom);

      // await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }
    
    public ICommand UpdateMushroomCommand { get; }
    private async void OnUpdateMushroomCommand(Mushroom mushroom)
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}?Id={mushroom.Id}");
    }

    //private void OnPieChanged(PieDetailViewModel sender, Pie pie)
    //{
    //  //Pies = new ObservableCollection<Pie>(PieRepository.Pies);
    //  //Pies = new ObservableCollection<Pie>(App.PieDataServie.GetAllPies());
    //  Pies = new ObservableCollection<Pie>(_pieDataService.GetAllPies());
    //}
  }
}