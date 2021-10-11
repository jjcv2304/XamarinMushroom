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
    static SQLiteAsyncConnection Database;

    public static readonly AsyncLazy<MushroomsDatabase> Instance = new AsyncLazy<MushroomsDatabase>(async () =>
    {
      var instance = new MushroomsDatabase();
      CreateTableResult result = await Database.CreateTableAsync<Mushroom>();
      return instance;
    });

    public MushroomsDatabase()
    {
      Database = new SQLiteAsyncConnection(DataConstants.DatabasePath, DataConstants.Flags);
    }


    public Task<List<Mushroom>> GetMushroomsAsync()
    {
      return Database.Table<Mushroom>().ToListAsync();
    }

    public Task<List<Mushroom>> GetMushroomsNotDoneAsync()
    {
      return Database.QueryAsync<Mushroom>("SELECT * FROM [Mushroom] WHERE [Done] = 0");
    }

    public Task<Mushroom> GetMushroomAsync(int id)
    {
      return Database.Table<Mushroom>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync(Mushroom mushroom)
    {
      if (mushroom.Id != 0)
      {
        return Database.UpdateAsync(mushroom);
      }
      else
      {
        return Database.InsertAsync(mushroom);
      }
    }

    public Task<int> DeleteItemAsync(Mushroom mushroom)
    {
      return Database.DeleteAsync(mushroom);
    }
  }
}
