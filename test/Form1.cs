﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // string MY_LICENSE_FILE = @"C:\LEADTOOLS22\Support\Common\License\LEADTOOLS.LIC";
       // string MY_DEVELOPER_KEY = "o8xPXu1T0paMbRbDS9FNk5KRN8AXLmsI5d253qlp7DM=";
        public void SetLicenseFileExample()
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
        }
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
        private void Form1_Load(object sender, EventArgs e)
        {

            SetLicenseFileExample();
            Form2 frm = new Form2();
            frm.Dispose();
            // Form2 frm = new Form2();
            // frm.Show();

            /* myPanel.Size = new Size(200, 200);
             myPanel.BackColor = Color.Gray;
             this.Controls.Add(myPanel); // เพิ่ม Panel เข้ากับ Container (ฟอร์มหรือหน้าต่าง)*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // myPanel.Visible = false; // ซ่อน Panel

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  myPanel.Visible = true; // แสดง Panel

        }
    }
}