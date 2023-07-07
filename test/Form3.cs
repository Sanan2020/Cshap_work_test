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
        ProgressPopup popup = new ProgressPopup();
        private async void btnsend_Click(object sender, EventArgs e)
        {
            // Form1 f1 = SingeltonForm<Form1>.Instance;
            // Form1 f1 = new Form1();
            // f1.y();
            // Console.WriteLine(f1.GetL_get());

            // Form1 f1 = new Form1();
<<<<<<< HEAD
            /*using (popProcess pp = new popProcess(data))
            {
                pp.ShowDialog(this);
            }*/
<<<<<<< HEAD

            // สร้าง Popup
           
            popup.Show();

            // กระบวนการปรับแต่ง
            await ProcessConfiguration();

            // ปิด Popup เมื่อกระบวนการเสร็จสิ้น
            popup.Close();
            popup.Dispose();
            popup = null;
        }
      

        private async Task ProcessConfiguration()
        {
            // ทำกระบวนการปรับแต่งที่ต้องการ
            // คุณสามารถเรียกใช้เมธอดใน Popup เพื่ออัปเดตข้อความ
           
            popup.UpdateProgress("กำลังปรับแต่ง...");
            await Task.Delay(5000); // ตัวอย่างการทำงานในเวลา 5 วินาที

            // อัปเดตข้อความใน Popup
            
=======
=======


            /* using (popProcess pp = new popProcess(data))
             {
                 pp.ShowDialog(this);
             }*/

            /*Form form1 = new Form();
            Button button1 = new Button();
            button1.Text = "OK";
            button1.Location = new Point(10, 10);
            button1.DialogResult = DialogResult.OK;
            form1.Text = "My Dialog Box";
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.AcceptButton = button1;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Controls.Add(button1);
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                // Display a message box indicating that the OK button was clicked.
                MessageBox.Show("The OK button on the form was clicked.");
                // Optional: Call the Dispose method when you are finished with the dialog box.
                form1.Dispose();
            }*/
            DialogResult res = MessageBox.Show("New Profile Success", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (res == DialogResult.OK)
            {
                //MessageBox.Show("You have clicked Ok Button");
                //Some task…

            }
>>>>>>> update
>>>>>>> update
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

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            // แสดงกล่องข้อความหรือสถานะว่ากำลังปรับแต่ง
            lblStatus.Text = "กำลังปรับแต่ง...";

            // สร้าง Task เพื่อดำเนินการปรับแต่ง
            Task<bool> processTask = Task.Run(() =>
            {
                // ทำกระบวนการปรับแต่งที่ต้องการ
                // คืนค่า true หรือ false ตามผลลัพธ์ของกระบวนการ

                // ตัวอย่างกระบวนการปรับแต่ง
                Thread.Sleep(5000); // ทดสอบความล่าช้า ให้ทำงานเป็นเวลา 5 วินาที
                return true; // คืนค่าเป็น true เมื่อปรับแต่งเสร็จสิ้น
            });

            // รอให้ Task เสร็จสิ้น
            bool isProcessed = await processTask;

            // แสดงข้อความหรือสถานะตามผลลัพธ์ของกระบวนการ
            if (isProcessed)
            {
                lblStatus.Text = "ปรับแต่งเสร็จสิ้น";
            }
            else
            {
                lblStatus.Text = "เกิดข้อผิดพลาดในการปรับแต่ง";
            }
        }
    }
}
