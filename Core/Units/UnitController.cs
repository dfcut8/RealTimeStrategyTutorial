using Godot;
using RealTimeStrategyTutorial.Core;

namespace RealTimeStrategy.Core.Units;

public partial class UnitController : Node2D
{
    private Unit? selectedUnit;

    public override void _Ready() { }

    public override void _Process(double delta) { }

    public override void _UnhandledInput(InputEvent e)
    {
        if (e is not InputEventMouseButton { Pressed: true } mouseEvent)
        {
            return;
        }

        switch (mouseEvent.ButtonIndex)
        {
            case MouseButton.Left:
                TrySelectUnit();
                break;

            case MouseButton.Right:
                TryCommandUnit();
                break;
        }
    }

    private void TrySelectUnit()
    {
        var u = GetSelectedUnit();
    }

    private void SelectUnit(Unit u) { }

    private void UnSelectUnit(Unit u) { }

    private void TryCommandUnit() { }

    private Unit? GetSelectedUnit()
    {
        var spaceState = GetWorld2D().DirectSpaceState;
        if (spaceState is null)
        {
            GetTree().CrashWithError("[UnitController]: Failed to get DirectSpaceState.");
            return null;
        }

        var query = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollideWithBodies = false,
        };

        var intersections = spaceState.IntersectPoint(query, 1);

        return intersections.Count > 0
            ? intersections[0]["collider"].AsGodotObject() as Unit
            : null;
    }
}
