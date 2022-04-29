
namespace asm5
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
            this.btnBackForm1 = new System.Windows.Forms.Button();
            this.lblShowGet = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackForm1
            // 
            this.btnBackForm1.Location = new System.Drawing.Point(342, 448);
            this.btnBackForm1.Name = "btnBackForm1";
            this.btnBackForm1.Size = new System.Drawing.Size(83, 44);
            this.btnBackForm1.TabIndex = 0;
            this.btnBackForm1.Text = "再來一場";
            this.btnBackForm1.UseVisualStyleBackColor = true;
            this.btnBackForm1.Click += new System.EventHandler(this.btnBackForm1_Click);
            // 
            // lblShowGet
            // 
            this.lblShowGet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblShowGet.Location = new System.Drawing.Point(100, 270);
            this.lblShowGet.Name = "lblShowGet";
            this.lblShowGet.Size = new System.Drawing.Size(260, 30);
            this.lblShowGet.TabIndex = 1;
            this.lblShowGet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(102, 315);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(217, 177);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 2;
            this.pic1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(160, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "本期中獎號碼";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(160, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "您選擇的號碼";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lblShowGet);
            this.Controls.Add(this.btnBackForm1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackForm1;
        private System.Windows.Forms.Label lblShowGet;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}