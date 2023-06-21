using System;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Controls;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
using static Leadtools.Documents.UI;
using Leadtools.Document;
using Spire.Xls.Core;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Leadtools.ImageProcessing.Core;
//using Leadtools.Document.Viewer;

namespace test
{
    public partial class Form5Viewer : Form
    {
        public Form5Viewer(){
            InitializeComponent();
        }
        private void Form5Viewer_Load(object sender, EventArgs e){
            panelImage.AutoScroll = true;
            panelImage.BorderStyle = BorderStyle.Fixed3D;
            piccenter.SizeMode = PictureBoxSizeMode.StretchImage;
            panelcenter.BorderStyle = BorderStyle.Fixed3D;

            //Licens
            RasterSupport.SetLicense(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC",
                    File.ReadAllText(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC.KEY"));
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
            {
                Console.WriteLine("Document support is unlocked");
            }
        }
        String selectImage;
        
        List<RasterImage> imagescol = new List<RasterImage>();
        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog ofd = new OpenFileDialog();
             ofd.Title = "";
             ofd.Multiselect = true;
             ofd.Filter = "All File |*.*";
             DialogResult dr = ofd.ShowDialog();
             if (dr == System.Windows.Forms.DialogResult.OK) {
                 String[] file = ofd.FileNames;
                 int x = 20;
                 int y = 20;
                 int maxHight = -1;//
                 foreach (string img in file) { 
                     PictureBox pic = new PictureBox();
                     pic.Image = Image.FromFile(img);
                     pic.Location = new Point(x, y);
                     pic.SizeMode = PictureBoxSizeMode.StretchImage;
                     x += pic.Width + 10;//
                     maxHight = Math.Max(pic.Height,maxHight);
                     if (x > this.ClientSize.Width - 100) {
                         x = 20;
                         y += maxHight + 10;
                     }
                     this.panelImage.Controls.Add(pic);
                 }
             }*/
            
            RasterCodecs codecs = new RasterCodecs();
            codecs.ThrowExceptionsOnInvalidImages = true;
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "";
            ofd.Multiselect = true;
            ofd.Filter = "All File |*.*";
            DialogResult dr = ofd.ShowDialog();
            int page = 0;
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                String[] file = ofd.FileNames;
                int x = 20;//ระวหว่าง panel
                int y = 20;//ระวหว่าง panel
                int maxWidth = -1;
                
                PictureBox pic2 = new PictureBox();
                foreach (string img in file){
                    page++;
                    PictureBox pic1 = new PictureBox();
                    RasterImage image = codecs.Load(Path.Combine(img));
                    imagescol.Add(image);
                    PictureBox pic = new PictureBox();
                    pic1.Height = 200;
                    pic1.Width = 170;
                    // pic1.Image = Image.FromFile(img);
                    using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[page-1], ConvertToImageOptions.None))
                    {
                         pic1.Image = new Bitmap(destImage1);
                    }
                    selectImage = page.ToString();
                    pic1.Location = new Point(x, y);
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic1.BorderStyle = BorderStyle.Fixed3D;
                    pic1.Name = page.ToString();
                    y += pic1.Height + 10;
                    maxWidth = Math.Max(pic1.Height, maxWidth);
                    if (x > this.ClientSize.Width - 100)
                    {
                        y = 20;
                        x += maxWidth + 100;
                    }
                    this.panelImage.Controls.Add(pic1);
                    Console.WriteLine(pic1.Location.X.ToString()+pic1.Location.Y.ToString());
                    Console.WriteLine(pic1.Name);
                    pic1.MouseClick += new MouseEventHandler(pic1_MouseClick);
                    Console.WriteLine(selectImage);
                    /*pic2.Image = Image.FromFile(img);
                    pic2.Location = new Point(x, y);
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic2.Name = "pic2";
                    y += pic2.Height + 10;
                    maxWidth = Math.Max(pic2.Height, maxWidth);
                    if (x > this.ClientSize.Width - 100)
                    {
                        y = 40;
                        x += maxWidth + 20;
                    }
                    this.panelImage.Controls.Add(pic2);
                    Console.WriteLine(pic2.Location.X.ToString() + pic2.Location.Y.ToString());
                    Console.WriteLine(pic2.Name);
                    pic2.MouseClick += new MouseEventHandler(pic1_MouseClick);*/
                    
                }
               // chang();
            }
        }
        void chang() {
            for (int i = 0; i<1; i++)
            {
                MinimumCommand command9 = new MinimumCommand();
                //Apply the Minimum filter. 
                command9.Dimension = 8;
                command9.Run(imagescol[0]);
                command9.Run(imagescol[2]);
            }
        }
        private void pic1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = (PictureBox)sender;
            /*if (pb.Name == "1")
            {*/
                //MessageBox.Show(pb.Name);
                using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[int.Parse(pb.Name)-1], ConvertToImageOptions.None))
                {
                    piccenter.Image = new Bitmap(destImage1);
                }
           // }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("ff");
        }
    }
}
