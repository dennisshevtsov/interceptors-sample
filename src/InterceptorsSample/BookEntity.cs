namespace InterceptorsSample;

public sealed class BookEntity(Guid id, string title)
{
  public Guid Id { get; set; } = id;

  public string Title { get; set; } = title;
}
