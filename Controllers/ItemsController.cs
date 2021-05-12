using System;
using System.Collections.Generic;
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
    public IEnumerable<Item> GetItems()
    {
      var items = repository.GetItems();
      return items;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id) // ActionResult allows it to return more than one type. "NotFound" is different type of "Item"
    {
      var item = repository.GetItem(id);
      if (item is null)
      {
        return NotFound();
      }
      return item;
    }
  }
}