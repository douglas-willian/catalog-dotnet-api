using catalog_dotnet_api.Dtos;
using catalog_dotnet_api.Entities;

namespace catalog_dotnet_api
{
  public static class Extensions
  {
    public static ItemDto AsDto(this Item item)
    {
      return new ItemDto
      {
        Id = item.Id,
        Name = item.Name,
        Price = item.Price,
        CreatedDate = item.CreatedDate
      };
    }
  }
}