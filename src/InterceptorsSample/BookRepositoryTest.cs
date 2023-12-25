// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterceptorsSample;

[TestClass]
public sealed class BookRepositoryTest
{
#pragma warning disable CS8618
  private BookRepository _bookRepository;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _bookRepository = new BookRepository(new TestDbContext());
  }

  [TestMethod]
  public async Task GetBookAsync_BookId_SetCalled()
  {
    // Arrange
    Guid bookId = Guid.NewGuid();
    BookRepositoryInterceptors.SetCalled = false;

    // Act
    await _bookRepository.GetBookAsync(bookId, CancellationToken.None);

    // Assert
    Assert.IsTrue(BookRepositoryInterceptors.SetCalled);
  }

  [TestMethod]
  public async Task GetBookAsync_BookId_AsNoTrackingCalled()
  {
    // Arrange
    Guid bookId = Guid.NewGuid();
    BookRepositoryInterceptors.NoTrackingCalled = false;

    // Act
    await _bookRepository.GetBookAsync(bookId, CancellationToken.None);

    // Assert
    Assert.IsTrue(BookRepositoryInterceptors.NoTrackingCalled);
  }

  [TestMethod]
  public async Task GetBookAsync_BookId_WhereCalled()
  {
    // Arrange
    Guid bookId = Guid.NewGuid();
    BookRepositoryInterceptors.WhereCalled = false;

    // Act
    await _bookRepository.GetBookAsync(bookId, CancellationToken.None);

    // Assert
    Assert.IsTrue(BookRepositoryInterceptors.WhereCalled);
  }

  [TestMethod]
  public async Task GetBookAsync_BookId_FirstOrDefaultAsyncCalled()
  {
    // Arrange
    Guid bookId = Guid.NewGuid();
    BookRepositoryInterceptors.FirstOrDefaultAsyncCalled = false;

    // Act
    await _bookRepository.GetBookAsync(bookId, CancellationToken.None);

    // Assert
    Assert.IsTrue(BookRepositoryInterceptors.FirstOrDefaultAsyncCalled);
  }
}
