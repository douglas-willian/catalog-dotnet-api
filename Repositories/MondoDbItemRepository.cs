using System;
using System.Collections.Generic;
using catalog_dotnet_api.Entities;
using MongoDB.Driver;

namespace catalog_dotnet_api.Repositories
{
  public class MondoDbItemRepository : IItemsRepository
  {

    private const string DATABASE_NAME = "Catalog";
    private const string COLLECTION_NAME = "items";
    private readonly IMongoCollection<Item> itemsCollection;

    public MondoDbItemRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DATABASE_NAME);
      itemsCollection = database.GetCollection<Item>(COLLECTION_NAME);
    }

    public void CreateItem(Item item)
    {
      throw new NotImplementedException();
    }

    public void DeleteItem(Guid id)
    {
      throw new NotImplementedException();
    }

    public Item GetItem(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItems()
    {
      throw new NotImplementedException();
    }

    public void UpdateItem(Item item)
    {
      throw new NotImplementedException();
    }
  }
}