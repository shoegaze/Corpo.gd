using Corpo.Adapters.TeamSports.Input.Concrete.Fragments;
using Corpo.Adapters.TeamSports.Input.Concrete.Fragments.Debug;

using TeamSports.Core.Game;


namespace Corpo.Adapters.TeamSports.Input.Concrete;


// TODO?: Inherit from CorpoBaseInput
// TODO?: Generate from UserInput.xml
public readonly record struct CorpoUserInput(
  HorizontalInput Horizontal,
  VerticalInput Vertical,
  SelectionInput Selection,
  DebugInput Debug
) : IUserInput;
