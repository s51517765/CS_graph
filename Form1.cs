using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_グラフ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] x1 = new double[100];
        double[] y1 = new double[100];
        double[] x2 = new double[100];
        double[] y2 = new double[100];
        double viewRate = 0.5;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                x1[i] = i * 0.5;
                y1[i] = Math.Sin((double)i / 20);
                x2[i] = i;
                y2[i] = Math.Sin((double)i / 10);

                chart1.Series["S1"].Points.AddXY(x1[i], y1[i]);
                chart1.Series["S2"].Points.AddXY(x1[i], y2[i]);
                chart2.Series["S2"].Points.AddXY(x2[i], y2[i]);
            }
 
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 90;
            chart2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart2.ChartAreas[0].AxisX.Interval = 20;
            chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
        
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            chart1.ChartAreas[0].CursorX.Interval = 0.001;
            chart1.ChartAreas[0].CursorY.Interval = 0.001;
            try
            {
                int x = (int)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                //  double y = Math.Sin((double)x / 0.5 / 20);

                int index = 0;
                for (int i = 0; i < y1.Length; i++)
                {
                    if (x - x1[i] < 0.1) break;
                    index = i;
                }

                chart1.ChartAreas[0].CursorX.Position = x;
                if (radioButtonS1.Checked)
                {
                    chart1.ChartAreas[0].CursorY.Position = y1[index];
                    label1.Text = "S1= " + y1[index].ToString("0.00");
                    chart1.ChartAreas[0].CursorX.LineColor = Color.Red;
                    chart1.ChartAreas[0].CursorY.LineColor = Color.Red;
                }
                else if (radioButtonS2.Checked)
                {
                    chart1.ChartAreas[0].CursorY.Position = y2[index];
                    label2.Text = "S2= " + y2[index].ToString("0.00");
                    chart1.ChartAreas[0].CursorX.LineColor = Color.Aqua;
                    chart1.ChartAreas[0].CursorY.LineColor = Color.Aqua;
                }
            }
            catch
            {
                //pass
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart1.Series["S1"].MarkerColor = Color.Red;
            }
            else
            {
                chart1.Series["S1"].MarkerColor = Color.Transparent;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Series["S2"].MarkerColor = Color.Aqua;
            }
            else
            {
                chart1.Series["S2"].MarkerColor = Color.Transparent;
            }
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            double maximum_C2 = chart2.ChartAreas[0].AxisX.Maximum; //現在の最大値を取得
            viewRate *= 0.5;
            chart2.ChartAreas[0].AxisX.Interval = 10;
            chart2.ChartAreas[0].AxisX.ScaleView.Size = maximum_C2*viewRate;
        }

        private void buttonShrink_Click(object sender, EventArgs e)
        {            
            double maximum_C2 = chart2.ChartAreas[0].AxisX.Maximum;
            viewRate *= 2;
            chart2.ChartAreas[0].AxisX.ScaleView.Size = maximum_C2 * viewRate;
        }
    }
}
