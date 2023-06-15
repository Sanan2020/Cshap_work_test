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
            this.btnConv = new System.Windows.Forms.Button();
            this.btnSupConv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(471, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "1 bit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOCR
            // 
            this.btnOCR.Location = new System.Drawing.Point(471, 245);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(75, 23);
            this.btnOCR.TabIndex = 1;
            this.btnOCR.Text = "button";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // btnConv
            // 
            this.btnConv.Location = new System.Drawing.Point(471, 27);
            this.btnConv.Name = "btnConv";
            this.btnConv.Size = new System.Drawing.Size(75, 23);
            this.btnConv.TabIndex = 2;
            this.btnConv.Text = "AutoBinarize";
            this.btnConv.UseVisualStyleBackColor = true;
            this.btnConv.Click += new System.EventHandler(this.btnConv_Click);
            // 
            // btnSupConv
            // 
            this.btnSupConv.Location = new System.Drawing.Point(471, 111);
            this.btnSupConv.Name = "btnSupConv";
            this.btnSupConv.Size = new System.Drawing.Size(75, 23);
            this.btnSupConv.TabIndex = 3;
            this.btnSupConv.Text = "button1";
            this.btnSupConv.UseVisualStyleBackColor = true;
            this.btnSupConv.Click += new System.EventHandler(this.btnSupConv_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 280);
            this.Controls.Add(this.btnSupConv);
            this.Controls.Add(this.btnConv);
            this.Controls.Add(this.btnOCR);
            this.Controls.Add(this.btnSave);
            this.Name = "Form4";
            this.Text = "test";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.Button btnConv;
        private System.Windows.Forms.Button btnSupConv;
    }
}