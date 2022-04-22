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
    //這裡家gobal 也崩潰
    public partial class Form1 : Form
    {
        List<string> listPlay = new List<string>();
        List<Label> listselect = new List<Label>();
        int intNeed;
        public Form1()
        {
            InitializeComponent();

            //輸入下拉式選單內容
            string[] strTemp = new string[]
            {
                "無", "一星", "二星","三星","四星",
               "五星","六星","七星","八星","九星","十星"
            };
            comboxStar.Items.AddRange(strTemp);

            //將lbl物件 用陣列儲存方便使用
            Label[] lblTemp = new Label[]
            {
            lblselect1, lblselect2,
            lblselect3, lblselect4,
            lblselect5, lblselect6,
            lblselect7, lblselect8,
            lblselect9, lblselect10
            };
            listselect.AddRange(lblTemp);
            //在這邊放 public class Global會崩潰
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //產生20個隨機碼(1~80) OK
            //避免重複數字 OK
            var rand = new Random();  //宣告為類別變數無用(?)
            List<string> listWin = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                string mystr = "";
                while (true)
                {
                    mystr = rand.Next(1, 81).ToString();
                    if (listWin.IndexOf(mystr) == -1)
                    {
                        break;
                    }
                }
                listWin.Add(mystr);
                Console.WriteLine(listWin[i]);

            }
            //請玩家選擇幾星、倍率(下拉式選單) ok


            //顯示尚需選擇幾個數 ok

            //清除目前所有選擇

            //請玩家輸入號碼  OK

            //選擇完數字要讓使用者不能再選  OK

            //按鍵輸入，按下時顏色改變  OK


            //比對數字 OK
            int getCount = 0;

            for (int i = 0; i < listPlay.Count; i++)
            {
                if (listWin.IndexOf(listPlay[i]) != -1)
                {
                    getCount++;
                }

            }
            Console.WriteLine("中了" + getCount);

            //將數字排序輸出

            //猜大小

            //顯示中獎

            //清除畫面
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            pickNum(btn1);
        }
        void pickNum(Button button)
        {
            if (comboxStar.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇星數");
            }
            else
            {
                if (button.BackColor != Color.Gray)  //顏色轉灰不給使用者點
                {
                    listPlay.Add(button.Text);
                    button.BackColor = Color.Gray;
                    intNeed -= 1;
                    lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
                    foreach (string str in listPlay)
                    {
                        Console.WriteLine(str);
                    }
                }

            }
        }

        //確定所選數字 OK
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (listPlay.Count != comboxStar.SelectedIndex)
            {
                MessageBox.Show($"還剩{intNeed}個數字需要選擇");
            }
            else
            {
                for (int i = 0; i < comboxStar.SelectedIndex; i++)
                {
                    listselect[i].Show();
                }
                for (int i = 0; i < comboxStar.SelectedIndex; i++)
                {
                    listselect[i].Text = listPlay[i];
                }
            }
        }

        //下拉式選單確定剩餘數目 ok
        private void comboxStar_SelectedIndexChanged(object sender, EventArgs e)
        {
            intNeed = comboxStar.SelectedIndex;
            lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
        }

        //幫玩家自動選擇數字
        private void btnAuto_Click(object sender, EventArgs e)
        { 
            var rand = new Random();
            List<string> listAuto = new List<string>();
            for (int i = 0; i < comboxStar.SelectedIndex; i++)
            {
                string mystr = "";
                while (true)
                {
                    mystr = rand.Next(1, 81).ToString();
                    if (listAuto.IndexOf(mystr) == -1)
                    {
                        break;
                    }
                }
                listAuto.Add(mystr);
            }
            for (int i = 0; i < comboxStar.SelectedIndex; i++)
            {
                listselect[i].Text = listAuto[i];
            }
            for (int i = 0; i < comboxStar.SelectedIndex; i++)
            {
                listselect[i].Show();
            }
        }

        //清除所有選擇
        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
    
    

