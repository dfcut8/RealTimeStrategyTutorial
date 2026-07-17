using Godot;

public partial class GlobalSceneManager : Node
{
    [Export]
    public required PackedScene FirstLevel { get; set; }

    [Export]
    public required PackedScene MainMenuScreen { get; set; }

    public static GlobalSceneManager? Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public void SwitchToFirstLevel()
    {
        GetTree().ChangeSceneToPacked(FirstLevel);
    }

    public void SwitchToMainMenuScreen()
    {
        GetTree().ChangeSceneToPacked(MainMenuScreen);
    }
}
