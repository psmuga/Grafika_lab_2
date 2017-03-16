using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GrafikaLab2
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private readonly System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 1);

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            g = pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.2a
            g.Clear(Color.Black);
            double alfa = 0;
            int srodekX = 200;
            int srodekY = 200;
            double dalfa = 0.0628;
            double r = 100;

            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(pen1, (float)(srodekX + r * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r * Math.Cos(alfa + dalfa * (i + 1))));
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //1.2b
            g.Clear(Color.Black);
            double alfa = 0;
            int srodekX = 200;
            int srodekY = 200;
            double dalfa = 3.6;
            double r = 100;

            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(pen1, (float)(srodekX + r * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r * Math.Cos(alfa + dalfa * (i + 1))));
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //1.3
            g.Clear(Color.Black);
            double alfa = 0;
            int srodekX = 200;
            int srodekY = 200;
            double dalfa = 0.0628;
            double r = 200;
            double r2 = 100;

            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(pen1, (float)(srodekX + r * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r * Math.Cos(alfa + dalfa * (i + 1))));
                g.DrawLine(pen1, (float)(srodekX + r * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r2 * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r2 * Math.Cos(alfa + dalfa * (i + 1))));
                g.DrawLine(pen1, (float)(srodekX + r2 * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r2 * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r * Math.Cos(alfa + dalfa * (i + 1))));
            }
            for (int j = 0; j < 1; j++)
            {
                r = r - 50;
                r2 = r2 - 50;
                for (int i = 0; i < 100; i++)
                {

                    g.DrawLine(pen1, (float)(srodekX + r * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r2 * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r2 * Math.Cos(alfa + dalfa * (i + 1))));
                    g.DrawLine(pen1, (float)(srodekX + r2 * Math.Sin(alfa + dalfa * i)), (float)(srodekY + r * Math.Cos(alfa + dalfa * i)), (float)(srodekX + r2 * Math.Sin(alfa + dalfa * (i + 1))), (float)(srodekY + r * Math.Cos(alfa + dalfa * (i + 1))));
                }
            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //2.2b
            g.Clear(Color.Black);
            int x = 0;
            int y = 250;

            float[] X = { x, y, y, x };
            float[] Y = { x, x, y, y };
            float[] XD = new float[4];
            float[] YD = new float[4];
            float SMU = 0.1F;
            float RMU = 1.0F - SMU;

            for (int i = 0; i < 20; i++)
            {
                float p1 = X[3];
                float p2 = Y[3];
                float p3 = X[0];
                float p4 = Y[0];
                g.DrawLine(pen1, p1 + 50, p2 + 50, p3 + 50, p4 + 50);
                for (int j = 0; j < 3; j++)
                {

                    float p7 = X[j];
                    float p8 = Y[j];
                    float p5 = X[j + 1];
                    float p6 = Y[j + 1];
                    g.DrawLine(pen1, p7 + 50, p8 + 50, p5 + 50, p6 + 50);

                    XD[j] = RMU * X[j] + SMU * X[j + 1];
                    YD[j] = RMU * Y[j] + SMU * Y[j + 1];
                }
                XD[3] = RMU * X[3] + SMU * X[0];
                YD[3] = RMU * Y[3] + SMU * Y[0];

                for (int j = 0; j < 4; j++)
                {
                    X[j] = XD[j];
                    Y[j] = YD[j];
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //1.4
            g.Clear(Color.Black);
            var p0 = new PointF(pictureBox1.Width/2,pictureBox1.Height/2);
            var spiral = Enumerable.Range(0, 270 * 10).AsParallel().AsOrdered().Select(archimedeanPoint);
            foreach (var p1 in spiral)
            {
                g.DrawLine(pen1,p0,p1);
                p0 = p1;

            } 

        }
        PointF archimedeanPoint(int degrees)
        {
            const double a = 1;
            const double b = 3;
            double t = -degrees * Math.PI / 180;
            double r = a + b * t;
            return new PointF { X = (float)(pictureBox1.Width / 2 + r * Math.Cos(t)), Y = (float)(pictureBox1.Height / 2 + r * Math.Sin(t)) };
        }

        PointF archimedeanPoint2(int degrees)
        {
            const double a = 1;
            const double b = 3;
            double t = -degrees * Math.PI / 180;
            double r = a + b * t;
            return new PointF { X = (float)(pictureBox1.Width / 2 + r * Math.Cos(t+5)), Y = (float)(pictureBox1.Height / 2 + r * Math.Sin(t+5)) };
        }
        PointF archimedeanPoint3(int degrees)
        {
            const double a = 1;
            const double b = 3;
            double t = -degrees * Math.PI / 180;
            double r = a + b * t;
            return new PointF { X = (float)(pictureBox1.Width / 2 + r * Math.Cos(t + 15)), Y = (float)(pictureBox1.Height / 2 + r * Math.Sin(t + 15)) };
        }
        PointF archimedeanPoint4(int degrees)
        {
            const double a = 1;
            const double b = 3;
            double t = -degrees * Math.PI / 180;
            double r = a + b * t;
            return new PointF { X = (float)(pictureBox1.Width / 2 + r * Math.Cos(t + 60)), Y = (float)(pictureBox1.Height / 2 + r * Math.Sin(t + 60)) };
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //1.5
            g.Clear(Color.Black);
            var p0 = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            var spiral = Enumerable.Range(0, 270 * 10).AsParallel().AsOrdered().Select(archimedeanPoint);
            foreach (var p1 in spiral)
            {
                g.DrawLine(pen1, p0, p1);
                p0 = p1;

            }
            var p2 = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            var spiral2 = Enumerable.Range(0, 270 * 10).AsParallel().AsOrdered().Select(archimedeanPoint2);
            foreach (var p1 in spiral2)
            {
                g.DrawLine(pen1, p2, p1);
                p2 = p1;

            }
            var p3 = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            var spiral3 = Enumerable.Range(0, 270 * 10).AsParallel().AsOrdered().Select(archimedeanPoint3);
            foreach (var p1 in spiral3)
            {
                g.DrawLine(pen1, p3, p1);
                p3 = p1;

            }
            var p4 = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            var spiral4 = Enumerable.Range(0, 270 * 10).AsParallel().AsOrdered().Select(archimedeanPoint4);
            foreach (var p1 in spiral4)
            {
                g.DrawLine(pen1, p4, p1);
                p4 = p1;

            }
        }

    }
}
