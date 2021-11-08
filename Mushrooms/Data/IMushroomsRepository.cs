using System.Collections.Generic;
using System.Threading.Tasks;
using Mushrooms.Models;

namespace Mushrooms.Data
{
  public interface IMushroomsRepository
  {
    Task<List<Mushroom>> GetMushroomsAsync();
    Task<List<Mushroom>> GetMushroomsNotDoneAsync();
    Task<Mushroom> GetMushroomAsync(int id);
    Task<int> SaveAsync(Mushroom mushroom);
    Task<int> DeleteItemAsync(Mushroom mushroom);
  }
}