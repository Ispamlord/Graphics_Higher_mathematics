using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphics_Least_squares
{
    public partial class Form1 : Form
    {
        private double[] x = new double[5] { 5, 7, 9, 11, 12 };
        private double[] y = new double[5] { 3, -2, -2, 4, 15 };
        private double[] z = new double[5];
        private double[] c = new double[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            
            LeastSquare Kv3 = new LeastSquare() { x = this.x, y = this.y, RowCount = 4, ColumCount = 4 };
            LeastSquare Kv2 = new LeastSquare() { x = this.x, y = this.y, RowCount = 3, ColumCount = 3 };
            LeastSquare Kv1 = new LeastSquare() { x = this.x, y = this.y, RowCount = 2, ColumCount = 2 };
            InterpolationLangrag lan = new InterpolationLangrag() { X = x, Y = y };
            //Kv3.LeastSquaresSolution3(1);
            //Kv2.LeastSquaresSolution2(1);
            Kv1.LeastSquaresSolution1(1);
            double g = x.Min();
            while (g < x.Max())
            {
                //this.chart1.Series[0].Points.AddXY(g, lan.DoAllActions(g));
                //this.chart1.Series[0].Points.AddXY(g, Kv3.LeastSquaresSolution3(g));
                //this.chart1.Series[0].Points.AddXY(g, Kv2.LeastSquaresSolution2(g));
                //this.chart1.Series[0].Points.AddXY(g, Kv1.LeastSquaresSolution1(g));
                g += 0.01;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                chart1.Series[i].Points.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            z[0] = double.Parse(textBox1.Text);
            z[1] = double.Parse(textBox2.Text);
            z[2] = double.Parse(textBox3.Text);
            z[3] = double.Parse(textBox4.Text);
            z[4] = double.Parse(textBox5.Text);
            c[0] = double.Parse(textBox6.Text);
            c[1] = double.Parse(textBox7.Text);
            c[2] = double.Parse(textBox8.Text);
            c[3] = double.Parse(textBox9.Text);
            c[4] = double.Parse(textBox10.Text);
            for(int i = 0; i < z.Length; i++)
            {
                this.chart1.Series[9].Points.AddXY(z[i], c[i]);
            }
            //InterpolationLangrag lan = new InterpolationLangrag() { X = x, Y = y };
            //SimpleInterpolation simple = new SimpleInterpolation();
            //Nueton nt = new Nueton() { MasX = x, MasY = y };
            //simple.DoAllActions(x, y);
            //Kv3.LeastSquaresSolution3(1);
            //Kv2.LeastSquaresSolution2(1);
            //Kv1.LeastSquaresSolution1(1);
            //double g = x.Min();
            //chart1.Series[0].Points.Clear();
            //while (g < x.Max())
            //{
            //    //this.chart1.Series[0].Points.AddXY(g, nt.DoAllActions(g));
            //    //this.chart1.Series[0].Points.AddXY(g, simple.Interpolation(g));
            //    //this.chart1.Series[0].Points.AddXY(g, lan.DoAllActions(g));
            //    //this.chart1.Series[0].Points.AddXY(g, Kv3.LeastSquaresSolution3(g));
            //    //this.chart1.Series[0].Points.AddXY(g, Kv2.LeastSquaresSolution2(g));
            //    //this.chart1.Series[0].Points.AddXY(g, Kv1.LeastSquaresSolution1(g));
            //    g += 0.01f;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeastSquare Kv1 = new LeastSquare() { x = z, y = c, RowCount = 2, ColumCount = 2 };
            Kv1.LeastSquaresSolution1(1);
            double g = x.Min();
            chart1.Series[0].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[0].Points.AddXY(g, Kv1.LeastSquaresSolution1(g));
                g += 0.01;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LeastSquare Kv3 = new LeastSquare() { x = z, y = c, RowCount = 4, ColumCount = 4 };
            Kv3.LeastSquaresSolution3(0);
            double g = x.Min();
            chart1.Series[2].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[2].Points.AddXY(g, Kv3.LeastSquaresSolution3(g));
                g += 0.01;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LeastSquare Kv2 = new LeastSquare() { x = z, y = c, RowCount = 3, ColumCount = 3 };
            Kv2.LeastSquaresSolution2(1);
            double g = x.Min();
            chart1.Series[1].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[1].Points.AddXY(g, Kv2.LeastSquaresSolution2(g));
                g += 0.01;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Nueton nt = new Nueton() { MasX = z, MasY = c };
            chart1.Series[3].Points.Clear();
            double g = x.Min();
            while (g < x.Max())
            {
                this.chart1.Series[3].Points.AddXY(g, nt.DoAllActions(g));
                g += 0.01;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Spline spline = new Spline();
            spline.spline(z, c);
            double g = x.Min();
            chart1.Series[5].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[5].Points.AddXY(g, spline.Interpolation(g));
                g += 0.01;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InterpolationLangrag lan = new InterpolationLangrag() { X = z, Y = c };
            double g = x.Min();
            chart1.Series[4].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[4].Points.AddXY(g, lan.DoAllActions(g));

                g += 0.01;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Spline spline = new Spline();
            spline.spline(z, c);
            double g = x.Min();
            chart1.Series[6].Points.Clear();
            while (g < x.Max())
            {
                this.chart1.Series[6].Points.AddXY(g, spline.dxFirst(g, 0.01));
                g += 0.01;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Spline spline = new Spline();
            spline.spline(z, c);
            double g = x.Min();
            chart1.Series[7].Points.Clear();
            while (g < x.Max()-0.1)
            {
                
                    this.chart1.Series[7].Points.AddXY(g, spline.dxSecond(g, 0.01));
                    g += 0.01;
                
            }
        }
            //public double hx(double x, double x1)
            //{
            //    return x1 - x;
            //}


            //public double dxFirst(double xi)
            //{
            //    int j = 0;
            //    while (j < x.Length - 1 && xi > x[j + 1])
            //    {
            //        j++;
            //    }
            //    double dx = xi - x[j];
            //    double h = hx(x[j], x[j + 1]);
            //    double dy = (fx(dx + h, j) - fx(dx - h, j)) / (2 * h);
            //    return dy;

            //}
            private void textBox15_TextChanged(object sender, EventArgs e)
            {

            }
        double f(double x)
        {
            return 5*Math.Pow(x,2);
        }
        private void button11_Click(object sender, EventArgs e)
        {

            
            this.chart1.Series[8].Points.Clear();
            double g = 3;
            while (g < 7)
            {
                ////double r = a + b * g + c * g * g + d * g *g * g;
                //this.chart1.Series[8].Points.AddXY(g, r);
                g += 0.01;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
    } 
