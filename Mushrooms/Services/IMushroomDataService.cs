using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.Models;

namespace Mushrooms.Services
{
  public interface IMushroomDataService
  {
    Task<bool> AddAsync(Mushroom mushroom);
    Task<bool> UpdateAsync(Mushroom mushroom);
    Task<bool> DeleteAsync(string id);
    Task<Mushroom> GetAsync(string id);
    Task<IEnumerable<Mushroom>> GetAsync(bool forceRefresh = false);
  }
}
