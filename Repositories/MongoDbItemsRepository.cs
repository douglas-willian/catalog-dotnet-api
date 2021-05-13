using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalog_dotnet_api.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace catalog_dotnet_api.Repositories
{
  public class MongoDbItemsRepository : IItemsRepository
  {

    private const string DATABASE_NAME = "Catalog";
    private const string COLLECTION_NAME = "items";
    private readonly IMongoCollection<Item> itemsCollection;

    public MongoDbItemsRepository(MongoClientBase mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DATABASE_NAME);
      itemsCollection = database.GetCollection<Item>(COLLECTION_NAME);
    }

    public async Task CreateItem(Item item)
    {
      await itemsCollection.InsertOneAsync(item);
    }

    public async Task DeleteItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      await itemsCollection.DeleteOneAsync(filter);
    }

    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

    public async Task<Item> GetItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      return await itemsCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Item>> GetItems()
    {
      return await itemsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateItem(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
      await itemsCollection.ReplaceOneAsync(filter, item);
    }
  }
}