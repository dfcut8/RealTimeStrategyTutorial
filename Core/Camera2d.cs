using Godot;

public partial class Camera2d : Camera2D
{
    public override void _Ready() { }

    public override void _Process(double delta) { }

    public override void _UnhandledInput(InputEvent e)
    {
        if (e is InputEventMouseButton mouseButtonEvent)
        {
            if (mouseButtonEvent.ButtonMask == MouseButtonMask.Middle)
            {
                GD.Print($"Setting camera position to: {mouseButtonEvent.GlobalPosition}");
                var rect = GetViewport().GetVisibleRect();
                GD.Print($"rect={rect.Size}");
                Position = mouseButtonEvent.GlobalPosition - (rect.Size / 2);
            }
        }
    }
}
