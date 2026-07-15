using Godot;

namespace RealTimeStrategyTutorial.Core.Units;

public partial class AiPlayerComponent : Node
{
    [Export]
    public float DetectRange { get; set; }

    [Export]
    public float DetectRate { get; set; }

    private float lastDetectTime;
    private Unit[] enemyList;

    public override void _Ready() { }

    public override void _Process(double delta) { }
}
