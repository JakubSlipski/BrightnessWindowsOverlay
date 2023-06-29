using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AlwaysOnTopApp
{
    public class MainForm : Form
    {
        private Button openButton;
        private Button openCodeButton;
        private Button closeButton;
        private Panel movePanel;

        private bool isDragging;
        private Point dragStartPosition;

        public MainForm()
        {
            InitializeComponents();
            SetTransparentWindow();
        }

        private void InitializeComponents()
        {
            openButton = new Button();
            openButton.Text = "B20";
            openButton.Size = new Size(40, 40);
            openButton.Location = new Point(10, 20);
            openButton.Click += OpenButton_Click;
            openButton.BackColor = Color.LimeGreen; // Set the background color of the button to lime
            openButton.ForeColor = Color.Black; // Set the text color of the button to dark red
            openButton.FlatStyle = FlatStyle.Flat; // Set the button style to flat
            openButton.Font = new Font(openButton.Font.FontFamily, openButton.Font.Size - 0); // Reduce the font size by one point
            this.Controls.Add(openButton);

            openCodeButton = new Button();
            openCodeButton.Text = "B100";
            openCodeButton.Size = new Size(40, 40);
            openCodeButton.Location = new Point(60, 20);
            openCodeButton.Click += OpenCodeButton_Click;
            openCodeButton.BackColor = Color.LimeGreen; // Set the background color of the button to lime
            openCodeButton.ForeColor = Color.Black; // Set the text color of the button to dark red
            openCodeButton.FlatStyle = FlatStyle.Flat; // Set the button style to flat
            openCodeButton.Font = new Font(openCodeButton.Font.FontFamily, openCodeButton.Font.Size - 1); // Reduce the font size by one point
            this.Controls.Add(openCodeButton);

            closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Size = new Size(40, 40);
            closeButton.Location = new Point(110, 20);
            closeButton.Click += CloseButton_Click;
            closeButton.BackColor = Color.LimeGreen; // Set the background color of the button to lime
            closeButton.ForeColor = Color.Black; // Set the text color of the button to dark red
            closeButton.FlatStyle = FlatStyle.Flat; // Set the button style to flat
            closeButton.Font = new Font(closeButton.Font.FontFamily, closeButton.Font.Size + 2); // Reduce the font size by one point
            this.Controls.Add(closeButton);

            movePanel = new Panel();
            movePanel.Size = new Size(140, 10);
            movePanel.Location = new Point(10, 10);
            movePanel.BackColor = Color.DimGray;
            movePanel.MouseDown += MovePanel_MouseDown;
            movePanel.MouseMove += MovePanel_MouseMove;
            movePanel.MouseUp += MovePanel_MouseUp;
            this.Controls.Add(movePanel);
            movePanel.BringToFront();
        }

        private void OpenButton_Click(object sender, EventArgs e) //20%
        {
            string filePath = "Brightness20.bat"; // Replace with your desired file path
            Process.Start(filePath);
        }

        private void OpenCodeButton_Click(object sender, EventArgs e) //100%
        {
            string codeFilePath = "Brightness100.bat"; // Replace with your desired code file path
            Process.Start(codeFilePath);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTransparentWindow()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Lime; // Set any color that will be made transparent
            this.TransparencyKey = Color.Lime;
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            TextRenderer.DrawText(e.Graphics, button.Text, button.Font, button.ClientRectangle, button.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }

        private void MovePanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPosition = new Point(e.X, e.Y);
        }

        private void MovePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = PointToScreen(e.Location);
                Location = new Point(currentPosition.X - dragStartPosition.X, currentPosition.Y - dragStartPosition.Y);
            }
        }

        private void MovePanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.TopMost = true; // Set the form to always stay on top
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(40, 0);
        }
    }

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
