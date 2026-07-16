using Godot;

public partial class Camera2d : Camera2D
{
    public override void _UnhandledInput(InputEvent e)
    {
        if (
            e is not InputEventMouseMotion mouseMotionEvent
            || (mouseMotionEvent.ButtonMask & MouseButtonMask.Middle) == 0
        )
        {
            return;
        }

        Position -= mouseMotionEvent.Relative / Zoom;
        ResetSmoothing();
        GetViewport().SetInputAsHandled();
    }
}
