using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalog_dotnet_api.Entities;

namespace catalog_dotnet_api.Repositories
{
  public interface IItemsRepository
  {
    Task<Item> GetItem(Guid id);
    Task<IEnumerable<Item>> GetItems();
    Task CreateItem(Item item);
    Task UpdateItem(Item item);
    Task DeleteItem(Guid id);
  }
}