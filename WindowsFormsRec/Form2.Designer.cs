using System.Drawing;
using System.Windows.Forms;

namespace Notepad
{
    partial class Form2
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
            lblWord = new Label();
            txtWord = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            chOption = new CheckBox();
            groupBox = new GroupBox();
            rdb02 = new RadioButton();
            rdb01 = new RadioButton();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // lblWord
            // 
            lblWord.AutoSize = true;
            lblWord.Location = new Point(12, 15);
            lblWord.Name = "lblWord";
            lblWord.Size = new Size(59, 15);
            lblWord.TabIndex = 0;
            lblWord.Text = "찾을 내용";
            // 
            // txtWord
            // 
            txtWord.Location = new Point(88, 12);
            txtWord.Name = "txtWord";
            txtWord.Size = new Size(460, 23);
            txtWord.TabIndex = 1;
            txtWord.TextChanged += txtWord_TextChanged;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(573, 15);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "다음 찾기";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(573, 72);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chOption
            // 
            chOption.AutoSize = true;
            chOption.Location = new Point(33, 72);
            chOption.Name = "chOption";
            chOption.Size = new Size(107, 19);
            chOption.TabIndex = 4;
            chOption.Text = "대/소문자 구분";
            chOption.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(rdb02);
            groupBox.Controls.Add(rdb01);
            groupBox.Location = new Point(166, 53);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(382, 63);
            groupBox.TabIndex = 5;
            groupBox.TabStop = false;
            groupBox.Text = "방향";
            // 
            // rdb02
            // 
            rdb02.AutoSize = true;
            rdb02.Checked = true;
            rdb02.Location = new Point(214, 23);
            rdb02.Name = "rdb02";
            rdb02.Size = new Size(61, 19);
            rdb02.TabIndex = 1;
            rdb02.TabStop = true;
            rdb02.Text = "아래쪽";
            rdb02.UseVisualStyleBackColor = true;
            // 
            // rdb01
            // 
            rdb01.AutoSize = true;
            rdb01.Location = new Point(62, 23);
            rdb01.Name = "rdb01";
            rdb01.Size = new Size(49, 19);
            rdb01.TabIndex = 0;
            rdb01.TabStop = true;
            rdb01.Text = "위쪽";
            rdb01.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 142);
            Controls.Add(groupBox);
            Controls.Add(chOption);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtWord);
            Controls.Add(lblWord);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "찾기";
            TopMost = true;
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWord;
        internal TextBox txtWord;
        internal Button btnOK;
        private Button btnCancel;
        internal CheckBox chOption;
        private GroupBox groupBox;
        private RadioButton rdb02;
        internal RadioButton rdb01;
    }
}