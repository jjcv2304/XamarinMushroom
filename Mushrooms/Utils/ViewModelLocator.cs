﻿using System;
using System.Collections.Generic;
using System.Text;
using Mushrooms.ViewModels;

namespace Mushrooms.Utils
{
  internal static class ViewModelLocator
  {

    internal static LibraryVM LibraryVM { get; set; } = new LibraryVM();
  }
}
