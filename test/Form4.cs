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
using System.Reflection.Emit;

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
            //
           /* string[] arr = Directory.GetFiles(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile", "*.txt");
            foreach (string file in arr)
            {
                Console.WriteLine(file);
            }*/

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrator\source\repos\project1\project1\bin\profile");
            foreach (var fi in di.GetFiles("*.txt"))
            {
                //Console.WriteLine(fi.Name);
                string[] nm = fi.Name.Split('.');
                Console.WriteLine(nm[0]);
            }
        }
        RasterCodecs codecs = new RasterCodecs();
        public String folderPath;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            codecs.ThrowExceptionsOnInvalidImages = true;
            
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File (*.bmp,*.tif,*.pdf,*.jpg, *.png)|*.bmp;*.tif;*.pdf;*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                folderPath = ofile.FileName;
                RasterImage image = codecs.Load(Path.Combine(folderPath));
                Console.WriteLine("btnOpen " + image.BitsPerPixel);
                using (System.Drawing.Image destImage1 = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.None))
                {
                    picInput.Image = new Bitmap(destImage1);
                    //MessageBox.Show(destImage1.ToString());
                }
               // Console.WriteLine("Input " + ChangeCommand().BitsPerPixel);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            //codecs.ThrowExceptionsOnInvalidImages = true;
            using (System.Drawing.Image destImage1 = RasterImageConverter.ConvertToImage(ChangeCommand(), ConvertToImageOptions.None))
            {
                pic1bit.Image = new Bitmap(destImage1);
                codecs.Save(ChangeCommand(), Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result1.tif"), RasterImageFormat.Tif, 1);
                //MessageBox.Show(destImage1.ToString());
            }
            Console.WriteLine("Convert " + ChangeCommand().BitsPerPixel);
            // codecs.ThrowExceptionsOnInvalidImages = true;
            //AutoBinarizeCommand command = new AutoBinarizeCommand();
            //command.Run(image);

            // Create a new 4-bit image. 
            /*
              Console.WriteLine("output " + image.BitsPerPixel);
              Console.WriteLine("output " + destImage.BitsPerPixel);
              //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result1Bit.tif"), RasterImageFormat.Tif, 1);
              Console.WriteLine("1Bit save...");*/
            l_await.Text = "Test";
            await Task.Delay(2000);
            l_await.Text = "";
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
               //codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "result1Bit.tif"), RasterImageFormat.Tif, 1);
                codecs.Save(image, Path.Combine(@"C:\Users\Administrator\Downloads\out\", "resultAutoBinarize.jpg"), RasterImageFormat.Jpeg, 1);
                Console.WriteLine(" AutoBinarize save...");
            }
        }

        public RasterImage ChangeCommand() {
            codecs.ThrowExceptionsOnInvalidImages = true;
            RasterImage image = codecs.Load(Path.Combine(folderPath), 24, CodecsLoadByteOrder.Bgr, 1, 1);
            if (AutoBinarize.Checked == true) {
                AutoBinarizeCommand Binarize = new AutoBinarizeCommand();
                Binarize.Run(image);
            }
            if (AutoColorLevel.Checked == true)
            {
                AutoColorLevelCommand ColorLevel = new AutoColorLevelCommand();
                ColorLevel.Run(image);
            }
            if (GrayScale.Checked == true)
            {
                GrayScaleExtendedCommand command5 = new GrayScaleExtendedCommand();
                command5.RedFactor = 500;
                command5.GreenFactor = 250;
                command5.BlueFactor = 250;
                command5.Run(image);
            }
            using (System.Drawing.Image destImage1 = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.None))
            {
                picOutput.Image = new Bitmap(destImage1);
                //MessageBox.Show(destImage1.ToString());
            }

            RasterImage destImage = new RasterImage(
                   RasterMemoryFlags.Conventional,
                   image.Width,
                   image.Height,
                   1,
                   image.Order,
                   image.ViewPerspective,
                   image.GetPalette(),
                   IntPtr.Zero,
                   0);
            int bufferSize = RasterBufferConverter.CalculateConvertSize(
               image.Width,
               image.BitsPerPixel,
               destImage.Width,
               destImage.BitsPerPixel);

            // Allocate the buffer in unmanaged memory 
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
             //Assert.IsFalse(buffer == IntPtr.Zero);

            // Process each row from srcImage to destImage. 
            image.Access();
            destImage.Access();
            for (int i = 0; i < image.Height; i++)
            {
                image.GetRow(i, buffer, image.BytesPerLine);
                RasterBufferConverter.Convert(
                   buffer,
                   image.Width,
                   image.BitsPerPixel,
                   destImage.BitsPerPixel,
                   image.Order,
                   destImage.Order,
                   null,
                   null,
                   0,
                   8,
                   0,
                   RasterConvertBufferFlags.None);
                destImage.SetRow(i, buffer, destImage.BytesPerLine);
            }

            destImage.Release();
            image.Release();
            Marshal.FreeHGlobal(buffer); // Clean up 

            return destImage;
        }
        public class fcchange
        {
            public void change1() { 
                
            }
        }
        private void btnSupConv_Click(object sender, EventArgs e)
        {
            fcchange fc =new fcchange();
            fc.change1();
        }

        private async void AutoBinarize_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(AutoBinarize.Checked.ToString());
            if (AutoBinarize.Checked == true) {
                ChangeCommand();
                }
            l_await.Text = "await";
            await Task.Delay(2000);
            l_await.Text = "";
        }

        private  async void AutoColorLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoColorLevel.Checked == true)
            {
                ChangeCommand();
            }
            l_await.Text = "await";
            await Task.Delay(2000);
            l_await.Text = "";
        }

        private void GrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (GrayScale.Checked == true)
            {
                ChangeCommand();
            }
        }
    }
}
