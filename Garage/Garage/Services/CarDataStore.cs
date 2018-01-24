using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Garage.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(Garage.Services.CarDataStore))]
namespace Garage.Services
{
    public class CarDataStore : IDataStore<Car>
    {
        bool isInitialized;
        List<Car> items;

        public async Task<bool> AddItemAsync(Car item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Car item)
        {
            await InitializeAsync();

            var _item = items.Where((Car arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Car item)
        {
            await InitializeAsync();

            var _item = items.Where((Car arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Car> GetItemAsync(string id)
        {
            await InitializeAsync();
            int _id;
            Int32.TryParse(id, out _id);

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == _id));
        }

        public async Task<IEnumerable<Car>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Car>();
            var _items = new List<Car>
            {
                new Car { Id = 1, Name = "KIA Rio", Description="Ласточка"},
                new Car { Id = 2, Name = "LADA 2107", Description="Белочка"},
                new Car { Id = 3, Name = "KIA Ceed", Description="Графит"}
            };

            foreach (Car item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
