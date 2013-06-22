using System.Windows.Forms;

namespace Shortcut.Demo.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            HotkeyCombination captureScreenHotkeyCombination = 
                new HotkeyCombination(Modifiers.Control, Keys.P);

            _hotkeyBinder.Bind(captureScreenHotkeyCombination).To(CaptureFullScreen);
        }

        private void CaptureFullScreen()
        {
            MessageBox.Show("Capturing screen!");
        }
    }
}
