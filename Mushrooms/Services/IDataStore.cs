using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mushrooms.Services
{
  public interface IDataStore<T>
  {
    Task<bool> AddAsync(T mushroom);
    Task<bool> UpdateAsync(T mushroom);
    Task<bool> DeleteAsync(string id);
    Task<T> GetAsync(string id);
    Task<IEnumerable<T>> GetAsync(bool forceRefresh = false);
  }
}
