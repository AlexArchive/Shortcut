using System;
using System.Windows;
using System.Windows.Forms;

namespace Shortcut.Demo.WPF
{
    public partial class MainWindow : Window
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            _hotkeyBinder.Bind(Modifiers.Control, Keys.F).To(HotkeyCallback);
        }

        private void HotkeyCallback()
        {
            System.Windows.MessageBox.Show("Hello, World");
        }
    }
}
