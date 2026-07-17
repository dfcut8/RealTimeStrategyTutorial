using Godot;

namespace RealTimeStrategyTutorial.Ui;

public partial class EndScreen : CanvasLayer
{
    [Export]
    public required PackedScene MenuScreen { get; set; }

    private Label? teamLabel;
    private Button mainMenuBtn;

    public override void _Ready()
    {
        teamLabel = GetNode<Label>("%TeamLabel");
        mainMenuBtn = GetNode<Button>("%MainMenuBtn");
        mainMenuBtn.Pressed += LoadMenu;

        Visible = false;
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public void Update(string winnerTeam)
    {
        teamLabel?.Text = winnerTeam;
        Visible = true;
        ProcessMode = ProcessModeEnum.Always;
    }

    private void LoadMenu()
    {
        GetTree().ChangeSceneToPacked(MenuScreen);
    }
}
