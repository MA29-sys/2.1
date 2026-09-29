namespace EnterCounter;

public partial class Form1 : Form
{
    private int _count;
    private readonly Label _countLabel;

    public Form1()
    {
        InitializeComponent();

        Text = "Licznik Enter";
        ClientSize = new Size(420, 320);
        MinimumSize = new Size(380, 300);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(26, 31, 46);
        Font = new Font("Segoe UI", 10f);
        AcceptButton = null;
        CancelButton = null;

        var title = new Label
        {
            Text = "Licznik Enter",
            ForeColor = Color.FromArgb(232, 236, 244),
            Font = new Font("Segoe UI", 18f, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(32, 28)
        };

        var hint = new Label
        {
            Text = "Naciśnij Enter, aby zwiększyć licznik",
            ForeColor = Color.FromArgb(139, 149, 168),
            Font = new Font("Segoe UI", 11f),
            AutoSize = true,
            Location = new Point(32, 68)
        };

        var countPanel = new Panel
        {
            BackColor = Color.FromArgb(37, 43, 59),
            Location = new Point(32, 110),
            Size = new Size(356, 120),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        _countLabel = new Label
        {
            Text = "0",
            ForeColor = Color.FromArgb(94, 234, 212),
            Font = new Font("Segoe UI", 56f, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };

        var timesLabel = new Label
        {
            Text = "razy",
            ForeColor = Color.FromArgb(139, 149, 168),
            Font = new Font("Segoe UI", 11f),
            AutoSize = false,
            TextAlign = ContentAlignment.TopCenter,
            Height = 28,
            Dock = DockStyle.Bottom
        };

        countPanel.Controls.Add(_countLabel);
        countPanel.Controls.Add(timesLabel);

        var resetButton = new Button
        {
            Text = "Resetuj",
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(94, 234, 212),
            ForeColor = Color.FromArgb(26, 31, 46),
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            Size = new Size(120, 40),
            Location = new Point(150, 250),
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Bottom,
            TabStop = false
        };
        resetButton.FlatAppearance.BorderSize = 0;
        resetButton.Click += (_, _) => ResetCount();

        Controls.Add(title);
        Controls.Add(hint);
        Controls.Add(countPanel);
        Controls.Add(resetButton);

        Resize += (_, _) =>
        {
            countPanel.Width = ClientSize.Width - 64;
            resetButton.Left = (ClientSize.Width - resetButton.Width) / 2;
        };
    }

    // Enter jest klawiszem dialogowym — KeyDown go nie łapie niezawodnie.
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData is Keys.Enter or Keys.Return)
        {
            _count++;
            _countLabel.Text = _count.ToString();
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ResetCount()
    {
        _count = 0;
        _countLabel.Text = "0";
    }
}
