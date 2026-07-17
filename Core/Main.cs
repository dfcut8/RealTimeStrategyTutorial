using System.Collections.Generic;
using System.Linq;
using Godot;
using RealTimeStrategyTutorial.Core.Units;

namespace RealTimeStrategyTutorial.Core;

public partial class Main : Node2D
{
    private Dictionary<Unit.TeamEnum, int> units = [];

    public override void _Ready()
    {
        foreach (var u in GetTree().GetNodesInGroup("Units"))
        {
            if (u is not Unit unit)
            {
                continue;
            }
            units[unit.Team] = units.GetValueOrDefault(unit.Team) + 1;
            unit.Died += OnUnitDied;
        }
    }

    public override void _Process(double delta) { }

    private void OnUnitDied(Unit u)
    {
        units[u.Team]--;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        GD.Print($"Checking if we have a winner: {string.Join(", ", units)}.");

        var teamsAlive = units.Where(x => x.Value > 0).ToList();

        if (teamsAlive.Count > 1)
        {
            GD.Print("Still playing");
        }
        else if (teamsAlive.Count == 1)
        {
            GD.Print($"Winner: {teamsAlive[0].Key}.");
        }
    }
}
