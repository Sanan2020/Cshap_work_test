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
using Leadtools;
using excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Drawing;

namespace test
{
    public partial class Form1 : Form
    {
        internal static Form2 form2;
        internal static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }
    

     
        // string MY_LICENSE_FILE = @"C:\LEADTOOLS22\Support\Common\License\LEADTOOLS.LIC";
        // string MY_DEVELOPER_KEY = "o8xPXu1T0paMbRbDS9FNk5KRN8AXLmsI5d253qlp7DM=";
        /* public void SetLicenseFileExample()
         {
             try {

                 //RasterSupport.SetLicense(MY_LICENSE_FILE, MY_DEVELOPER_KEY);
             bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);

             if (isLocked)
                 Console.WriteLine("Document support is locked");
             else
                 Console.WriteLine("Document support is unlocked");
             }
             catch (Exception e)
             {
                 //Console.WriteLine(e.Message);
                 MessageBox.Show(e.Message);

             }

         }*/
        private bool Expanded = false;
        private void btnExpander_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;
                //btnExpander.BackColor = Color.Red;
                panAddress.Height = 27;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow;
                //btnExpander.BackColor = Color.Green;
                panAddress.Height = 211;
            }
            Expanded = !Expanded;
        }
        private bool Expanded2 = false;
        private void btnExpander2_Click(object sender, EventArgs e)
        {
            if (Expanded2)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;
                //btnExpander.BackColor = Color.Red;
                panAddress2.Height =27;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow;
                //btnExpander.BackColor = Color.Green;
                panAddress2.Height = 211;
            }
            Expanded2 = !Expanded2;
        }
        private bool Expanded3 = false;
        private void btnExpander3_Click(object sender, EventArgs e)
        {
            if (Expanded3)
            {
                // btnExpander.Image = Properties.Resources.collapse_arrow;
                //btnExpander.BackColor = Color.Red;
                panAddress3.Height = 27;
            }
            else
            {
                //  btnExpander.Image = Properties.Resources.expand_arrow;
                //btnExpander.BackColor = Color.Green;
                panAddress3.Height = 211;
            }
            Expanded3 = !Expanded3;
        }
        //Panel myPanel = new Panel();
        public String license;
        public String key;
        String[] ls;
        String lscol;
        String rf;
        String rfile;
        List<String> list = new List<String>();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"C:\Users\Administrator\Downloads\poc\image\Gray-FN.jpg");
            //if มี
            // SetLicenseFileExample();

            //else if ไม่มี
            /* Form2 frm = new Form2();
             frm.Show();*/



            // Form2 frm = new Form2();
            // frm.Show();

            /* myPanel.Size = new Size(200, 200);
             myPanel.BackColor = Color.Gray;
             this.Controls.Add(myPanel); // เพิ่ม Panel เข้ากับ Container (ฟอร์มหรือหน้าต่าง)*/
            /////////////////////


            /*try {*/
            StreamReader streamread = new StreamReader("pathLicense.txt");
                while ((rfile = streamread.ReadLine()) != null)
                {
                    rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                    list.Add(rf);

                }
                streamread.Close();
            //Console.WriteLine("k "+list);
            if (list !=null)
            {
                RasterSupport.SetLicense(list[0].ToString(), System.IO.File.ReadAllText(list[1].ToString()));
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");

                    // Form1 frm = new Form1();
                    //frm.Show();
                    //this.Hide();
                }
                list.Clear();
            }
            /*}
            catch (Exception ex){
                MessageBox.Show(ex.Message);
                 Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }*/
           // MessageBox.Show(pictureBox1.Location.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
           // myPanel.Visible = false; // ซ่อน Panel

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  myPanel.Visible = true; // แสดง Panel

        }

        
        protected override void OnMouseWheel(MouseEventArgs e){
            //MessageBox.Show("m");

            //pictureBox1.Image = ZoomP

            if (e.Delta > 0)
            {
                //pictureBox1.Image = null;
                // ซูมอิน (เพิ่มขนาดภาพ)
                if (pictureBox1.Width < 4500 || pictureBox1.Width < 4500){ //กำหนดขอบเขตการขยายภาพ
                    pictureBox1.Width += (int)(pictureBox1.Width * 0.1);
                    pictureBox1.Height += (int)(pictureBox1.Height * 0.1);
                }
            }
            else if (e.Delta < 0)
            {
                //pictureBox1.Image = null;
                // ซูมเอาท์ (ลดขนาดภาพ)
                if (pictureBox1.Width > 400 || pictureBox1.Width > 400) { //กำหนดขอบเขตการลดภาพ
                    pictureBox1.Width -= (int)(pictureBox1.Width * 0.1);
                    pictureBox1.Height -= (int)(pictureBox1.Height * 0.1);
                }
                    
            }
            l_zoom.Text = "w "+pictureBox1.Width.ToString()+" h"+pictureBox1.Height.ToString();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("E");
        }
        int xPos;
        int yPos;
        bool Dragging;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           Dragging = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { 
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
               // Console.WriteLine("xPos " + xPos);
               // Console.WriteLine("yPos " + yPos);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging && c != null)
            {
                if (c.Top <= 300)
                {
                    c.Top = e.Y + c.Top - yPos;
                }
                else {
                    
                }
               c.Left = e.X + c.Left - xPos;

                Console.WriteLine("c.Top " + c.Top.ToString());
                Console.WriteLine("c.Left " + c.Left.ToString());
            }
            l_xy.Text = pictureBox1.Location.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Closing");
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            //pictureBox1.Location = new Point(0,0);
        }
        public void y() {
           // Console.WriteLine("start");
            l_get.Text = "FFFFF";
            trackBar1.Value = 0;
           // Console.WriteLine("end");
        }
        Form3 form3 = new Form3();
        private void button4_Click(object sender, EventArgs e)
        {
           Form3 form3 = new Form3();
            form3.ShowDialog();
            //timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            l_get.Text = "y";
            if (form3.stateF3 == true)
            {
                timer1.Stop();
            }
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            
        }
        
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public String folderPath;
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1Export f1ex = new Form1Export();
            f1ex.ShowDialog();
        }
    }
}
