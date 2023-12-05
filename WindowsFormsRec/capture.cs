using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capture
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Rectangle selectedRegion;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            await Task.Delay(500);

            SendKeys.Send("{PRTSC}");
            Image img = Clipboard.GetImage();

            pictureBox1.Image = img;

            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Image| *.jpg | Bitmap Image | *.bmp";
            saveFileDialog.Title = "Save Image";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = (FileStream)saveFileDialog.OpenFile())
                    {
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                                break;

                            case 2:
                                pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving the file: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var captureForm = new CaptureForm())
            {
                if (captureForm.ShowDialog() == DialogResult.OK)
                {
                    selectedRegion = captureForm.SelectedRegion;
                    Bitmap capturedImage = CaptureRegion(selectedRegion);
                    pictureBox1.Image = capturedImage;
                }
            }
            this.Show();
        }

        private Bitmap CaptureRegion(Rectangle region)
        {
            Bitmap screenshot = new Bitmap(region.Width, region.Height);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(region.Location, Point.Empty, region.Size);
            }
            return screenshot;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CaptureForm : System.Windows.Forms.Form
    {
        private Point startPoint;
        private Rectangle selectedRegion;

        public Rectangle SelectedRegion => selectedRegion;

        public CaptureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds; // 전체 화면 크기로 설정
            this.BackColor = Color.Black;
            this.Opacity = 0.5;
            this.Cursor = Cursors.Cross;
            this.MouseDown += CaptureForm_MouseDown;
            this.MouseMove += CaptureForm_MouseMove;
            this.MouseUp += CaptureForm_MouseUp;
        }

        private void CaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - startPoint.X;
                int height = e.Y - startPoint.Y;
                selectedRegion = new Rectangle(startPoint.X, startPoint.Y, width, height);
                this.Invalidate();
            }
        }

        private void CaptureForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (selectedRegion.Width > 0 && selectedRegion.Height > 0)
            {
                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedRegion);
                }
            }
        }
    }
}
