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
using excel = Microsoft.Office.Interop.Excel;

namespace test
{
    public partial class Form1Export : Form
    {
        public Form1Export()
        {
            InitializeComponent();
        }
        List<String> item = new List<String>();
        private void Form1Export_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile");
            foreach (var fi in di.GetFiles("*.txt"))
            {
                //Console.WriteLine(fi.Name);
                string[] nm = fi.Name.Split('.');
                Console.WriteLine(nm[0]);
                listBox1.Items.Add(nm[0]);
                item.Add(nm[0]);
            }

            checkedListBox1.Items.Add("Excel");
           
        }
        List<String> itemre = new List<String>();
        private void btnExport_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog ofile = new OpenFileDialog();
          ofile.Filter = "Image File (*.txt)|*.txt;";
          ofile.Multiselect = true;
          ofile.Title = "Export profile";
          if (DialogResult.OK == ofile.ShowDialog())
          {
              folderPath += ofile.FileName;
              Console.WriteLine(folderPath + "\r\n");
          }*/
            int round = 1;
            String[] ls;
            String lscol;
            String lscol2;
            String rf;
            String rfile;
            List<String> list = new List<String>();
            List<String> list2 = new List<String>();
            /////////////////////////////
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                //Console.WriteLine(listBox1.SelectedItems[i]);
                itemre.Add(listBox1.SelectedItems[i].ToString());
                //listBox1.Items.Remove(listBox1.SelectedItems[i]);
                //Console.WriteLine(item[i].ToString());
            }

            if (itemre.Count > 0)
            {
                    foreach (string z in itemre)
                    {
                        Console.WriteLine("itemre " + z);
                        //item.Remove(z);
                    }
                    foreach (string n in itemre)
                    {

                    StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\"+n+".txt");
                    while ((rfile = streamread.ReadLine()) != null)
                    {
                        rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                        ls = rf.Split("=".ToCharArray());   //split ตัดข้อความ ตัดที่ = 
                        lscol = ls[0];
                        list.Add(lscol);
                        lscol2 = ls[1];
                        list2.Add(lscol2);
                    }
                    
                    foreach (string l in list)
                    {
                        Console.WriteLine(l);
                    }
                    //round += 1;
                }
                ////////////////////////////////
                excel.Application objExcel = new excel.Application();
                objExcel.Visible = true;
                objExcel.WindowState = excel.XlWindowState.xlNormal;

                excel.Workbook objWorkbook = objExcel.Workbooks.Add();

                excel.Worksheet objWorksheet = objWorkbook.Worksheets.Add();
                Console.WriteLine("list " + list.Count);
                
                for (int i = 1; i <= list.Count; i++)
                {
                    //row, colum = data
                    //objWorksheet.Cells[i,1] = i;
                    //objWorksheet.Cells[i,2] = "data";

                    objWorksheet.Cells[i, 1] = round;
                    objWorksheet.Cells[i, 2] = list[i - 1];
                    objWorksheet.Cells[i, 3] = list2[i - 1];
                    Console.WriteLine(i + " " + list[i - 1]);
                }

                list.Clear();
                objWorkbook.SaveAs(@"C:\profileValue.xlsx");
                objWorkbook.Close();
                objExcel.Quit();
            }

            
        }
    }
}
