// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace InterceptorsSample;

internal static class BookRepositoryInterceptors
{
  internal static bool SetCalled { get; set; }

  internal static bool NoTrackingCalled { get; set; }

  internal static bool WhereCalled { get; set; }

  internal static bool FirstOrDefaultAsyncCalled { get; set; }

  // Use the real path to the file.
  [InterceptsLocation(@"BookRepository.cs", 14, 18)]
  public static DbSet<BookEntity> Set(this DbContext dbContext)
  {
    SetCalled = true;
    return null!;
  }

  [InterceptsLocation(@"BookRepository.cs", 15, 18)]
  public static IQueryable<BookEntity> AsNoTracking(this IQueryable<BookEntity> set)
  {
    NoTrackingCalled = true;
    return set;
  }

  [InterceptsLocation(@"BookRepository.cs", 16, 18)]
  public static IQueryable<BookEntity> Where(this IQueryable<BookEntity> set, Func<BookEntity, bool> predicate)
  {
    WhereCalled = true;
    return set;
  }

  [InterceptsLocation(@"BookRepository.cs", 17, 18)]
  public static Task<BookEntity?> FirstOrDefaultAsync(this IQueryable<BookEntity> set, CancellationToken cancellationToken)
  {
    FirstOrDefaultAsyncCalled = true;
    return Task.FromResult<BookEntity?>(null);
  }
}
