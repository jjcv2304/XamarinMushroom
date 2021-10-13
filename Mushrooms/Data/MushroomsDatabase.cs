using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.Models;
using SQLite;

namespace Mushrooms.Data
{
  public class MushroomsDatabase
  {
    private static SQLiteAsyncConnection _database = null!;

    public static readonly AsyncLazy<MushroomsDatabase> Instance = new AsyncLazy<MushroomsDatabase>(async () =>
    {
      var instance = new MushroomsDatabase();
    //  var result = await _database.CreateTableAsync<Mushroom>();
      return instance;
    });

    public MushroomsDatabase()
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

    public Task<int> SaveItemAsync(Mushroom mushroom)
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
