namespace NumberApp;

public partial class CustomPopup : ContentPage
{
    public Button closeButton;
    //TODO customize popup and make it actually as popup
    public CustomPopup()
    {
        closeButton = new Button
        {
            Text = "Restart Game",
        };
        
        closeButton.Clicked += async (sender, args) => await Navigation.PopAsync();

        Content = new StackLayout
        {
            Padding = new Thickness(20),
            Children = { new Label { Text = "This is a popup window!" }, closeButton }
        };
    }
}