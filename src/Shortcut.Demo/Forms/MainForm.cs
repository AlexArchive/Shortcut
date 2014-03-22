using System.Windows.Forms;

namespace Shortcut.Demo.Forms
{
    public partial class MainForm : Form
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            HotkeyCombination hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
            _hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
        }

        private static void HotkeyCallback()
        {
            MessageBox.Show("Trace: HotkeyCallback()");
        }
    }
}
