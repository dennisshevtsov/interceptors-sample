// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
#pragma warning disable CS9113
public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
#pragma warning restore CS9113
{
}
