using Corpo.Adapters.TeamSports.Input.Concrete.Fragments;
using Corpo.Adapters.TeamSports.Input.Concrete.Fragments.Debug;


namespace Corpo.Adapters.TeamSports.Input.Concrete;


public readonly record struct CorpoInput(
  HorizontalInput Horizontal,
  VerticalInput Vertical,
  SelectionInput Selection,
  DebugInput Debug
);
