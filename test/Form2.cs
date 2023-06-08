using Leadtools;
using Leadtools.Drawing;
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

namespace test
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public String license;
        public String key;
        public void SetLicenseFileExample()
        {
            try
            {
                /* string MY_LICENSE_FILE = @""+license+"";
                 string MY_DEVELOPER_KEY = ""+key+"";
                 RasterSupport.SetLicense(MY_LICENSE_FILE, MY_DEVELOPER_KEY);*/

                RasterSupport.SetLicense(license,File.ReadAllText(key));
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");
                    this.Hide();
                     Form1 frm = new Form1();
                     frm.Show();
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SetLicenseFileExample();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "File (*.LIC)|*.LIC;";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                license = ofile.FileName;
                Console.WriteLine(license);
                textBox1.Text = license;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "File (*.KEY)|*.KEY;";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                key = ofile.FileName;
                Console.WriteLine(key);
                textBox2.Text = key;
            }
        }
    }
}
