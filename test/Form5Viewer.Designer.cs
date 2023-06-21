namespace test
{
    partial class Form5Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelImage = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.llToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piccenter = new System.Windows.Forms.PictureBox();
            this.panelcenter = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccenter)).BeginInit();
            this.panelcenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelImage
            // 
            this.panelImage.Location = new System.Drawing.Point(5, 25);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(221, 504);
            this.panelImage.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.llToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // llToolStripMenuItem
            // 
            this.llToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lToolStripMenuItem});
            this.llToolStripMenuItem.Name = "llToolStripMenuItem";
            this.llToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.llToolStripMenuItem.Text = "File";
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lToolStripMenuItem.Text = "open";
            this.lToolStripMenuItem.Click += new System.EventHandler(this.lToolStripMenuItem_Click);
            // 
            // piccenter
            // 
            this.piccenter.Location = new System.Drawing.Point(3, 1);
            this.piccenter.Name = "piccenter";
            this.piccenter.Size = new System.Drawing.Size(536, 499);
            this.piccenter.TabIndex = 3;
            this.piccenter.TabStop = false;
            this.piccenter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // panelcenter
            // 
            this.panelcenter.Controls.Add(this.piccenter);
            this.panelcenter.Location = new System.Drawing.Point(232, 26);
            this.panelcenter.Name = "panelcenter";
            this.panelcenter.Size = new System.Drawing.Size(542, 503);
            this.panelcenter.TabIndex = 4;
            // 
            // Form5Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 531);
            this.Controls.Add(this.panelcenter);
            this.Controls.Add(this.panelImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5Viewer";
            this.Text = "Form5Viewer";
            this.Load += new System.EventHandler(this.Form5Viewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccenter)).EndInit();
            this.panelcenter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem llToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.PictureBox piccenter;
        private System.Windows.Forms.Panel panelcenter;
    }
}