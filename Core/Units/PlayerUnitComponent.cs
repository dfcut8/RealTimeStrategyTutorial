using Godot;

public partial class PlayerUnitComponent : Node
{
    [Export]
    private Sprite2D? selectionSprite;

    public override void _Ready()
    {
        selectionSprite?.Visible = false;
    }

    public void ToggleSelection(bool toggle)
    {
        selectionSprite?.Visible = toggle;
    }
}
