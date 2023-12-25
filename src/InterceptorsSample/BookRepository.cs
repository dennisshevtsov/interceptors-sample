using Microsoft.EntityFrameworkCore;

namespace InterceptorsSample
{
  public sealed class BookRepository(DbContext dbContext)
  {
    private readonly DbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public Task<BookEntity?> GetBookAsync(Guid id, CancellationToken cancellationToken) =>
      _dbContext.Set<BookEntity>()
                .AsNoTracking()
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
  }
}
