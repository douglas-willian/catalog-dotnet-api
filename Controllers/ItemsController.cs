using System;
using System.Collections.Generic;
using System.Linq;
using catalog_dotnet_api.Dtos;
using catalog_dotnet_api.Entities;
using catalog_dotnet_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog_dotnet_api.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class ItemsController : ControllerBase
  {
    private readonly IItemsRepository repository;

    public ItemsController(IItemsRepository repository)
    {
      this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
      var items = repository.GetItems().Select(item => item.AsDto());
      return items;
    }

    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id) // ActionResult allows it to return more than one type. "NotFound" is different type of "Item"
    {
      var item = repository.GetItem(id);
      if (item is null)
      {
        return NotFound();
      }
      return item.AsDto();
    }

    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        Name = itemDto.Name,
        Price = itemDto.Price,
        CreatedDate = DateTimeOffset.UtcNow
      };

      repository.CreateItem(item);

      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
      var existingItem = repository.GetItem(id);
      if (existingItem is null)
      {
        return NotFound();
      }

      Item updatedItem = existingItem with
      {
        Name = itemDto.Name,
        Price = itemDto.Price
      };

      repository.UpdateItem(updatedItem);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
      var existingItem = repository.GetItem(id);
      if (existingItem is null)
      {
        return NotFound();
      }

      repository.DeleteItem(id);

      return NoContent();
    }
  }
}