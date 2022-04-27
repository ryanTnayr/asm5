
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
            this.SuspendLayout();
            // 
            // btnBackForm1
            // 
            this.btnBackForm1.Location = new System.Drawing.Point(134, 110);
            this.btnBackForm1.Name = "btnBackForm1";
            this.btnBackForm1.Size = new System.Drawing.Size(75, 23);
            this.btnBackForm1.TabIndex = 0;
            this.btnBackForm1.Text = "回上一頁";
            this.btnBackForm1.UseVisualStyleBackColor = true;
            this.btnBackForm1.Click += new System.EventHandler(this.btnBackForm1_Click);
            // 
            // lblShowGet
            // 
            this.lblShowGet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblShowGet.Location = new System.Drawing.Point(27, 41);
            this.lblShowGet.Name = "lblShowGet";
            this.lblShowGet.Size = new System.Drawing.Size(269, 23);
            this.lblShowGet.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 481);
            this.Controls.Add(this.lblShowGet);
            this.Controls.Add(this.btnBackForm1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackForm1;
        private System.Windows.Forms.Label lblShowGet;
    }
}