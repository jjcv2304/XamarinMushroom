using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mushrooms.Data;
using Mushrooms.Models;

namespace Mushrooms.Services
{
  public class MushroomDataService: IMushroomDataService
  {
    public async Task<bool> AddAsync(Mushroom mushroom)
    {
      MushroomsRepository database = await MushroomsRepository.Instance;
      var result = await database.SaveAsync(mushroom);
      return true;//todo improve
    }

    public Task<bool> UpdateAsync(Mushroom mushroom)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
      throw new NotImplementedException();
    }

    public async Task<Mushroom> GetAsync(string id)
    {
      MushroomsRepository database = await MushroomsRepository.Instance;
      var mushroom = await database.GetMushroomAsync(Convert.ToInt32(id));//todo improve conversion
      return mushroom;
    }

    public async Task<IEnumerable<Mushroom>> GetAsync(bool forceRefresh = false)
    {
      MushroomsRepository database = await MushroomsRepository.Instance;
      var mushrooms = await database.GetMushroomsAsync();
      return mushrooms;
    }
  }
}
