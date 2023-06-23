using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Leadtools;
using Leadtools.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Leadtools.Demos;
//using Leadtools.Demos.Dialogs;
using Leadtools.Codecs;
using Leadtools.Svg;
using Xamarin;
using Xamarin.Forms.Core;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.Document;

namespace test
{
    public partial class Form5Viewer2 : Form
    {
        public Form5Viewer2()
        {
            InitializeComponent();
        }
       // public virtual Color BackColor { get; set; }
       /* protected override void OnLoad(EventArgs e)
           {
             if (!this.DesignMode)
                 InitDemo();

             base.OnLoad(e);
            ActiveItem_Example();
        }*/
        /* // LEADTOOLS control to view images
         private ImageViewer _imageViewer;

         private void InitDemo(){
            // InitImageViewer();
         }*/
        //
        // Summary:
        //     Gets or sets the background color for the control.
        //
        // Returns:
        //     A System.Drawing.Color that represents the background color of the control. The
        //     default is the value of the System.Windows.Forms.Control.DefaultBackColor property.
        
        private void InitImageViewer(){
           // ImageViewerVerticalViewLayout _imageViewer = new ImageViewerVerticalViewLayout { Columns = 1 };
            //_imageViewer.
            _imageViewer.BackColor = SystemColors.AppWorkspace;
            _imageViewer.Dock = DockStyle.Fill;
           

        }
       // private ImageViewer _imageViewer;
        private void Form5Viewer2_Load(object sender, EventArgs e)
        {
            RasterSupport.SetLicense(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC",
                    File.ReadAllText(@"C:\Users\Administrator\Downloads\licens\LEADTOOLS.LIC.KEY"));
            bool isLocked = RasterSupport.IsLocked(RasterSupportType.Document);
            if (isLocked)
                Console.WriteLine("Document support is locked");
            else
            {
                Console.WriteLine("Document support is unlocked");
            }

            DocumentFactoryLoadFromStreamExample();
        }
        public void DocumentFactoryLoadFromStreamExample()
        {
            // Get a stream to anything, in this case a file 
            // Note that the stream must be seekable 
            var fileName = Path.Combine(LEAD_VARS.ImagesDir, "Leadtools.pdf");
            using (var stream = File.OpenRead(fileName))
            {
                // We must keep the stream alive as long as the document is alive 
                var options = new LoadDocumentOptions();
                using (var document = DocumentFactory.LoadFromStream(stream, options))
                {
                    Console.WriteLine(document.Stream);
                    Console.WriteLine(document);
                    //pictureBox1.Image = document;
                    //PrintOutDocumentInfo(document);
                }
            }
        }
        public virtual ImageViewerItem ActiveItem { get; set; }

        public void ActiveItem_Example()
        {
            // Create the control
            // _imageViewer = new ImageViewer(_viewLayouts[1]);
            /*_imageViewer.BackColor = SystemColors.AppWorkspace;
            _imageViewer.Dock = DockStyle.Fill;*/

         
        }

        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\LEADTOOLS22\Resources\Images";
        }
    }
}
