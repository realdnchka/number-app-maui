using Microsoft.Maui.Graphics.Text;
using NumberApp.CustomControls;
using NumberApp.Functional;

namespace NumberApp;

public partial class MainPage : ContentPage
{
    private int _currentSum = 0;
    private List<GameButton> _buttons = new();
    
    public MainPage()
    {
        InitializeComponent();
        StartGame();
    }
    
    Label debugButton = new Label
    {
        Text = "Debug Button"
    };
    
    private void OnNumBtnClicked(object sender, EventArgs e)
    {
        var button = (GameButton) sender;
        var number = Int32.Parse(button.Text);
        var correctSum = Int32.Parse(SumBtn.Text);
        
        if (button.isClicked)
        {
            _currentSum += number;
        }
        else
        {
            _currentSum -= number;
        }
        
        debugButton.Text = _currentSum.ToString();
        
        if (_currentSum == correctSum)
        {
            ChangeNumbers();
        }
    }

    private void StartGame()
    {
        //Creating buttons
        ButtonsLayout.Children.Add(debugButton);
        _buttons.Add(CreateButton("FirstNumBtn"));
        _buttons.Add(CreateButton("SecondNumBtn"));
        _buttons.Add(CreateButton("ThirdNumBtn"));
        _buttons.Add(CreateButton("FourthNumBtn"));
        _buttons.Add(CreateButton("FifthNumBtn"));

        foreach (var button in _buttons)
        {
            ButtonsLayout.Children.Add(button);
        }
        ChangeNumbers();
    }

    private void ChangeNumbers()
    {
        _currentSum = 0;
        var numbers = new NumGenerator().GetNumbers();
        SumBtn.Text = numbers[5].ToString();
        
        for(var i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].isClicked = false;
            _buttons[i].Text = numbers[i].ToString();
        }
    }

    private GameButton CreateButton(string styleId)
    {
        var Button = new GameButton()
        {
            StyleId = styleId,
            HorizontalOptions = LayoutOptions.Center,
        };
        
        Button.Clicked += OnNumBtnClicked;
        return Button;
    }
}