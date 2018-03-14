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

namespace Yazlab1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_watchPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        bool flag = false;

        private void button_basla_Click(object sender, EventArgs e)
        {
            
        }

        public void Watch()
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Filter = "*.zip*";
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName;
            fsw.Path = textBox_watchPath.Text;
            fsw.EnableRaisingEvents = true;

            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);

            ChangeReplaceFile();
        }

        string replaceFileName = "";

        void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            if (!flag)
            {
                if (e.Name == textBox_originalFileName.Text)
                {
                    flag = true;

                    if (replaceFileName != "")
                    {
                        string replaceFile = Path.Combine(textBox_watchPath.Text, replaceFileName);
                        while (!File.Exists(replaceFile))
                        {
                            ChangeReplaceFile();
                            replaceFile = Path.Combine(textBox_watchPath.Text, replaceFileName);
                        }

                        string fakeFileName = Path.Combine(textBox_watchPath.Text, "ornek_veri_dosyası_" + (new Random().Next(0, 100024) + replaceFileIndex).ToString() + ".xlsx");

                        File.Move(e.FullPath, fakeFileName);

                        if (File.Exists(e.FullPath))
                            return;

                        File.Move(replaceFile, e.FullPath);

                        Application.Exit();

                    }
                }
            }
        }


        int replaceFileIndex = 0;
        public void ChangeReplaceFile()
        {
            string[] replaceFiles = textBox_replaceFileNames.Text.Split(',');

            if (replaceFileIndex < replaceFiles.Length)
            {
                replaceFileName = replaceFiles[replaceFileIndex];
                replaceFileIndex++;
            }
            else
            {
                replaceFileName = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //notifyIcon1.MouseDoubleClick += new MouseEventHandler(MyIcon_MouseDoubleClick);
            notifyIcon1.Click += new EventHandler(MyIcon_MouseDoubleClick2);

            timer1.Start();
            
            Watch();
        }


        void MyIcon_MouseDoubleClick2(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            Hide();

            timer1.Stop();
        } 



    }
}
