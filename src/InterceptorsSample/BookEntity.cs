// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace InterceptorsSample;

public sealed class BookEntity(Guid id, string title)
{
  public Guid Id { get; set; } = id;

  public string Title { get; set; } = title;
}
