using Godot;

namespace RealTimeStrategyTutorial.Ui;

public partial class EndScreen : CanvasLayer
{
    private Label? teamLabel;

    public override void _Ready()
    {
        teamLabel = GetNode<Label>("%TeamLabel");
        Visible = false;
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public void Update(string winnerTeam)
    {
        teamLabel?.Text = winnerTeam;
        Visible = true;
        ProcessMode = ProcessModeEnum.Always;
    }
}
