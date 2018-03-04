using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab11
{
    public partial class Form_Chart : Form
    {
        public Form_Chart()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Button btn = new Button();

            //btn.Left = e.X-15;
            //btn.Top = e.Y-15;

            //btn.Text = "X";
            //btn.BackColor = Color.Red;
            //btn.Size = new System.Drawing.Size(30, 30);

            //pictureBox1.Controls.Add(btn);

            //Nokta_Belirleyici nb = new Nokta_Belirleyici(new Point(e.X, e.Y));
            //nb.ShowDialog();            
        }


        // bu pencere kapatılırsa uygulama tamamen kapansın diye:
        private void Form_Chart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form_Chart_Load(object sender, EventArgs e)
        {

        }

        private void button_ciz_Click(object sender, EventArgs e)
        {
            Pen kalem = new Pen(Color.Red, 4);
            Graphics cizim = pictureBox1.CreateGraphics();
            
            // daire çizdirme
            cizim.DrawEllipse(kalem, new Rectangle(265, 300, 40, 40));
            cizim.DrawEllipse(kalem, new Rectangle(352, 400, 40, 40));
            cizim.DrawEllipse(kalem, new Rectangle(500, 350, 40, 40));
            cizim.DrawEllipse(kalem, new Rectangle(400, 600, 40, 40));

            // çizgi çizdirme
            cizim.DrawLine(kalem, new Point(265 + 20, 300 + 20), new Point(352 + 20, 400 + 20));
            cizim.DrawLine(kalem, new Point(352 + 20, 400 + 20), new Point(500 + 20, 350 + 20));
            cizim.DrawLine(kalem, new Point(500 + 20, 350 + 20), new Point(400 + 20, 600 + 20));
        }


    }
}
