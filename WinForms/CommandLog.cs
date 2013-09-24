using System.Windows.Forms;

namespace GSV
{
    public partial class CommandLog : Form
    {
        public CommandLog()
        {
            InitializeComponent();
        }

        private void CommandLog_Load(object sender, System.EventArgs e)
        {
            CommandLogViewer.Text = string.Join("\r\n", Git.CommandLog);
        }
    }
}
