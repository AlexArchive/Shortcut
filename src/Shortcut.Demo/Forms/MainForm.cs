using System.Windows.Forms;

namespace Shortcut.Demo.Forms
{
    public partial class MainForm : Form
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainForm()
        {
            InitializeComponent();
            var hotkey = new HotkeyCombination(Modifiers.Control, Keys.F);
            _hotkeyBinder.Bind(hotkey).To(HotkeyCallback);
        }

        private static void HotkeyCallback()
        {
            MessageBox.Show("Trace: HotkeyCallback()");
        }
    }
}
