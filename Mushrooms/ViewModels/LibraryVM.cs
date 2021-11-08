using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Mushrooms.Data;
using Mushrooms.Models;

namespace Mushrooms.ViewModels
{
  internal class LibraryVM: BaseViewModel
  {
    private readonly IMushroomsRepository _repository;

    internal ObservableCollection<Mushroom> _mushrooms;

    public ObservableCollection<Mushroom> Mushrooms
    {
      get => _mushrooms;
      set
      {
        _mushrooms = value;
        OnPropertyChanged("Mushrooms");
      }
    }

    internal LibraryVM(IMushroomsRepository repository)
    {
      _repository = repository;
    }
  }
}
