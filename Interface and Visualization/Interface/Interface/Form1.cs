﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Second_Interface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
        }

        Graphics g;
        Pen xOy, gr, pt;
        int minX = 0, minY = -10, maxX = 30, maxY = 10, width, height;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                rLabel.Visible = true;
                mLabel.Visible = false;
                lyambdaLabel.Visible = false;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                rLabel.Visible = true;
                mLabel.Visible = false;
                lyambdaLabel.Visible = false;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                rLabel.Visible = false;
                mLabel.Visible = false;
                lyambdaLabel.Visible = true;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                rLabel.Visible = false;
                mLabel.Visible = true;
                lyambdaLabel.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void mLabel_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vbutton1_Click_1(object sender, EventArgs e)
        {
            width = GrafPanel.Width;
            height = GrafPanel.Height;
            g = GrafPanel.CreateGraphics();
            xOy = new Pen(Color.Black, 2F);
            gr = new Pen(Color.Black);
            pt = new Pen(Color.Red, 2F);
            g.RotateTransform(180F);
            g.TranslateTransform(-width, -height);
            g.Clear(Color.White);

            if (VradioButton4.Checked)
                create_dinamic_axes();
            if (VradioButton5.Checked)
            {
                label5.Text = "x= " + minX.ToString();
                label6.Text = "x= " + maxX.ToString();
                label7.Text = "y= " + minY.ToString();
                label8.Text = "y= " + maxY.ToString();
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                create_static_axes();
            }
            create_curve();
        }

        private void VisualizationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vbutton2_Click_1(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            g.Clear(Color.White);
            g.Dispose();
            xOy.Dispose();
            gr.Dispose();
            pt.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_dinamic_axes()
        {
            if (minX < 0 && maxX > 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX < 0 && maxX > 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX < 0 && maxX > 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, maxX * width / (maxX - minX), 0, maxX * width / (maxX - minX), height);
            }
            else if (minX >= 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (maxX <= 0 && minY < 0 && maxY > 0)
            {
                g.DrawLine(xOy, 0, Math.Abs(minY) * height / (maxY - minY), width, Math.Abs(minY) * height / (maxY - minY));
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
            else if (minX >= 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (minX >= 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, width - width / 75, 0, width - width / 75, height);
            }
            else if (maxX <= 0 && maxY <= 0)
            {
                g.DrawLine(xOy, 0, height - height / 75, width, height - height / 75);
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
            else if (maxX <= 0 && minY >= 0)
            {
                g.DrawLine(xOy, 0, height / 75, width, height / 75);
                g.DrawLine(xOy, width / 75, 0, width / 75, height);
            }
        }

        private void create_static_axes()
        {
            g.DrawLine(xOy, 0, height / 50, width, height / 50);
            g.DrawLine(xOy, width - width / 80, 0, width - width / 80, height);
        }

        private void create_curve()
        {
            //int count = 25;
            //double minimum = -7.07279; //TMethodOfGlobalSearch
            //double[,] points = { { 0, 0 }, { 10, -2.09768 }, { 17.4142, 0.587645 }, { 17.4142, 0.587645 }, { 23.5982, 0.213565 }, { 23.5982, 0.213565 }, { 23.5982, 0.213565 }, { 26.7259, -0.149626 }, { 26.7259, -0.149626 }, { 26.7259, -0.149626 }, { 28.3019, -7.07279 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 }, { 28.868, -5.98227 } };

            //double minimum = -7.06199; //TMonotoneMethod
            //int count = 150;
            //double[,] points = { { 0, 0 }, { 0.309986, 0.0738028 }, { 0.46542, 0.103979 }, { 0.621462, 0.126316 }, { 0.777127, 0.138509 }, { 0.932936, 0.138886 }, { 1.08874, 0.126185 }, { 1.2441, 0.0998127 }, { 1.40067, 0.0592856 }, { 1.55614, 0.00570141 }, { 1.71159, -0.0600482 }, { 1.86536, -0.135388 }, { 2.02104, -0.219883 }, { 2.17458, -0.308663 }, { 2.3281, -0.39983 }, { 2.47931, -0.488789 }, { 2.63628, -0.576699 }, { 2.79104, -0.655323 }, { 2.94577, -0.722368 }, { 3.09889, -0.774016 }, { 3.25315, -0.808232 }, { 3.40675, -0.821922 }, { 3.71451, -0.780346 }, { 4.02085, -0.641044 }, { 4.3323, -0.401826 }, { 4.64373, -0.0796509 }, { 4.80149, 0.106811 }, { 4.96373, 0.308627 }, { 5.25396, 0.677077 }, { 5.55169, 1.03286 }, { 5.8494, 1.32691 }, { 6.15155, 1.52458 }, { 6.45221, 1.59007 }, { 6.7527, 1.50549 }, { 7.05322, 1.26586 }, { 7.34806, 0.890242 }, { 7.50694, 0.638308 }, { 7.66042, 0.368385 }, { 7.81383, 0.0784216 }, { 7.96049, -0.211563 }, { 8.11451, -0.522553 }, { 8.26059, -0.816766 }, { 8.54457, -1.3607 }, { 8.69515, -1.62038 }, { 8.83795, -1.83985 }, { 9.11752, -2.17263 }, { 9.39709, -2.34837 }, { 9.67345, -2.34398 }, { 9.83447, -2.25515 }, { 10, -2.09768 }, { 10.2762, -1.69273 }, { 10.569, -1.09325 }, { 10.8617, -0.362332 }, { 11.1748, 0.49792 }, { 11.4769, 1.32839 }, { 11.7936, 2.11102 }, { 12.1102, 2.718 }, { 12.2706, 2.93442 }, { 12.433, 3.08067 }, { 12.5919, 3.14695 }, { 12.751, 3.13357 }, { 12.9101, 3.0387 }, { 13.0677, 2.86485 }, { 13.228, 2.6092 }, { 13.3845, 2.28726 }, { 13.5411, 1.90055 }, { 13.6913, 1.47604 }, { 13.854, 0.96776 }, { 14.0068, 0.455136 }, { 14.1595, -0.0792041 }, { 14.2999, -0.579111 }, { 14.454, -1.12572 }, { 14.593, -1.60591 }, { 14.8557, -2.44491 }, { 15.0268, -2.91835 }, { 15.1804, -3.27919 }, { 15.3338, -3.56825 }, { 15.4755, -3.76485 }, { 15.7706, -3.93492 }, { 16.0658, -3.76207 }, { 16.3508, -3.27185 }, { 16.6663, -2.39537 }, { 16.9818, -1.24239 }, { 17.1496, -0.552331 }, { 17.3369, 0.252015 }, { 17.6365, 1.54374 }, { 17.9579, 2.8201 }, { 18.116, 3.36423 }, { 18.2793, 3.84663 }, { 18.4425, 4.2339 }, { 18.6081, 4.51708 }, { 18.7714, 4.67855 }, { 18.9353, 4.71643 }, { 19.0992, 4.62675 }, { 19.2623, 4.41125 }, { 19.4273, 4.0686 }, { 19.5893, 3.61748 }, { 19.7513, 3.06283 }, { 19.9067, 2.4453 }, { 20.1123, 1.52429 }, { 20.3022, 0.598332 }, { 20.4921, -0.367315 }, { 20.6588, -1.21976 }, { 20.851, -2.17599 }, { 21.0121, -2.93015 }, { 21.1729, -3.61792 }, { 21.305, -4.12079 }, { 21.4741, -4.66689 }, { 21.6151, -5.02615 }, { 21.8803, -5.43647 }, { 22.1454, -5.47061 }, { 22.4243, -5.08834 }, { 22.6672, -4.42053 }, { 22.9638, -3.23292 }, { 23.2604, -1.72694 }, { 23.615, 0.313341 }, { 23.9299, 2.15179 }, { 24.0957, 3.0649 }, { 24.2715, 3.95342 }, { 24.4404, 4.70311 }, { 24.613, 5.34061 }, { 24.7855, 5.82661 }, { 24.9588, 6.14555 }, { 25.1354, 6.28382 }, { 25.312, 6.22664 }, { 25.4886, 5.97298 }, { 25.6648, 5.52932 }, { 25.8429, 4.89909 }, { 26.0176, 4.11987 }, { 26.1924, 3.203 }, { 26.3573, 2.23587 }, { 26.5392, 1.08514 }, { 26.7003, 0.0214328 }, { 26.8613, -1.05494 }, { 26.9941, -1.93367 }, { 27.1605, -2.99623 }, { 27.2879, -3.76351 }, { 27.5069, -4.94895 }, { 27.6486, -5.60264 }, { 27.7467, -5.9933 }, { 27.9072, -6.5119 }, { 28.0675, -6.86733 }, { 28.1496, -6.98275 }, { 28.3653, -7.06199 }, { 28.6443, -6.67661 }, { 28.8758, -5.95215 }, { 29.2172, -4.29096 }, { 29.5616, -2.06761 }, { 29.7597, -0.635159 }, { 30, 1.15689 } };

            double minimum = -5.30666; //TMethodOfPiyavsky
            int count = 149;
            double[,] points = { { 0, 0 }, { 5.91851, 1.38232 }, { 13.8431, 1.00305 }, { 21.7677, -5.30666 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 }, { 24.1151, 3.16752 } };

            //double minimum = -7.05899; //TMethodOfKushner
            //int count = 29;
            //double[,] points = { {0, 0}, {6.95447, 1.36138}, {17.8075, 2.24573}, {17.8075, 2.24573}, {28.1314, -6.96108}, {28.1314, -6.96108}, {28.2467, -7.05899}, {28.2467, -7.05899}, {28.4767, -6.9739}, {29.7713, -0.549013}, {29.7889, -0.418411}, {29.7889, -0.418411}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9072, 0.463969}, {29.9575, 0.840012}, {29.9575, 0.840012}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9798, 1.00625}, {29.9963, 1.12925} };

            PointF[] p = new PointF[count];

            if (VradioButton4.Checked)
            {
                for (int i = 0; i < count; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY)));
                    p[i] = poss;
                }

                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(p[i], new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                    }
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / (maxY - minY))), new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / (maxY - minY))), new Size(4, 4)));
                    }
                }
            }

            if (VradioButton5.Checked)
            {
                for (int i = 0; i < count; ++i)
                {
                    PointF poss = new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(Math.Abs(minY) * height / (maxY - minY) + points[i, 1] * height / (maxY - minY + 0.1)));
                    p[i] = poss;
                }
                if (VradioButton2.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(p[i], new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(p[i], new Size(4, 4)));
                    }
                }
                else if (VradioButton3.Checked)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (points[i, 1] == minimum)
                        {
                            g.FillEllipse(Brushes.Green, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / 50)), new Size(6, 6)));
                        }
                        else
                            g.FillEllipse(Brushes.Red, new RectangleF(new PointF((float)(width - (points[i, 0] - minX) * width / (maxX - minX)), (float)(height / 50)), new Size(4, 4)));
                    }
                }
            }

            g.DrawLines(gr, p);
        }


    }
}