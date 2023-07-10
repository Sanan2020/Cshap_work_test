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
    public partial class ProgressPopup : Form
    {
        public ProgressPopup()
        {
            InitializeComponent();
        }
        // สร้างเมธอดสำหรับการอัปเดตข้อความใน Popup
        public void UpdateProgress(string message)
        {
            lblProgress.Text = message;
        }
    }
}
