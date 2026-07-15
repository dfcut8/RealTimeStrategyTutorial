using Godot;
using RealTimeStrategyTutorial.Core.Units;

namespace RealTimeStrategyTutorial.Core.Ui;

public partial class HealthBar : ProgressBar
{
    private Unit? owner;

    public override void _Ready()
    {
        owner = GetParent() as Unit;
        if (owner is null)
        {
            GetTree().CrashWithError("[HealthBar] Failed to get owner!");
            return;
        }
        MaxValue = owner.MaxHp;
        Visible = false;
        owner?.Damaged += OnDamaged;
    }

    private void OnDamaged(int v)
    {
        Visible = true;
        Value = v;
    }
}
