using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace drawing
{
    public partial class paint : Form
    {

        private static Point clickPoint;
        private static Point UpPoint;
        private static Bitmap OriginalBmp;
        private static Bitmap DrawBmp;
        private static Rectangle imgRect;


        public static PaintTools toolType { get; set; }
        public enum PaintTools
        {
            IDLE = default,
            DrawLine,
            DrawRectangle,
            DrawCircle,
            Eraser
        }

        public List<Rectangle> listRect = new List<Rectangle>();
        public List<Rectangle> tempRect = new List<Rectangle>();
        public List<PaintTools> listTool = new List<PaintTools>();
        public List<PaintTools> tempTool = new List<PaintTools>();

        public paint()
        {
            InitializeComponent();
            //White BackgroundImage Load
            pictureBox1.Image = new Bitmap(Application.StartupPath + @"\DefaultBackground.png");
            OriginalBmp = (Bitmap)pictureBox1.Image;
            imgRect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolType = PaintTools.DrawRectangle;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolType = PaintTools.DrawCircle;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolType = PaintTools.DrawLine;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //마우스 클릭 위치 저장
                clickPoint = new Point(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float w = Math.Abs(clickPoint.X - e.X);
                float h = Math.Abs(clickPoint.Y - e.Y);

                Pen pn = new Pen(Color.Black);
                pn.Width = 3;
                Graphics g = pictureBox1.CreateGraphics();
                pictureBox1.Refresh();

                if (toolType == PaintTools.DrawRectangle) //사각형 그리기
                {
                    if (e.X > clickPoint.X)
                    {
                        if (e.Y > clickPoint.Y) g.DrawRectangle(pn, clickPoint.X, clickPoint.Y, w, h);
                        else g.DrawRectangle(pn, clickPoint.X, e.Y, w, h);
                    }
                    else
                    {
                        if (e.Y > clickPoint.Y) g.DrawRectangle(pn, e.X, clickPoint.Y, w, h);
                        else g.DrawRectangle(pn, e.X, e.Y, w, h);
                    }
                }
                else if (toolType == PaintTools.DrawCircle) //원형 그리기
                {
                    if (e.X > clickPoint.X)
                    {
                        if (e.Y > clickPoint.Y) g.DrawEllipse(pn, clickPoint.X, clickPoint.Y, w, h);
                        else g.DrawEllipse(pn, clickPoint.X, e.Y, w, h);
                    }
                    else
                    {
                        if (e.Y > clickPoint.Y) g.DrawEllipse(pn, e.X, clickPoint.Y, w, h);
                        else g.DrawEllipse(pn, e.X, e.Y, w, h);
                    }
                }
                else if (toolType == PaintTools.DrawLine) //선형 그리기
                {
                    g.DrawLine(pn, clickPoint.X, clickPoint.Y, e.X, e.Y);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpPoint.X = e.X;
                UpPoint.Y = e.Y;

                float w = Math.Abs(clickPoint.X - e.X);
                float h = Math.Abs(clickPoint.Y - e.Y);

                Pen pn = new Pen(Color.Black);
                pn.Width = 3;
                Rectangle rect = new Rectangle();
                Graphics g = pictureBox1.CreateGraphics();

                if (toolType == PaintTools.DrawRectangle) //사각형 그리기
                {
                    if (e.X > clickPoint.X)
                    {
                        if (e.Y > clickPoint.Y) rect = new Rectangle(clickPoint.X, clickPoint.Y, (int)w, (int)h);
                        else rect = new Rectangle(clickPoint.X, e.Y, (int)w, (int)h);
                    }
                    else
                    {
                        if (e.Y > clickPoint.Y) rect = new Rectangle(e.X, clickPoint.Y, (int)w, (int)h);
                        else rect = new Rectangle(e.X, e.Y, (int)w, (int)h);
                    }
                }
                else if (toolType == PaintTools.DrawCircle) //원형 그리기
                {
                    if (e.X > clickPoint.X)
                    {
                        if (e.Y > clickPoint.Y) rect = new Rectangle(clickPoint.X, clickPoint.Y, (int)w, (int)h);
                        else rect = new Rectangle(clickPoint.X, e.Y, (int)w, (int)h);
                    }
                    else
                    {
                        if (e.Y > clickPoint.Y) rect = new Rectangle(e.X, clickPoint.Y, (int)w, (int)h);
                        else rect = new Rectangle(e.X, e.Y, (int)w, (int)h);
                    }
                }
                else if (toolType == PaintTools.DrawLine) //선형 그리기
                {
                    rect = new Rectangle(clickPoint.X, clickPoint.Y, clickPoint.X + e.X, clickPoint.Y + e.Y);
                }

                //리스트에 Rectangle 정보, Tool Type 정보 저장하기
                listRect.Add(rect);
                listTool.Add(toolType);
                DrawBitmap();
            }
        }
        private void DrawBitmap()
        {
            if (OriginalBmp != null)
            {
                DrawBmp = (Bitmap)OriginalBmp.Clone();
                for (int i = 0; i < listRect.Count; i++)
                {
                    double wRatio = (double)OriginalBmp.Width / pictureBox1.Width;
                    double hRatio = (double)OriginalBmp.Height / pictureBox1.Height;
                    Rectangle rect = new Rectangle((int)(listRect[i].X * wRatio), (int)((listRect[i].Y) * hRatio),
                            (int)(listRect[i].Width * wRatio), (int)(listRect[i].Height * hRatio));
                    Pen pn = new Pen(Color.Black);
                    pn.Width = (float)(3 * wRatio);

                    using (Graphics g = Graphics.FromImage(DrawBmp))
                    {
                        if (listTool[i] == PaintTools.DrawRectangle) g.DrawRectangle(pn, rect);
                        else if (listTool[i] == PaintTools.DrawCircle) g.DrawEllipse(pn, rect);
                        else if (listTool[i] == PaintTools.DrawLine) g.DrawLine(pn, new Point(rect.X, rect.Y), new Point(rect.Width - rect.X, rect.Height - rect.Y));
                    }
                }
                pictureBox1.Image = DrawBmp;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (OriginalBmp != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                if (listRect.Count > 0 && DrawBmp != null)
                {
                    e.Graphics.DrawImage(DrawBmp, imgRect);
                }
                else
                {
                    e.Graphics.DrawImage(OriginalBmp, imgRect);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listRect.Count > 0)
            {
                //Undo 실행 취소
                //맨 마지막 list에 있던 거 temp에 저장하고 마지막 list 삭제
                tempRect.Add(listRect[listRect.Count - 1]);
                listRect.RemoveAt(listRect.Count - 1);
                tempTool.Add(listTool[listTool.Count - 1]);
                listTool.RemoveAt(listTool.Count - 1);
                pictureBox1.Refresh();
                DrawBitmap();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempRect.Count > 0)
            {
                //Redo 다시 실행
                //맨 마지막 temp에 있던 거 list에 저장하고 마지막 temp 삭제
                listRect.Add(tempRect[tempRect.Count - 1]);
                tempRect.RemoveAt(tempRect.Count - 1);
                listTool.Add(tempTool[tempTool.Count - 1]);
                tempTool.RemoveAt(tempTool.Count - 1);
                pictureBox1.Refresh();
                DrawBitmap();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Undo & Redo Shortcut 실행 취소 & 다시 실행 단축키
            if (e.Control && !e.Shift && e.KeyCode == Keys.Z)
            {
                //CTRL + Z : Undo 실행 취소
                if (listRect.Count > 0)
                {
                    //맨 마지막 list에 있던 거 temp에 저장하고 마지막 list 삭제
                    tempRect.Add(listRect[listRect.Count - 1]);
                    listRect.RemoveAt(listRect.Count - 1);
                    tempTool.Add(listTool[listTool.Count - 1]);
                    listTool.RemoveAt(listTool.Count - 1);
                    pictureBox1.Refresh();
                    DrawBitmap();
                }
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                //CTRL + SHIFT + Z : Redo 다시 실행
                if (tempRect.Count > 0)
                {
                    //맨 마지막 temp에 있던 거 list에 저장하고 마지막 temp 삭제
                    listRect.Add(tempRect[tempRect.Count - 1]);
                    tempRect.RemoveAt(tempRect.Count - 1);
                    listTool.Add(tempTool[tempTool.Count - 1]);
                    tempTool.RemoveAt(tempTool.Count - 1);
                    pictureBox1.Refresh();
                    DrawBitmap();
                }
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG 파일 (*.png)|*.png|모든 파일 (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DrawBmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PNG 파일 (*.png)|*.png|모든 파일 (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OriginalBmp = new Bitmap(openFileDialog.FileName);
                    DrawBmp = (Bitmap)OriginalBmp.Clone();
                    pictureBox1.Image = DrawBmp;
                    listRect.Clear();
                    listTool.Clear();
                }
            }
        }
    }
}
