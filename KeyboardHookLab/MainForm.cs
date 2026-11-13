namespace KeyboardHookLab;

// Окно с журналом клавиатурных событий.
public sealed class MainForm : Form
{
    private readonly TextBox _logTextBox;

    public MainForm()
    {
        Text = "Keyboard Events";
        Width = 700;
        Height = 450;
        StartPosition = FormStartPosition.CenterScreen;

        // Форма получает события клавиатуры раньше дочерних элементов.
        KeyPreview = true;

        _logTextBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical
        };

        Controls.Add(_logTextBox);

        KeyDown += OnKeyDown;
        KeyUp += OnKeyUp;
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        // Escape очищает журнал.
        if (e.KeyCode == Keys.Escape)
        {
            _logTextBox.Clear();
            return;
        }

        _logTextBox.AppendText(
            $"[{DateTimeOffset.Now:HH:mm:ss.fff}] Нажата клавиша: {e.KeyCode}" +
            Environment.NewLine);
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        _logTextBox.AppendText(
            $"[{DateTimeOffset.Now:HH:mm:ss.fff}] Отпущена клавиша: {e.KeyCode}" +
            Environment.NewLine);
    }
}