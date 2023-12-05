using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRec
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        private Notepad.Form1 notepad;
        private WindowsFormsRec.Form1 rec;
        private Capture.Form1 capture1;
        private drawing.paint paint;

        private void paintbtn_Click(object sender, EventArgs e)
        {
            if (!(paint == null || !paint.Visible))
            {
                paint.Focus();
                return;
            }
            paint = new drawing.paint();
            paint.Show();
        }

        private void recbtn_Click(object sender, EventArgs e)
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
