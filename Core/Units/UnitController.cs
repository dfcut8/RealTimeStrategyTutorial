using Godot;
using RealTimeStrategyTutorial.Core;

namespace RealTimeStrategy.Core.Units;

public partial class UnitController : Node2D
{
    private Unit? selectedUnit;

    public override void _Ready() { }

    public override void _Process(double delta) { }

    public override void _Input(InputEvent @event) { }

    private void TrySelectUnit() { }

    private void SelectUnit(Unit u) { }

    private void UnSelectUnit(Unit u) { }

    private void TryCommandUnit() { }

    public Unit GetSelectedUnit()
    {
        var world = GetWorld2D().DirectSpaceState;
        if (world is not null) { }
        else
        {
            GetTree().CrashWithError("[UnitController]: Failed to get DirectSpaceState.");
        }
        return new();
    }
}
