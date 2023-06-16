namespace test
{
    partial class Form4
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOCR = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSupConv = new System.Windows.Forms.Button();
            this.picInput = new System.Windows.Forms.PictureBox();
            this.AutoBinarize = new System.Windows.Forms.RadioButton();
            this.AutoColorLevel = new System.Windows.Forms.RadioButton();
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.pic1bit = new System.Windows.Forms.PictureBox();
            this.l_await = new System.Windows.Forms.Label();
            this.GrayScale = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1bit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(833, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "1 bit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOCR
            // 
            this.btnOCR.Location = new System.Drawing.Point(1089, 606);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(75, 23);
            this.btnOCR.TabIndex = 1;
            this.btnOCR.Text = "button";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(327, 528);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSupConv
            // 
            this.btnSupConv.Location = new System.Drawing.Point(1089, 577);
            this.btnSupConv.Name = "btnSupConv";
            this.btnSupConv.Size = new System.Drawing.Size(75, 23);
            this.btnSupConv.TabIndex = 3;
            this.btnSupConv.Text = "button1";
            this.btnSupConv.UseVisualStyleBackColor = true;
            this.btnSupConv.Click += new System.EventHandler(this.btnSupConv_Click);
            // 
            // picInput
            // 
            this.picInput.Location = new System.Drawing.Point(12, 12);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(423, 479);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInput.TabIndex = 4;
            this.picInput.TabStop = false;
            // 
            // AutoBinarize
            // 
            this.AutoBinarize.AutoSize = true;
            this.AutoBinarize.Location = new System.Drawing.Point(507, 528);
            this.AutoBinarize.Name = "AutoBinarize";
            this.AutoBinarize.Size = new System.Drawing.Size(84, 17);
            this.AutoBinarize.TabIndex = 5;
            this.AutoBinarize.TabStop = true;
            this.AutoBinarize.Text = "AutoBinarize";
            this.AutoBinarize.UseVisualStyleBackColor = true;
            this.AutoBinarize.CheckedChanged += new System.EventHandler(this.AutoBinarize_CheckedChanged);
            // 
            // AutoColorLevel
            // 
            this.AutoColorLevel.AutoSize = true;
            this.AutoColorLevel.Location = new System.Drawing.Point(507, 551);
            this.AutoColorLevel.Name = "AutoColorLevel";
            this.AutoColorLevel.Size = new System.Drawing.Size(97, 17);
            this.AutoColorLevel.TabIndex = 6;
            this.AutoColorLevel.TabStop = true;
            this.AutoColorLevel.Text = "AutoColorLevel";
            this.AutoColorLevel.UseVisualStyleBackColor = true;
            this.AutoColorLevel.CheckedChanged += new System.EventHandler(this.AutoColorLevel_CheckedChanged);
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(441, 12);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(386, 479);
            this.picOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOutput.TabIndex = 7;
            this.picOutput.TabStop = false;
            // 
            // pic1bit
            // 
            this.pic1bit.Location = new System.Drawing.Point(833, 12);
            this.pic1bit.Name = "pic1bit";
            this.pic1bit.Size = new System.Drawing.Size(343, 479);
            this.pic1bit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1bit.TabIndex = 8;
            this.pic1bit.TabStop = false;
            // 
            // l_await
            // 
            this.l_await.AutoSize = true;
            this.l_await.Location = new System.Drawing.Point(569, 616);
            this.l_await.Name = "l_await";
            this.l_await.Size = new System.Drawing.Size(35, 13);
            this.l_await.TabIndex = 9;
            this.l_await.Text = "label1";
            // 
            // GrayScale
            // 
            this.GrayScale.AutoSize = true;
            this.GrayScale.Location = new System.Drawing.Point(507, 580);
            this.GrayScale.Name = "GrayScale";
            this.GrayScale.Size = new System.Drawing.Size(74, 17);
            this.GrayScale.TabIndex = 10;
            this.GrayScale.TabStop = true;
            this.GrayScale.Text = "GrayScale";
            this.GrayScale.UseVisualStyleBackColor = true;
            this.GrayScale.CheckedChanged += new System.EventHandler(this.GrayScale_CheckedChanged);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 635);
            this.Controls.Add(this.GrayScale);
            this.Controls.Add(this.l_await);
            this.Controls.Add(this.pic1bit);
            this.Controls.Add(this.picOutput);
            this.Controls.Add(this.AutoColorLevel);
            this.Controls.Add(this.AutoBinarize);
            this.Controls.Add(this.picInput);
            this.Controls.Add(this.btnSupConv);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnOCR);
            this.Controls.Add(this.btnSave);
            this.Name = "Form4";
            this.Text = "test";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1bit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSupConv;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.RadioButton AutoBinarize;
        private System.Windows.Forms.RadioButton AutoColorLevel;
        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.PictureBox pic1bit;
        private System.Windows.Forms.Label l_await;
        private System.Windows.Forms.RadioButton GrayScale;
    }
}