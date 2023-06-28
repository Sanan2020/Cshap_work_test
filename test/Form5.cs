using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Document.Writer;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.Pdf;
using Leadtools.Svg;
using Spire.Pdf;
using static System.Resources.ResXFileRef;

namespace test
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DocumentRasterPageExample();
           // DocumentWriterExample();
           //PDFFileMergeWithExample();
           //PDFAddImagesExample();
            /* using (Converter converter = new Converter("image.jpg"))
             {
                 PdfConvertOptions options = new PdfConvertOptions();
                 converter.Convert("imageToPdf.pdf", options);
             }*/
        }
        public List<String> imagescol = new List<String>();
        RasterImage im;
        public void DocumentRasterPageExample()
        {
            // Input file name 
            var inputFileName = Path.Combine(LEAD_VARS.ImagesDir, "TEST.docx");

            // Output PDF file name 
            var outputFileName = Path.Combine(LEAD_VARS.ImagesDir, "out_Example.pdf");

            // Create a new instance of the LEADTOOLS Document Writer 
            var docWriter = new DocumentWriter();

            // Setup a new RasterCodecs object 
            using (var codecs = new RasterCodecs())
            {
                codecs.Options.RasterizeDocument.Load.Resolution = 300;

                // Get information on the page 
                double pageWidth;
                double pageHeight;
                using (var info = codecs.GetInformation(inputFileName, false, 1))
                {
                    // Get the size in inches, we need it for the empty page 
                    pageWidth = info.Document.PageWidth;
                    pageHeight = info.Document.PageHeight;
                }

                // Begin the document 
                docWriter.BeginDocument(outputFileName, DocumentFormat.Pdf);

                // Add the first page from SVG 
                var svgPage = new DocumentWriterSvgPage();
                using (svgPage.SvgDocument = codecs.LoadSvg(inputFileName, 1, null))
                {
                    // Add it 
                    docWriter.AddPage(svgPage);
                }

                // Add a second page as empty 
                var emptyPage = new DocumentWriterEmptyPage();
                emptyPage.Width = pageWidth;
                emptyPage.Height = pageHeight;
                docWriter.AddPage(emptyPage);

                // Finally, add a third page as an image 
                var rasterPage = new DocumentWriterRasterPage();
                using (rasterPage.Image = codecs.Load(inputFileName, 1))
                {
                    rasterPage.Image = null;
                    rasterPage.Image = im;
                    // Add it 
                    docWriter.AddPage(rasterPage);
                }
            }

            // Finally finish writing the HTML file on disk 
            docWriter.EndDocument();
        }
       
        public void PDFFileMergeWithExample()
        {
            string sourceFileName1 = Path.Combine(LEAD_VARS.ImagesDir, @"1.pdf");
            string sourceFileName2 = Path.Combine(LEAD_VARS.ImagesDir, @"2.pdf");
            string sourceFileName3 = Path.Combine(LEAD_VARS.ImagesDir, @"3.pdf");

            string destinationFileName = Path.Combine(LEAD_VARS.ImagesDir, @"Merged.pdf");

            // Merge 1 with (2, 3) and form destination 
            PDFFile pdfFile = new PDFFile(sourceFileName1);
            pdfFile.MergeWith(new string[] { sourceFileName2, sourceFileName2 }, destinationFileName);
        }

        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\Users\Administrator\Downloads\merged";
        }

        public void PDFAddImagesExample()//แทรกภาพเข้าไปบนหน้าเอกสาร
        {
            string srcFileName = Path.Combine(LEAD_VARS.ImagesDir, "leadtools.pdf"); ;
            string dstFileName = Path.Combine(LEAD_VARS.ImagesDir, @"out.pdf");
            string imageFileName = Path.Combine(LEAD_VARS.ImagesDir, "Cannon.jpg");

            var imagesData = new List<PDFImageData>();
            var codecs = new RasterCodecs();
            RasterImage image = codecs.Load(imageFileName);

            var file = new PDFFile(srcFileName);
            var imageData = new PDFImageData();

            var imagePositions = new List<PDFImagePosition>();
            var imagePosition = new PDFImagePosition();
            imagePosition.PageNumber = 5;
            imagePosition.Bounds = new PDFRect(250, 500, 350, 200);
            imagePositions.Add(imagePosition);

            imageData.Image = image;
            imageData.ImagePosition = imagePositions;

            imagesData.Add(imageData);

            file.AddImages(imagesData, dstFileName);
            image.Dispose();
            codecs.Dispose();
        }
        public List<String> image = new List<String>();
        public void DocumentWriterExample()
        {

            var inputFileName = Path.Combine(LEAD_VARS.ImagesDir, "test.docx");
            var outputFileName = Path.Combine(LEAD_VARS.ImagesDir, "Example.pdf");

            // Setup a new RasterCodecs object 
            var codecs = new RasterCodecs();
            codecs.Options.RasterizeDocument.Load.Resolution = 300;

            // Get the number of pages in the input document 
            var pageCount = codecs.GetTotalPages(inputFileName);

            // Create a new instance of the LEADTOOLS Document Writer 
            var docWriter = new DocumentWriter();

            // Change the PDF options 
            var pdfOptions = docWriter.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;
            pdfOptions.DocumentType = PdfDocumentType.PdfA;
            docWriter.SetOptions(DocumentFormat.Pdf, pdfOptions);

            // Create a new PDF document 
            Debug.WriteLine("Creating new PDF document: {0}", outputFileName);
            docWriter.BeginDocument(outputFileName, DocumentFormat.Pdf);

            // Loop through all the pages 
            for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
            {
                // Get the page as SVG 
                Debug.WriteLine("Loading page {0}", pageNumber);
                var page = new DocumentWriterSvgPage();
                page.SvgDocument = codecs.LoadSvg(inputFileName, pageNumber, null);

                // Add the page 
                Debug.WriteLine("Adding page {0}", pageNumber);
                docWriter.AddPage(page);

                page.SvgDocument.Dispose();
            }

            // Finally finish writing the PDF file on disk 
            docWriter.EndDocument();
            codecs.Dispose();
        }
    }
}
