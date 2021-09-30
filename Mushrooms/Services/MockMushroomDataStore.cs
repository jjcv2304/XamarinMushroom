using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mushrooms.Models;

namespace Mushrooms.Services
{
    public class MockMushroomDataStore : IDataStore<Mushroom>
    {
        readonly List<Mushroom> mushrooms;

        public MockMushroomDataStore()
        {
            mushrooms = new List<Mushroom>()
            {
                new Mushroom(Guid.NewGuid(), "Common Name 1", "Scientific Name 1", Cap.Conical, MarginType.Appendiculate, MarginCurvature.Incurved, GillAttachment.Adnate, StemShape.Bulbous, RingType.Double),
                new Mushroom(Guid.NewGuid(), "Common Name 2", "Scientific Name 2", Cap.Conical, MarginType.Appendiculate, MarginCurvature.Incurved, GillAttachment.Adnate, StemShape.Bulbous, RingType.Double),
                new Mushroom(Guid.NewGuid(), "Common Name 3", "Scientific Name 3", Cap.Conical, MarginType.Appendiculate, MarginCurvature.Incurved, GillAttachment.Adnate, StemShape.Bulbous, RingType.Double),
            };
        }

        public async Task<bool> AddAsync(Mushroom mushroom)
        {
            mushrooms.Add(mushroom);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Mushroom mushroom)
        {
            var oldMushroom = mushrooms.FirstOrDefault(m => m.Id == mushroom.Id);
            mushrooms.Remove(oldMushroom);
            mushrooms.Add(mushroom);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var mushroom = mushrooms.FirstOrDefault(m => m.Id == new Guid(id));
            mushrooms.Remove(mushroom);

            return await Task.FromResult(true);
        }

        public async Task<Mushroom> GetAsync(string id)
        {
            return (await Task.FromResult(mushrooms.FirstOrDefault(m => m.Id == new Guid(id))))!;
        }

        public async Task<IEnumerable<Mushroom>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(mushrooms);
        }
    }
}