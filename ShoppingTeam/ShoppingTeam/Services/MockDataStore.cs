using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ShoppingTeam.Models;

[assembly: Xamarin.Forms.Dependency(typeof(ShoppingTeam.Services.MockDataStore))]
namespace ShoppingTeam.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Bananen", Description="Yummy." , Menge = "1 Stk.", Kategorie=Kategorien.Obst},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Salami", Description="Rund und rot.", Menge = "1 Pkg.", Kategorie=Kategorien.Fleisch },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Milch", Description="This is an item description.", Menge = "1 Liter", Kategorie=Kategorien.Kühlregal },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Bier", Description="This is an item description.", Menge = "6 pack", Kategorie=Kategorien.Getränke },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Erdbeeren", Description="Rot und saftig.", Menge = "1 Schale"},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}