// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
  "Style",
  "IDE0063:Use simple 'using' statement",
  Justification = @"
    It transforms the block into one that has no curly brackets, which makes the
    code harder to understand and might cause issues",
  Scope = "module"
)]
