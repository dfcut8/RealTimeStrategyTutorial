using Godot;

namespace RealTimeStrategyTutorial.Core;

public static class GDExtentions
{
    public static void CrashWithError(this SceneTree st, string message)
    {
        GD.PrintErr(message);
        st.Quit(1);
    }
}
