using Leadtools;
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
        int round = 1;
        int round2 = 1;
        String[] ls;
        String lscol;
        String lscol2;
        String rf;
        String rfile;
        List<String> lid = new List<String>();
        List<String> list = new List<String>();
        List<String> list2 = new List<String>();
        private void btnExport_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                itemre.Add(listBox1.SelectedItems[i].ToString());
            }
            if (itemre.Count > 0){
                excel.Application objExcel1 = new excel.Application();
                objExcel1.Visible =false;
                objExcel1.WindowState = excel.XlWindowState.xlNormal;
                excel.Workbook objWorkbook1 = objExcel1.Workbooks.Add();
                excel.Worksheet objWorksheet1 = objWorkbook1.Worksheets.Add();
                    foreach (string n in itemre){   
                        objWorksheet1.Cells[round, 1] = round;
                        objWorksheet1.Cells[round, 2] = itemre[round - 1];
                        Console.WriteLine(round +" " + round);
                        Console.WriteLine(round +" " + itemre[round - 1]);
                        round++;
                    }
                    
                excel.Application objExcel = new excel.Application();
                objExcel.Visible = false;
                objExcel.WindowState = excel.XlWindowState.xlNormal;
                excel.Workbook objWorkbook = objExcel.Workbooks.Add();
                excel.Worksheet objWorksheet = objWorkbook.Worksheets.Add();
                foreach (string n in itemre){
                    StreamReader streamread = new StreamReader(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile\" + n + ".txt");
                    while ((rfile = streamread.ReadLine()) != null){
                        rf = rfile;                         //text = อ่านข้อความทีละบรรทัด
                        ls = rf.Split("=".ToCharArray());   //split ตัดข้อความ ตัดที่ = 
                        lid.Add(round2.ToString());
                        lscol = ls[0];
                        list.Add(lscol);
                        lscol2 = ls[1];
                        list2.Add(lscol2);
                    }
                    round2++;
                    Console.WriteLine("list " + list.Count);
                }
                for (int i = 1; i <= list.Count; i++)
                {
                    //row, colum = data
                    //objWorksheet.Cells[i,1] = i;
                    //objWorksheet.Cells[i,2] = "data";
                    objWorksheet.Cells[i, 1] = lid[i - 1];
                     objWorksheet.Cells[i, 2] = list[i - 1];
                     objWorksheet.Cells[i, 3] = list2[i - 1];
                    Console.WriteLine(lid[i - 1] + " " + list[i - 1]);
                }
                
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String savePath = saveFileDialog1.FileName;
                    objWorkbook1.SaveAs(savePath+"Profile");
                    objWorkbook1.Close();
                    objExcel1.Quit();

                    list.Clear();
                    objWorkbook.SaveAs(savePath+"Value");
                    objWorkbook.Close();
                    objExcel.Quit();

                    listBox1.SelectedItem = null;
                    itemre.Clear();
                    MessageBox.Show("Export profile success");
                    this.Dispose();
                }
            }
        }
    }
}
