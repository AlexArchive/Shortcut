using System.Windows.Forms;

namespace Shortcut.Demo.Forms
{
    public partial class MainForm : Form
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainForm()
        {
            InitializeComponent();
            InitialzeHotkeyBindings();
        }

        private void InitialzeHotkeyBindings()
        {
            _hotkeyBinder.Bind(Modifiers.Control, Keys.F).To(HotkeyCallback);
        }

        private static void HotkeyCallback()
        {
            MessageBox.Show("Hello, World.");
        }
    }
}
