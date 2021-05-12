using System;
using System.Collections.Generic;
using System.Linq;
using catalog_dotnet_api.Entities;

namespace catalog_dotnet_api.Repositories
{
  public class InMemItemsRepository
  {
    private readonly List<Item> items = new() // nao é necessário usar "new List<Item>()" 
    {
      new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow },
    };

    public IEnumerable<Item> GetItems() => items;
    public Item GetItem(Guid id) => items.Where(item => item.Id == id).SingleOrDefault();
  }
}