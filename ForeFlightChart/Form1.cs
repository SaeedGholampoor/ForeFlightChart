// رسم هایی که میکنم دست آخر باید بیارمش روی بیت مپ

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ForeFlightChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //char(System.Text.Encoding.GetEncoding(0227))
            //0255---0227
            label1.Font = new Font("ESRI Weather", 20);

            label1.Text = ((char)0227).ToString();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            Pen pn = new Pen(Color.FromArgb(195, 195, 195));
            pn.DashStyle = DashStyle.Dash;
            Graphics e3 = PnlBase.CreateGraphics();
            for (int i = 0; i <= PnlBase.Height; i += 50)
            {
                if (i != PnlBase.Height)
                    e3.DrawLine(pn, new Point(0, i), new Point(PnlBase.Width, i));
                else
                    e3.DrawLine(pn, new Point(0, i - 1), new Point(PnlBase.Width, i - 1)); // برای خط آخر که نشان نمیده هست
            }
            for (int j = 0; j <= PnlBase.Width; j += 50)
            {
                if (j != PnlBase.Width)
                    e3.DrawLine(pn, new Point(j, 0), new Point(j, PnlBase.Height));
                else
                    e3.DrawLine(pn, new Point(j - 1, 0), new Point(j - 1, PnlBase.Height - 1));
            }

        }

        private void PnlBase_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
        }
        int _rotcount = 0;
        int _rotlog = 80;
        private void button2_Click(object sender, EventArgs e)
        {
            Font fn = new Font("ESRI Weather", 40,FontStyle.Bold);
            string text = ((char)0227).ToString();
            Graphics gr = PnlBase.CreateGraphics();
            GraphicsState st = gr.Save();
            gr.ResetTransform();
            if (_rotcount > 0)
            {
                _rotlog += 10;
                gr.RotateTransform(_rotlog);
                _rotcount++;
            }
            else
            {
                _rotlog += 10;
                gr.RotateTransform(_rotlog);
                _rotcount++;
            }
            gr.TranslateTransform((float)55, (float)50,MatrixOrder.Append);
            Pen blackPen = new Pen(Color.Black, 3);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, fn, new SolidBrush(Color.Black), 0, 0, sf);
            }
            gr.Restore(st);



        }
    }
}
