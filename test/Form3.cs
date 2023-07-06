using Leadtools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form3 : Form
    {
        public bool stateF3 = false;
        public Form3()
        {
            InitializeComponent();
        }
        
        private void btnsend_Click(object sender, EventArgs e)
        {
            // Form1 f1 = SingeltonForm<Form1>.Instance;
            // Form1 f1 = new Form1();
            // f1.y();
            // Console.WriteLine(f1.GetL_get());
            // Form1 f1 = new Form1();
            /*using (popProcess pp = new popProcess(data))
            {
                pp.ShowDialog(this);
            }*/
        }
        void data() {
            for (int i =0;i<=500;i++) { 
                Thread.Sleep(10);
            }
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form1.form1.y();
            
        }
        public List<String> imagescol = new List<String>();
        private void Form3_Load(object sender, EventArgs e)
        {
            //obj();
            
        }
        class PF
        {
            public string name = "a";
        }
        void obj() {
             PF pF = new PF();
            Console.WriteLine(pF.name);
        }
        void list() {
            imagescol.Add("A");
            imagescol.Add("B");
            imagescol.Add("C");

            imagescol[1] = null;
            imagescol[1] = "DD";
            int r = imagescol.Count;
            for (int i = 0; i < r; i++)
            {
                //Console.Write(imagescol[i]);
                Console.WriteLine(imagescol[i]);
            }
        }
    }
}
