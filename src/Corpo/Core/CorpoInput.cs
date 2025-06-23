namespace Corpo.Core;


public readonly record struct CorpoInput(
  Horizontal Horizontal,
  Vertical Vertical,
  Decide Decide,
  DebugInput Debug
);

public readonly record struct Horizontal(
  bool Left,
  bool Right
);

public readonly record struct Vertical(
  bool Up,
  bool Down
);

public readonly record struct Decide(
  bool Accept,
  bool Cancel,
  bool Cycle
);

public readonly record struct DebugInput(
  bool Toggle
);
