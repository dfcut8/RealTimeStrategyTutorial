using System.Collections.Generic;
using Godot;

namespace RealTimeStrategyTutorial.Core.Units;

public partial class AiPlayerComponent : Node
{
    [Export]
    public float DetectRange { get; set; } = 10f;

    [Export]
    public float DetectRate { get; set; }

    private double lastDetectTime;
    private List<Unit> enemyList = [];
    private Unit owner = new();

    public override void _Ready()
    {
        owner = GetOwner<Unit>();
    }

    public override void _Process(double delta)
    {
        var time = Time.GetUnixTimeFromSystem();
        if (time - lastDetectTime > DetectRate)
        {
            lastDetectTime = time;
            UpdateEnemyList();
            Detect();
        }
    }

    private void Detect()
    {
        Unit? closestEnemy = null;
        float closestDist = float.MaxValue;
        foreach (var enemy in enemyList)
        {
            var dist = owner.GlobalPosition.DistanceTo(enemy.Position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy is not null)
        {
            owner.SetAttackTarget(closestEnemy);
        }
    }

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
