using System;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Controls;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
//using static Leadtools.Documents.UI;
using Leadtools.Document;
using Spire.Xls.Core;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Leadtools.ImageProcessing.Core;
using Leadtools.Svg;
using Leadtools.ImageProcessing.Color;
//using Leadtools.Document.Viewer;

namespace test
{
    public partial class Form5Viewer : Form
    {
        public Form5Viewer(){
            InitializeComponent();
        }
        
        private void Form5Viewer_Load(object sender, EventArgs e){
           /* panelImage.AutoScroll = true;
            panelImage.BorderStyle = BorderStyle.FixedSingle;

            panelcenter.AutoScroll = true;
            piccenter.SizeMode = PictureBoxSizeMode.StretchImage;
            panelcenter.BorderStyle = BorderStyle.FixedSingle;*/

            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.SplitterWidth = 10; //ความกว้างของตัว split ค่าเดิม 4
            //splitContainer1.Width = 100;
            Console.WriteLine(splitContainer1.Panel2.Width);
            //Licens
           /* RasterSupport.SetLicense(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC",
                    File.ReadAllText(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC.KEY"));*/
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
        int pageCount;
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
            String[] file;

            if (dr == System.Windows.Forms.DialogResult.OK){
                file = ofd.FileNames;
                int x = 20;//ระวหว่าง panel
                int y = 20;//ระวหว่าง panel
                int maxWidth = -1;
                /**/
                //int w = 170 / 2;
                int w = 420 / 2;
                int x3 = (splitContainer1.Panel2.Width / 2) - w;
                
                //int x3 = 40;//ระวหว่าง panel
                int y3 = 20;//ระวหว่าง panel
                int maxWidth3 = -1;
                RasterCodecs _rasterCodecs = new RasterCodecs();
                //Load documents at 300 DPI for better viewing
                _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;
                /**/
               // int pageCount;
                foreach (string img in file){
                    /**/
                    
                    using (var imageInfo = _rasterCodecs.GetInformation(img, true)) //นับจำนวนเอกสาร
                    {
                        pageCount = imageInfo.TotalPages; //จำนวนเอกสาร
                    }
                    Console.WriteLine("Page "+pageCount);
                    l_numberPages.Text = pageCount.ToString() + " Page";
                    // Loads all the pages into the viewer
                    
                    for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                    {
                        // Load it as a raster image and add it
                        var rasterImage = _rasterCodecs.Load(img, pageNumber);
                        // this._imageViewer.Items.AddFromImage(rasterImage, 1);
                        //imagescol.Add(rasterImage);
                        PictureBox pic2 = new PictureBox();
                        using (Image destImage1 = RasterImageConverter.ConvertToImage(rasterImage, ConvertToImageOptions.None))
                        {
                            pic2.Image = new Bitmap(destImage1); 
                        }
                        imagescol.Add(rasterImage);
                        pic2.Height = 200;
                        pic2.Width = 170;
                        selectImage = pageNumber.ToString();
                        pic2.Location = new Point(x, y);
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic2.BorderStyle = BorderStyle.FixedSingle;
                        pic2.Name = pageNumber.ToString();
                        y += pic2.Height + 10;
                        maxWidth = Math.Max(pic2.Height, maxWidth);
                        if (x > this.ClientSize.Width - 100)
                        {
                            y = 20;
                            x += maxWidth + 100;
                        }
                        //this.panelImage.Controls.Add(pic2);
                        this.splitContainer1.Panel1.Controls.Add(pic2);
                        //Console.WriteLine(pic2.Location.X.ToString() + pic2.Location.Y.ToString());
                        Console.WriteLine(pic2.Name);
                        pic2.MouseClick += new MouseEventHandler(pic1_MouseClick);

                       /* PictureBox pic3 = new PictureBox();
                        using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[0], ConvertToImageOptions.None))
                        {
                            // piccenter.Image = new Bitmap(destImage1);

                            pic3.Image = new Bitmap(destImage1);

                        }
                        pic3.Height = 600; //ความกว้างหน้ากระดาษ
                        pic3.Width = 420;  //ความสูงหน้ากระดาษ

                        pic3.Location = new Point(x3, y3);
                        pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic3.BorderStyle = BorderStyle.FixedSingle;

                        y3 += pic3.Height + 10; //ระยะห่างระหว่างหน้า
                        maxWidth3 = Math.Max(pic3.Height, maxWidth3);
                        if (x3 > this.ClientSize.Width - 100)
                        {
                            y3 = 20;
                            x3 += maxWidth3 + 100;
                        }
                        //this.panelcenter.Controls.Add(pic3);
                        this.splitContainer1.Panel2.Controls.Add(pic3);*/
                    }
                    /**/

                    /* page++; //เจอหน้าเดียว
                     Console.WriteLine("P " + page);
                     PictureBox pic1 = new PictureBox();
                     //pic1.Image = Image.FromFile(img); //เฉพาะไฟล์ภาพ
                     RasterImage image = codecs.Load(Path.Combine(img));
                     imagescol.Add(image);
                     using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[page-1], ConvertToImageOptions.None)){
                       pic1.Image = new Bitmap(destImage1);
                     }
                     pic1.Height = 200;
                     pic1.Width = 170;
                     selectImage = page.ToString();
                     pic1.Location = new Point(x, y);
                     pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                     pic1.BorderStyle = BorderStyle.FixedSingle;
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
                     Console.WriteLine(selectImage);*/
                }
                // chang();
            }
        }
        void chang() {
            int w = 420 / 2;
            int x3 = (splitContainer1.Panel2.Width / 2) - w;

            //int x3 = 40;//ระวหว่าง panel
            int y3 = 20;//ระวหว่าง panel
            int maxWidth3 = -1;

            //int munberImagescol = Convert.ToInt32(imagescol);
            //Console.WriteLine("munberImagescol: " + munberImagescol);
            for (int i = 1; i<=pageCount; i++)
            {
                /*MinimumCommand command9 = new MinimumCommand();
                //Apply the Minimum filter. 
                command9.Dimension = 8;
                command9.Run(imagescol[i-1]);*/

                PictureBox pic3 = new PictureBox();
                using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[i-1], ConvertToImageOptions.None))
                {
                    // piccenter.Image = new Bitmap(destImage1);
                    pic3.Image = new Bitmap(destImage1);
                }
                pic3.Height = 600; //ความกว้างหน้ากระดาษ
                pic3.Width = 420;  //ความสูงหน้ากระดาษ

                pic3.Location = new Point(x3, y3);
                pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic3.BorderStyle = BorderStyle.FixedSingle;

                y3 += pic3.Height + 10; //ระยะห่างระหว่างหน้า
                maxWidth3 = Math.Max(pic3.Height, maxWidth3);
                if (x3 > this.ClientSize.Width - 100)
                {
                    y3 = 20;
                    x3 += maxWidth3 + 100;
                }
                //this.panelcenter.Controls.Add(pic3);
                this.splitContainer1.Panel2.Controls.Add(pic3);
            }
        }
        private void pic1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = (PictureBox)sender;
            /*if (pb.Name == "1")
            {*/
            //MessageBox.Show(pb.Name);
            ContrastBrightnessIntensityCommand command = new ContrastBrightnessIntensityCommand();
            //Increase the brightness by 25 percent  of the possible range. 
            command.Brightness = 484;   //484
            command.Contrast = 394;     //394
            command.Intensity = 118;    //118
            command.Run(imagescol[int.Parse(pb.Name) - 1]);
            //PictureBox pic3 = new PictureBox();
            using (Image destImage1 = RasterImageConverter.ConvertToImage(imagescol[int.Parse(pb.Name)-1], ConvertToImageOptions.None)){
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
