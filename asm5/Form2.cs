using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asm5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Size = new Size();
            Location = new Point();
            Label lbl;
            for (int i = 0; i<20;i++)
            {
                lbl  = new Label();
                lbl.Name = "lbl" + i;
                lbl.AutoSize = false;
                lbl.Size =(36, 36);
                lbl.Location = (10, 10);
                //lbl.Width = 36;
                //lbl.Height = 36;
                //lbl.Left = 10 ;
                //lbl.Top = 10;
                //lbl.Left = 30+(i%10)*46;
                //lbl.Top = 30+(i/10)*46;
                
                lbl.Visible = true;
                this.Controls.Add(lbl);
                
                
            }
           



            //label.Text = "xxxxx";
            


            //this.Controls.Add(label);
        }

        public void SetTextBox(string text) //實作一個公開方法，使其他Form可以傳遞資料進來
        {
           lblShowGet.Text = text;
        }

        bool IsToForm1 = false;
        private void btnBackForm1_Click(object sender, EventArgs e)
        {
            IsToForm1 = true;
            this.Close(); //強制關閉Form2
        }

        protected override void OnClosing(CancelEventArgs e) //在視窗關閉時觸發
        {
            base.OnClosing(e);
            if (IsToForm1) //判斷是否要回到Form1
            {
                this.DialogResult = DialogResult.Yes; //利用DialogResult傳遞訊息
                Form1 form1 = (Form1)this.Owner; //取得父視窗的參考
                //form1.SetTextBox(textBox2.Text); //將Form2中textBox的資料透過公開方法傳遞給Form1
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
