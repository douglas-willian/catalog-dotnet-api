using System;
using System.Collections.Generic;
using catalog_dotnet_api.Entities;

namespace catalog_dotnet_api.Repositories
{
  public interface IItemsRepository
  {
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
  }
}