using Leadtools;
using Leadtools.Codecs;
using Leadtools.Ocr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.ImageProcessing;
using static System.Net.Mime.MediaTypeNames;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.Drawing;
using System.Drawing.Imaging;
using Leadtools.Dicom.Common.Extensions;

namespace test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        String rf;
        String rfile;
        List<String> list = new List<String>();
        private void Form4_Load(object sender, EventArgs e)
        {
            StreamReader streamread = new StreamReader("pathLicense.txt");
            while ((rfile = streamread.ReadLine()) != null)
            {
                rf = rfile;                        
                list.Add(rf);
            }
            streamread.Close();
            //Console.WriteLine("k "+list);
            if (list != null)
            {
                RasterSupport.SetLicense(list[0].ToString(), System.IO.File.ReadAllText(list[1].ToString()));
                bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
                if (isLocked)
                    Console.WriteLine("Document support is locked");
                else
                {
                    Console.WriteLine("Document support is unlocked");
                }
                list.Clear();
            }
        }
        RasterCodecs codecs = new RasterCodecs();
        private void btnSave_Click(object sender, EventArgs e)
        {
            codecs.ThrowExceptionsOnInvalidImages = true;
            String folderPath;
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                RasterImage image = codecs.Load(Path.Combine(folderPath));
                codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result1Bit.tif"), RasterImageFormat.Tif, 1);
                Console.WriteLine("1Bit save...");
            }
        }

        private void btnOCR_Click(object sender, EventArgs e)
        {
            codecs.ThrowExceptionsOnInvalidImages = true;
            String folderPath;
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                RasterImage image = codecs.Load(Path.Combine(folderPath));
                // Perform OCR on the preprocessed image
                using (IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD))
                {
                    ocrEngine.Startup(null, null, null, null);
                    //ocrEngine.LanguageManager.EnableLanguages(new[] { "Thai" });

                    using (IOcrPage ocrPage = ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose))
                    {
                        ocrPage.AutoZone(null);
                        ocrPage.Recognize(null);

                        string extractedText = ocrPage.GetText(-1);
                        System.Console.WriteLine("***************Start****************\r\n" + extractedText + "\r\n***************END****************");
                    }
                    ocrEngine.Shutdown();
                }
            }
        }
       
        private void btnConv_Click(object sender, EventArgs e)
        {
             codecs.ThrowExceptionsOnInvalidImages = true;
             String folderPath;
             OpenFileDialog ofile = new OpenFileDialog();
             ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
             if (DialogResult.OK == ofile.ShowDialog())
             {
                folderPath = ofile.FileName;
                RasterImage image = codecs.Load(Path.Combine(folderPath));
                AutoBinarizeCommand command = new AutoBinarizeCommand();
                command.Run(image);
               // codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result1Bit.tif"), RasterImageFormat.Tif, 1);
                codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "resultAutoBinarize.jpg"), RasterImageFormat.Jpeg, 24);
                Console.WriteLine(" AutoBinarize save...");
            }
        }
        

        private void btnSupConv_Click(object sender, EventArgs e)
        {
            //this.picInput.Image = new Bitmap(ofile.FileName);
            /* using (Image destImage1 = RasterImageConverter.ConvertToImage(image1, ConvertToImageOptions.None))
             {
                 picInput.Image = new Bitmap(destImage1);
                 //MessageBox.Show(destImage1.ToString());
             }*/
            //RasterImage image2 = codecs.Load(RasterImageFormat.Tif, 1);
            codecs.ThrowExceptionsOnInvalidImages = true;
            String folderPath;
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                RasterImage image = codecs.Load(Path.Combine(folderPath));
                /* RasterImage destImage = new RasterImage(
                    RasterMemoryFlags.Conventional,
                    image.Width,
                    image.Height,
                    image.BitsPerPixel,
                    image.Order,
                    image.ViewPerspective,
                    image.GetPalette(),
                    IntPtr.Zero,
                    0);
                 // Copy the data from the source image to the destination image 
                 image.Access();
                 destImage.Access();

                 byte[] buffer = new byte[image.BytesPerLine];

                 for (int y = 0; y < image.Height; y++)
                 {
                     image.GetRow(y, buffer, 0, buffer.Length);
                     destImage.SetRow(y, buffer, 0, buffer.Length);
                 }

                 destImage.Release();
                 image.Release();
                 // We do not need the source image anymore 
                 image.Dispose();
                 // save the destination image 
                 codecs.Save(destImage, @"C:\Users\Administrator\Downloads\out\qq.bmp", RasterImageFormat.Bmp, 24);*/
                // codecs.(destImage, RasterImageFormat, 1);
                // สร้าง RasterImage ใหม่เพื่อเก็บภาพ 1 บิต

                /*RasterImage destinationImage = new RasterImage(RasterMemoryFlags.Conventional, 1, 1, 1, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft);

                // ตั้งค่าคุณสมบัติการแปลงรูปภาพ
                var ditheringCommand = new DitheringCommand();
                ditheringCommand.DitheringMethod = DitheringMethod.FloydStein;
                ditheringCommand.OutputBpp = 1;
                ditheringCommand.OutputPalette = DitheringOutputPalette.BlackAndWhite;

                // แปลงรูปภาพเป็น 1 บิตโดยใช้เทคนิค Dithering
                ditheringCommand.Run(image, destinationImage);

                // ทำสิ่งอื่น ๆ กับรูปภาพ 1 บิตที่ได้ เช่น การบันทึกลงดิสก์หรือประมวลผลต่อไป

                // คืนค่าหน่วยความจำที่ใช้เก็บรูปภาพ
                destinationImage.Dispose();*/
            }

            //  codecs.Save(destImage, @"C:\Users\Administrator\Downloads\out\qq.bmp", RasterImageFormat.Bmp, 1);
            // codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result.tif"), RasterImageFormat.Tif, 1);
            /*  using (System.Drawing.Image destImage1 = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.None))
              {
                 //  codecs.Save(destImage1, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result.tif") RasterImageFormat.Tif, 1);
                // codecs.Convert(image, );
                 // destImage1.Save(@"C:\Users\Administrator\Downloads\out\result.tif", ImageFormat.Tiff);
                  // picOutput.Image = new Bitmap(destImage1);
                  //MessageBox.Show(destImage1.ToString());
              }*/
        }
        public void RasterImageExample()
        {
            RasterCodecs codecs = new RasterCodecs();

            string srcFileName = Path.Combine(LEAD_VARS.ImagesDir, "interlaced_footage.jpg");
            string destFileName1 = Path.Combine(LEAD_VARS.ImagesDir, "Image1_RasterImage1.bmp");
            string destFileName2 = Path.Combine(LEAD_VARS.ImagesDir, "Image1_RasterImage2.bmp");

            // Load the image 
            RasterImage srcImage = codecs.Load(srcFileName);

            // Creates a new image in memory with same dimensions as the source image 
            RasterImage destImage = new RasterImage(
               RasterMemoryFlags.Conventional,
               srcImage.Width,
               srcImage.Height,
               srcImage.BitsPerPixel,
               srcImage.Order,
               srcImage.ViewPerspective,
               srcImage.GetPalette(),
               IntPtr.Zero,
               0);

            // Copy the data from the source image to the destination image 
            srcImage.Access();
            destImage.Access();

            byte[] buffer = new byte[srcImage.BytesPerLine];

            for (int y = 0; y < srcImage.Height; y++)
            {
                srcImage.GetRow(y, buffer, 0, buffer.Length);
                destImage.SetRow(y, buffer, 0, buffer.Length);
            }

            destImage.Release();
            srcImage.Release();

            // We do not need the source image anymore 
            srcImage.Dispose();

            // save the destination image 
            codecs.Save(destImage, destFileName1, RasterImageFormat.Bmp, 24);

            // perform image processing on the image 

            FlipCommand flipCmd = new FlipCommand();
            flipCmd.Horizontal = false;
            flipCmd.Run(destImage);

            // save it 
            codecs.Save(destImage, destFileName2, RasterImageFormat.Bmp, 24);

            // Clean up 
            destImage.Dispose();
            codecs.Dispose();
        }

        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\LEADTOOLS22\Resources\Images";
        }
    }
}
