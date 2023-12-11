namespace WindowsFormsRec
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.paintbtn = new System.Windows.Forms.Button();
            this.recbtn = new System.Windows.Forms.Button();
            this.notebtn = new System.Windows.Forms.Button();
            this.capture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paintbtn
            // 
            this.paintbtn.Location = new System.Drawing.Point(182, 51);
            this.paintbtn.Name = "paintbtn";
            this.paintbtn.Size = new System.Drawing.Size(204, 145);
            this.paintbtn.TabIndex = 0;
            this.paintbtn.Text = "그림판";
            this.paintbtn.UseVisualStyleBackColor = true;
            this.paintbtn.Click += new System.EventHandler(this.paintbtn_Click);
            // 
            // recbtn
            // 
            this.recbtn.Location = new System.Drawing.Point(403, 51);
            this.recbtn.Name = "recbtn";
            this.recbtn.Size = new System.Drawing.Size(204, 145);
            this.recbtn.TabIndex = 1;
            this.recbtn.Text = "녹화";
            this.recbtn.UseVisualStyleBackColor = true;
            this.recbtn.Click += new System.EventHandler(this.recbtn_Click);
            // 
            // notebtn
            // 
            this.notebtn.Location = new System.Drawing.Point(182, 218);
            this.notebtn.Name = "notebtn";
            this.notebtn.Size = new System.Drawing.Size(204, 145);
            this.notebtn.TabIndex = 2;
            this.notebtn.Text = "메모장";
            this.notebtn.UseVisualStyleBackColor = true;
            this.notebtn.Click += new System.EventHandler(this.notebtn_Click);
            // 
            // capture
            // 
            this.capture.Location = new System.Drawing.Point(403, 218);
            this.capture.Name = "capture";
            this.capture.Size = new System.Drawing.Size(204, 145);
            this.capture.TabIndex = 3;
            this.capture.Text = "화면캡쳐";
            this.capture.UseVisualStyleBackColor = true;
            this.capture.Click += new System.EventHandler(this.capture_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.capture);
            this.Controls.Add(this.notebtn);
            this.Controls.Add(this.recbtn);
            this.Controls.Add(this.paintbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "YuhanTool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button paintbtn;
        private System.Windows.Forms.Button recbtn;
        private System.Windows.Forms.Button notebtn;
        private System.Windows.Forms.Button capture;
    }
}