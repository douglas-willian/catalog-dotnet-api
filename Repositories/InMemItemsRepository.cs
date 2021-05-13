using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog_dotnet_api.Entities;

namespace catalog_dotnet_api.Repositories
{
  /// <summary>
  /// Using Async Await here just for practicing purposes.
  /// </summary>
  public class InMemItemsRepository : IItemsRepository
  {
    private readonly List<Item> items = new() // nao é necessário usar "new List<Item>()" 
    {
      new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow },
    };

    public async Task<IEnumerable<Item>> GetItems() => await Task.FromResult(items);
    public async Task<Item> GetItem(Guid id)
    {
      var item = items.Where(item => item.Id == id).SingleOrDefault();
      return await Task.FromResult(item);
    }

    public async Task CreateItem(Item item)
    {
      items.Add(item);
      await Task.CompletedTask;
    }

    public async Task UpdateItem(Item item)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
      items[index] = item;
      await Task.CompletedTask;
    }

    public async Task DeleteItem(Guid id)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == id);
      items.RemoveAt(index);
      await Task.CompletedTask;
    }
  }
}