using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab11
{
    public partial class Nokta_Belirleyici : Form
    {
        Point _point;
        public Nokta_Belirleyici(Point p_point)
        {
            InitializeComponent();

            _point = p_point;
        }

        private void Nokta_Belirleyici_Load(object sender, EventArgs e)
        {
            StreamReader oku = new StreamReader(@"c:\prolab11\plaka-il.txt");
            string satir = oku.ReadLine();
            while (satir!=null)
            {
                comboBox1.Items.Add(satir);

                satir = oku.ReadLine();
            }
            oku.Close();
        }

        // ekle butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string text = comboBox1.Text.Split(',')[0];
            int plaka_kodu = Convert.ToInt32(text);

            StreamWriter yaz = new StreamWriter(@"c:\prolab11\plaka-point.txt", true);
            yaz.WriteLine(plaka_kodu + "," + _point.X + "," + _point.Y);
            yaz.Close();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
