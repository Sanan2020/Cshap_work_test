using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
           
        }
       
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.form1.y();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
