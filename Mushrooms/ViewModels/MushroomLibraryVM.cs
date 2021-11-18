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
    private IMushroomDataService _mushroomDataService;
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
    public ICommand MushroomSelectedCommand { get; }
    public ICommand AddMushroomCommand { get; }
    public ICommand DeleteMushroomCommand { get; }
    public ICommand UpdateMushroomCommand { get; }

    public MushroomLibraryVM(IMushroomDataService mushroomDataService)
    {
      _mushroomDataService = mushroomDataService;

      AddMushroomCommand = new Command(OnAddMushroomCommand);
      DeleteMushroomCommand = new Command<Mushroom>(OnDeleteMushroomCommand);
      UpdateMushroomCommand = new Command<Mushroom>(OnUpdateMushroomCommand);
      MushroomSelectedCommand = new Command<Mushroom>(OnMushroomSelectedCommand);

      MushroomList = new ObservableCollection<Mushroom>();
    }

    public async Task OnAppearing()
    {
      //IsBusy = true;
      //todo verify is ok to return void for delegates?
      MushroomList = new ObservableCollection<Mushroom>(await _mushroomDataService.GetAsync());
    }


    private async void OnMushroomSelectedCommand(Mushroom mushroom)
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomDetailPage)}?Id={mushroom.Id}");
    }

    private async void OnAddMushroomCommand()
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }

    private async void OnDeleteMushroomCommand(Mushroom mushroom)
    {
      //todo add confirmation dialog
      await _mushroomDataService.DeleteAsync(mushroom);

      // await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }
    private async void OnUpdateMushroomCommand(Mushroom mushroom)
    {
      //await _mushroomDataService.UpdateAsync(mushroom.Id.ToString());

      // await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }

    //private void OnPieChanged(PieDetailViewModel sender, Pie pie)
    //{
    //  //Pies = new ObservableCollection<Pie>(PieRepository.Pies);
    //  //Pies = new ObservableCollection<Pie>(App.PieDataServie.GetAllPies());
    //  Pies = new ObservableCollection<Pie>(_pieDataService.GetAllPies());
    //}
  }
}