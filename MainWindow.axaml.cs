using Avalonia.Controls;

namespace AvaloniaApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Button button = (Button)sender;

        switch (button.CommandParameter)
        {
            case "lerning":
                var lerning = new LerningWindow();
                lerning.Show();
                break;

            case "test":
                var lest = new TestWindow();
                lest.Show();
                break;

            case "definition":
                var definition = new DefinitionWindow();
                definition.Show();
                break;
        }
    }
}