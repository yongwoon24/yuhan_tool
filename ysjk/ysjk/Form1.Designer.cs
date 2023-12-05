namespace ysjk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            painbtn = new Button();
            capture = new Button();
            notebtn = new Button();
            recordbtn = new Button();
            SuspendLayout();
            // 
            // painbtn
            // 
            painbtn.Location = new Point(170, 73);
            painbtn.Name = "painbtn";
            painbtn.Size = new Size(206, 124);
            painbtn.TabIndex = 0;
            painbtn.Text = "그림판";
            painbtn.UseVisualStyleBackColor = true;
            painbtn.Click += painbtn_Click;
            // 
            // capture
            // 
            capture.Location = new Point(413, 225);
            capture.Name = "capture";
            capture.Size = new Size(206, 124);
            capture.TabIndex = 2;
            capture.Text = "캡처";
            capture.UseVisualStyleBackColor = true;
            capture.Click += capture_Click;
            // 
            // notebtn
            // 
            notebtn.Location = new Point(170, 225);
            notebtn.Name = "notebtn";
            notebtn.Size = new Size(206, 124);
            notebtn.TabIndex = 3;
            notebtn.Text = "메모장";
            notebtn.UseVisualStyleBackColor = true;
            notebtn.Click += notebtn_Click;
            // 
            // recordbtn
            // 
            recordbtn.Location = new Point(413, 73);
            recordbtn.Name = "recordbtn";
            recordbtn.Size = new Size(206, 124);
            recordbtn.TabIndex = 4;
            recordbtn.Text = "녹화";
            recordbtn.UseVisualStyleBackColor = true;
            recordbtn.Click += recordbtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(recordbtn);
            Controls.Add(notebtn);
            Controls.Add(capture);
            Controls.Add(painbtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button painbtn;
        private Button capture;
        private Button notebtn;
        private Button recordbtn;
    }
}