using Mushrooms.ViewModels;

namespace Mushrooms.Utils
{
  public static class ViewModelLocator
  {

    //public static PieDetailViewModel PieDetailViewModel { get; set; } = new PieDetailViewModel(App.PieDataServie, App.NavigationService);

    internal static AboutVM AboutVM { get; set; } = new AboutVM();
    internal static ExportDataVM ExportDataVM { get; set; } = new ExportDataVM(App.MushroomDataService);

    internal static IdentifyMushroomVM IdentifyMushroomVM { get; set; } = new IdentifyMushroomVM();

    internal static ImportDataVM ImportDataVM { get; set; } = new ImportDataVM();

    internal static MushroomDetailVM MushroomDetailVM { get; set; } = new MushroomDetailVM();

    internal static MushroomDiaryVM MushroomDiaryVM { get; set; } = new MushroomDiaryVM();

    internal static MushroomLibraryVM MushroomLibraryVM { get; set; } = new MushroomLibraryVM(App.MushroomDataService);
    
    internal static NewMushroomVM NewMushroomVM { get; set; } = new NewMushroomVM();
  }
}
