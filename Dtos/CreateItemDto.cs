using System.ComponentModel.DataAnnotations;

namespace catalog_dotnet_api.Dtos
{
  public record CreateItemDto
  {
    [Required]
    public string Name { get; init; }

    [Required]
    [Range(1, 1000)]
    public decimal Price { get; init; }
  }
}