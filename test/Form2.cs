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
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

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


                /* StreamWriter streamwri = new StreamWriter("pathLicense.txt"); //bin/Debug
                 streamwri.WriteLine(license);
                 streamwri.WriteLine(key);
                 streamwri.Close();
                 Console.WriteLine("seve part seccess...");*/

                
                ////////////////////
                RasterSupport.SetLicense(textBox1.Text, System.IO.File.ReadAllText(textBox2.Text));
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");
                     //this.Hide();
                     Form1 frm = new Form1();
                     frm.Show();
                    this.Hide();
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
        String[] ls;
        String lscol;
        String rf;
        String rfile;
        List<String> list = new List<String>();
        private async void Form2_Load(object sender, EventArgs e)
        {
            //if มี license
            //เข้าสู่หน้าโปรแกรม



            /* RasterSupport.SetLicense(license, File.ReadAllText(key));
             bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
             if (isLocked)
                 Console.WriteLine("Document support is locked");
             else
             {
                 Console.WriteLine("Document support is unlocked");
                 this.Hide();
                 Form1 frm = new Form1();
                 frm.Show();
             }*/

            //else if ถ้าไม่มี
            //ทำการสร้าง part ไปยังที่อยู่ของ license
            
            StreamReader streamread = new StreamReader("pathLicense.txt");
            while ((rfile = streamread.ReadLine()) != null)
            {
                rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                list.Add(rf);
          
            }
           // textBox1.Text = list[0].ToString();
           // textBox2.Text = list[1].ToString();
            RasterSupport.SetLicense(list[0].ToString(), System.IO.File.ReadAllText(list[1].ToString()));
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
            {
                Console.WriteLine("Document support is unlocked");
               
                Form1 frm = new Form1();
               frm.Show();

                timer1.Start();
            }
            /*foreach (String dd in list) { 

                 Console.WriteLine(dd);
             }*/
           
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            //MessageBox.Show("dd");
            timer1.Stop();
        }
    }
}
