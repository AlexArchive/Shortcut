using System;
using System.Windows.Forms;

namespace Shortcut.Demo.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HotkeyBinder _hotkeyBinder = 
            new HotkeyBinder();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HotkeyCombination captureScreenHotkey = 
                new HotkeyCombination(Modifiers.Control, Keys.P);

            _hotkeyBinder.Bind(captureScreenHotkey).To(CaptureScreen);
        }

        private void CaptureScreen()
        {
            MessageBox.Show("Capturing Screen!");
        }
    }
}
