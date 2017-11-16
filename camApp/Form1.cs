using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace camApp
{
    public partial class Form1 : Form
    {
        VideoCapture capture;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            //if (capture == null)
            //    capture = new Emgu.CV.VideoCapture(0);
            capture = new VideoCapture(0);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 1280);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 720);
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture = null;
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Pause();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"D://test.jpg", ImageFormat.Jpeg);
        }
    }
}
