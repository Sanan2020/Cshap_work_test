using System;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Controls;
using Leadtools;
//using Leadtools.Document.Viewer;

namespace test
{
    public partial class Form5Viewer : Form
    {
        public Form5Viewer()
        {
            InitializeComponent();
            this.Size = new Size(800, 800);
        }

        public void ImageViewer_Example()
        {
            // Create the form that holds the ImageViewer 
            new Form5Viewer().ShowDialog();
        }
        // LEADTOOLS ImageViewer to be used with this example 
       // private ImageViewer imageViewer;
        // Information label 
        private Label _label;

        protected override void OnLoad(EventArgs e)
        {
            // Create a panel to the top 
            var panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panel);

            // Add an "Example" button to the panel 
            var button = new Button();
            button.Text = "&Example";
            button.Click += (sender, e1) => Example();
            panel.Controls.Add(button);

            // Add a label to the panel 
            _label = new Label();
            _label.Top = button.Bottom;
            _label.Width = 800;
            _label.Text = "Example...";
            panel.Controls.Add(_label);

            // Create the image viewer taking the rest of the form 
            //_imageViewer = new ImageViewer();
            imageViewer.Dock = DockStyle.Fill;
            imageViewer.BackColor = Color.Bisque;
            this.Controls.Add(imageViewer);
            imageViewer.BringToFront();

            // Add Pan/Zoom interactive mode 
            // Click and drag to pan, CTRL-Click and drag to zoom in and out 
            //imageViewer.DefaultInteractiveMode = new ImageViewerPanZoomInteractiveMode();

            // Load an image 
           // using (var codecs = new RasterCodecs())
                //imageViewer.Image = codecs.Load(Path.Combine(LEAD_VARS.ImagesDir, "image1.cmp"));
            imageViewer.Image = new Bitmap("C:\\LEADTOOLS22\\Resources\\Images\\Ocr1.tif");
            base.OnLoad(e);
        }

        private void Example()
        {
            var panel2 = new Panel();
            panel2.Dock = DockStyle.Top;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panel2);
            // Example code goes here 
            // MessageBox.Show("Image");
            var button2 = new Button();
            button2.Text = "&Example";
            button2.Click += (sender, e1) => Example();
            panel2.Controls.Add(button2);
        }
        static class LEAD_VARS
        {
            public const string ImagesDir = @"C:\LEADTOOLS21\Resources\Images";
        }
        /* protected override void OnLoad(EventArgs e)
         {
             // Create a new image viewer instance 
            // ImageViewer imageViewer = new ImageViewer();
             // Set some properties 
             imageViewer.Dock = DockStyle.Fill;
             // Add it to the form 
             this.Controls.Add(imageViewer);
             // Load an image into it 
             imageViewer.Image = new Bitmap("C:\\LEADTOOLS22\\Resources\\Images\\Ocr1.tif");

             base.OnLoad(e);
         }*/
        private void Form5Viewer_Load(object sender, EventArgs e)
        {
            // Disable the example button, this should only run once 
            //exampleButton.Enabled = false;

           /*var view = documentViewer.view;
            // Get its image viewer 
            var imageViewer = view.ImageViewer;
            // Hook to the PostRender 
            imageViewer.PostRenderItem += (sender, e) =>
            {
                // Get the image viewer item for the page 
                var item = e.Item;

                // Get the current rectangle for the image 
                var bounds = imageViewer.GetItemViewBounds(item, ImageViewerItemPart.Image, false);

                // Build the text we want. The page number is the item index + 1 
                var pageNumber = imageViewer.Items.IndexOf(item) + 1;
                var text = "Page " + pageNumber.ToString();

                // Get the image transformation for this item 
                var transform = imageViewer.GetItemImageTransform(e.Item);

                // Apply it to the context 
                var gstate = e.Context.Save();
                using (var matrix = new System.Drawing.Drawing2D.Matrix(
                   (float)transform.M11,
                   (float)transform.M12,
                   (float)transform.M21,
                   (float)transform.M22,
                   (float)transform.OffsetX,
                   (float)transform.OffsetY))
                {
                    e.Context.MultiplyTransform(matrix);
                }

                // Render the text at the bottom of the bounds 
                var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom;
                var rc = new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
                TextRenderer.DrawText(e.Context, text, imageViewer.Font, rc, Color.White, Color.Black, flags);

                e.Context.Restore(gstate);
            };

            // Invalidate so our changes take effect the first time 
            view.Invalidate();*/
        }
    }
}
