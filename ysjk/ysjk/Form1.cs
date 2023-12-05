using System.Windows.Forms;
using Notepad;
using WindowsFormsRec;
using Capture;

namespace ysjk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Notepad.Form1 notepad;
        private WindowsFormsRec.Form1 rec;
        private Capture.Form1 capture1;
        private void painbtn_Click(object sender, EventArgs e)
        {
            if (!(notepad == null || !notepad.Visible))
            {
                notepad.Focus();
                return;
            }
            notepad = new Notepad.Form1();
            notepad.Show();
        }

        private void recordbtn_Click(object sender, EventArgs e)
        {
            if (!(rec == null || !rec.Visible))
            {
                rec.Focus();
                return;
            }
            rec = new WindowsFormsRec.Form1();
            rec.Show();
        }

        private void notebtn_Click(object sender, EventArgs e)
        {
            if (!(notepad == null || !notepad.Visible))
            {
                notepad.Focus();
                return;
            }
            notepad = new Notepad.Form1();
            notepad.Show();
        }

        private void capture_Click(object sender, EventArgs e)
        {
            if (!(capture1 == null || !capture1.Visible))
            {
                capture1.Focus();
                return;
            }
            capture1 = new Capture.Form1();
            capture1.Show();
        }
    }
}