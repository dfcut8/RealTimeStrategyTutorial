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

    public Unit? GetSelectedUnit()
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
