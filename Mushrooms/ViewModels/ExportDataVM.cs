using System;
using System.Collections.Generic;
using System.Text;
using Mushrooms.Services;

namespace Mushrooms.ViewModels
{

  internal class ExportDataVM
  {
    private MushroomDataService _mushroomDataService;

    public ExportDataVM(MushroomDataService mushroomDataService)
    {
      this._mushroomDataService = mushroomDataService;
    }
  }
}
