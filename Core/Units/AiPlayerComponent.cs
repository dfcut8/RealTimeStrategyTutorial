using System.Collections.Generic;
using Godot;

namespace RealTimeStrategyTutorial.Core.Units;

public partial class AiPlayerComponent : Node
{
    [Export]
    public float DetectRange { get; set; }

    [Export]
    public float DetectRate { get; set; }

    private double lastDetectTime;
    private List<Unit> enemyList = [];
    private Unit owner = new();

    public override void _Ready()
    {
        owner = GetParent<Unit>();
    }

    public override void _Process(double delta)
    {
        var time = Time.GetUnixTimeFromSystem();
        if (time - lastDetectTime < DetectRange)
        {
            lastDetectTime = time;
            UpdateEnemyList();
            Detect();
        }
    }

    private void Detect() { }

    private void UpdateEnemyList()
    {
        enemyList.Clear();
        var listFromGroup = GetTree().GetNodesInGroup("UnitsPlayer");
        foreach (var obj in listFromGroup)
        {
            if (obj is Unit u)
            {
                enemyList.Add(u);
            }
        }
    }
}
