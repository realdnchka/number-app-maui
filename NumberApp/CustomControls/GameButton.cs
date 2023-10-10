namespace NumberApp.CustomControls;

public class GameButton: Button
{
    public bool isClicked = false;

    public event EventHandler NewClicked;

    public GameButton()
    {
        Clicked += OnButtonClicked;
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        // Toggle the clicked state
        isClicked = !isClicked;

        // Raise the Clicked event
        NewClicked?.Invoke(this, e);
    }
}