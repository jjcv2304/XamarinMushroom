using System.Collections.Generic;
using System.Threading.Tasks;
using Mushrooms.Models;
using SQLite;

namespace Mushrooms.Data
{
  public class MushroomsRepository
  {
    private static SQLiteAsyncConnection _database = null!;

    public static readonly AsyncLazy<MushroomsRepository> Instance = new AsyncLazy<MushroomsRepository>(async () =>
    {
      var instance = new MushroomsRepository();
    //  var result = await _database.CreateTableAsync<Mushroom>();
      return instance;
    });

    public MushroomsRepository()
    {
      _database = new SQLiteAsyncConnection(DataConstants.DatabasePath, DataConstants.Flags);
    }

    public Task<List<Mushroom>> GetMushroomsAsync()
    {
      return _database.Table<Mushroom>().ToListAsync();
    }

    public Task<List<Mushroom>> GetMushroomsNotDoneAsync()
    {
      return _database.QueryAsync<Mushroom>("SELECT * FROM [Mushroom] WHERE [Done] = 0");
    }

    public Task<Mushroom> GetMushroomAsync(int id)
    {
      return _database.Table<Mushroom>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveAsync(Mushroom mushroom)
    {
      if (mushroom.Id != 0)
      {
        return _database.UpdateAsync(mushroom);
      }
      else
      {
        return _database.InsertAsync(mushroom);
      }
    }

    public Task<int> DeleteItemAsync(Mushroom mushroom)
    {
      return _database.DeleteAsync(mushroom);
    }
  }
}
