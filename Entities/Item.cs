using System;

namespace catalog_dotnet_api.Entities
{
  // record types are used for immutable objects. With-expressions support. Value-based equality support
  public record Item
  {
    public Guid Id { get; init; } // Init-only property. After initialization it can no longer be modified.
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
  }
}