using Godot;

namespace RealTimeStrategyTutorial.Ui;

public partial class EndScreen : CanvasLayer
{
    private Label? teamLabel;
    private Button? mainMenuBtn;

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
        GlobalSceneManager.Instance?.SwitchToMainMenuScreen();
    }
}
