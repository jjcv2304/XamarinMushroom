using System;
using System.Collections.Generic;
using System.Text;
using Mushrooms.Services;

namespace Mushrooms.ViewModels
{
  internal class MushroomLibraryVM
  {
    private MushroomDataService _mushroomDataService;

    public MushroomLibraryVM(MushroomDataService mushroomDataService)
    {
      _mushroomDataService = mushroomDataService;
    }
  }
}
