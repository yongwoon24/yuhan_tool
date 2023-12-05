using Emgu.CV;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ysjk;

namespace WindowsFormsRec
{
    public partial class Form1 : Form
    {
        Thread tUpdate;
        static public object RecodeLock = new object();
        VideoWriter videoWriter;
        struct TRecPara
        {
            public bool bNeedRecode;
            public Rectangle rRect;
            public int iFps;
        };
        TRecPara RecPara = new TRecPara { bNeedRecode = false };
        private ysjk.Form1 frm1;

        public Form1()
        {
            InitializeComponent();
            // Form에 키 이벤트 핸들러를 추가
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            tUpdate = new Thread(Update);
            tUpdate.Priority = ThreadPriority.Normal;
            tUpdate.Start();                     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            if (RecPara.bNeedRecode) label2.Text = "REC";
            else label2.Text = "STOP";
        }

        Stopwatch swRec = new Stopwatch();
        public void Update()
        {
            while (true)
            {
                Thread.Sleep(1);

                if (RecPara.bNeedRecode)
                {
                    if (!swRec.IsRunning) swRec.Start();
                    try
                    {
                        lock (RecodeLock)
                        {
                            if (videoWriter != null && videoWriter.IsOpened)
                            {
                                if (swRec.ElapsedMilliseconds > (1000 / RecPara.iFps))
                                {
                                    swRec.Restart();
                                    Bitmap bmp = new Bitmap(RecPara.rRect.Width, RecPara.rRect.Height, PixelFormat.Format24bppRgb);
                                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                                    {
                                        g.CopyFromScreen(RecPara.rRect.X, RecPara.rRect.Y, 0, 0, new Size(RecPara.rRect.Width, RecPara.rRect.Height));
                                    }
                                    Mat mat = Emgu.CV.BitmapExtension.ToMat(bmp);

                                    videoWriter.Write(mat);
                                }
                            }
                        }
                    }
                    catch
                    {
                        Debug.WriteLine("Error VideoWriter");
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void StartRecording()
        {
            button1.Enabled = false;

            RecPara.bNeedRecode = true;
            RecPara.rRect.X = 0;
            RecPara.rRect.Y = 0;
            RecPara.rRect.Width = Screen.PrimaryScreen.Bounds.Width;
            RecPara.rRect.Height = Screen.PrimaryScreen.Bounds.Height;
            RecPara.iFps = 30;

            string sPath = "C:\\Rec\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".mp4";
            if (!Directory.Exists(Path.GetDirectoryName(sPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(sPath));
            }
            string sFourcc = "H264";

            int iFourcc = VideoWriter.Fourcc(sFourcc[0], sFourcc[1], sFourcc[2], sFourcc[3]);

            videoWriter = new VideoWriter(sPath, iFourcc, RecPara.iFps, new Size(RecPara.rRect.Width, RecPara.rRect.Height), true);
            videoWriter.Set(VideoWriter.WriterProperty.Quality, 100);

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void StopRecording()
        {
            lock (RecodeLock)
            {
                try
                {
                    RecPara.bNeedRecode = false;
                    if (videoWriter != null)
                    {
                        videoWriter.Dispose();
                        MessageBox.Show("녹화가 중단되었습니다. 동영상이 저장되었습니다.");
                    }
                }
                catch
                {
                    Debug.WriteLine("Error videoWriter");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1 = new ysjk.Form1();
            frm1.Focus();
            tUpdate.Abort();
            tUpdate.Join();
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + R 키를 누르면 녹화 시작 또는 중단
            if (e.KeyCode == Keys.R && e.Control)
            {
                if (RecPara.bNeedRecode)
                {
                    StopRecording();
                }
                else
                {
                    StartRecording();
                }
            }
        }
    }
}
