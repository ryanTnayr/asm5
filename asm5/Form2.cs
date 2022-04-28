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

        }


        public void Set(List<int> mywin, List<int> myplay, List<int> get)
        {

            for (int i = 0; i < 20; i++)
            {
                Label lbl = new Label();
                lbl.Name = "lblWin" + i;
                lbl.Text = string.Format($"{mywin[i]}");
                //lbl.Visible = true;
                lbl.BackColor = Color.Yellow;
                if (myplay.IndexOf(mywin[i]) != -1)
                {
                    lbl.BackColor = Color.Red;
                }
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Size = new Size(30, 30);
                lbl.Location = new Point(30+(i%10)*40, 30+(i/10)*40);
                Controls.Add(lbl);
            }
           
            for(int i = 0; i < myplay.Count; i++)
            {
                Label lbl = new Label();
                lbl.BackColor = Color.Yellow;
                if (mywin.IndexOf(myplay[i]) != -1)
                {
                    lbl.BackColor = Color.Red;
                }
                    
                lbl.Name = "lblPlay" + i;
                lbl.Text = string.Format($"{myplay[i]}");
                //lbl.Visible = true;
                
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Size = new Size(30, 30);
                lbl.Location = new Point(30 + (i % 10) * 40, 150);
                Controls.Add(lbl);
            }
            lblShowGet.Text = string.Format($"您中了{get.Count}個!!!");
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
