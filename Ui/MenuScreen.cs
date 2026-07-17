using Godot;

public partial class MenuScreen : Control
{
    private Button? playAgainBtn;
    private Button? quitBtn;

    //private GlobalSceneManager? sceneManager;

    public override void _Ready()
    {
        //sceneManager = GetNode<GlobalSceneManager>("/root/GlobalSceneManager");
        quitBtn = GetNode<Button>("%QuitBtn");
        quitBtn.Pressed += OnQuitBtnPressed;
        playAgainBtn = GetNode<Button>("%PlayAgainBtn");
        playAgainBtn.Pressed += OnPlayAgainBtnPressed;
    }

    private void OnPlayAgainBtnPressed()
    {
        GlobalSceneManager.Instance?.SwitchToFirstLevel();
    }

    private void OnQuitBtnPressed()
    {
        GetTree().Quit();
    }

    public override void _Process(double delta) { }
}
