using Godot;

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
}
