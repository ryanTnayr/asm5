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
        List<Button> listButton = new List<Button>();
        public Form1()
        {
            InitializeComponent();

            //將btn物件 陣列化
            Button[] btnTemp = new Button[]
            {
            btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9,btn10,
            btn11,btn12,btn13,btn14,btn15,btn16,btn17,btn18,btn19,btn20,
            btn21,btn22,btn23,btn24,btn25,btn26,btn27,btn28,btn29,btn30,
            btn31,btn32,btn33,btn34,btn35,btn36,btn37,btn38,btn39,btn40,
            btn41,btn42,btn43,btn44,btn45,btn46,btn47,btn48,btn49,btn50,
            btn51,btn52,btn53,btn54,btn55,btn56,btn57,btn58,btn59,btn60,
            btn61,btn62,btn63,btn64,btn65,btn66,btn67,btn68,btn69,btn70,
            btn71,btn72,btn73,btn74,btn75,btn76,btn77,btn78,btn79,btn80,
            };
            listButton.AddRange(btnTemp);

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

            //清除目前所有選擇  ok
            //將按鍵 陣列化
            //1.若(案件顏色有改變) or 一律改 (哪個比較快)
            //2.改選擇陣列
            //3.改待選陣列

           

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

            //AUTO選擇 OK
            //1. 自動產生玩家選擇星數的數字出來
            //2. 若玩家沒有選擇星數提醒
            //3. 若玩家選擇到一半案AUTO，自動填入剩餘數字

            //將數字排序輸出

            //猜大小

            //顯示中獎

            //再來一局
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            pickNum(btn1);
        }

        //click 發生  !!!!待增加案第二下按鍵取消該數字!!!!
        void pickNum(Button button)
        {
            if (comboxStar.SelectedIndex != -1)
            {

                if (listPlay.Count == comboxStar.SelectedIndex)
                {
                    MessageBox.Show("你已選擇完畢");
                }
                else
                {
                    if (button.BackColor != Color.Gray)  //顏色轉灰不給使用者點
                    {
                        listPlay.Add(button.Text);
                        button.BackColor = Color.Gray;
                        intNeed -= 1;
                        lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
                        //foreach (string str in listPlay)
                        //{
                        //    Console.Write(str);
                        //}
                    }
                }
            }
            else
            {
                MessageBox.Show("請選擇星數");
            }
        }

        //確定所選數字 ENTER OK
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (listPlay.Count != comboxStar.SelectedIndex)
            {
                MessageBox.Show($"還剩{intNeed}個數字需要選擇");
            }
            else
            {
                listPlay.Sort();

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

        //幫玩家自動選擇數字 AUTO  OK
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (comboxStar.SelectedIndex == -1)
            {
                MessageBox.Show("請先選擇星數");
            }
            else
            {
                var rand = new Random();
                List<string> listAuto = new List<string>();
                for (int i = 0; i < comboxStar.SelectedIndex - listPlay.Count; i++)  //幫玩家選，也有自動幫玩家補足的功能
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
                    int intstr = Convert.ToInt32(mystr);
                    listButton[intstr - 1].BackColor = Color.Gray;
                    intNeed -= 1;
                    lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
                    listAuto.Add(mystr);
                }
                for (int i = 0; i < listAuto.Count; i++)
                {
                    listPlay.Add(listAuto[i]);
                }
            }
        }

        //清除所有選擇 ok
        private void btnClear_Click(object sender, EventArgs e)
        {
            listPlay = new List<string> { } ;       
            intNeed = comboxStar.SelectedIndex;
            lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
            for (int i = 0; i < 80;i++)
            {
                if (listButton[i].BackColor == Color.Gray)
                {
                    //怪怪的，不給回最初的顏色
                    listButton[i].BackColor = Button.DefaultBackColor;
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            pickNum(btn2);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            pickNum(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            pickNum(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            pickNum(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            pickNum(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            pickNum(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            pickNum(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            pickNum(btn9);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            pickNum(btn10);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            listPlay.Sort();
            for(int i = 0; i< listPlay.Count; i++)
            {
                Console.Write(listPlay[i]+" ");
            }
            
        }
    }
}
    
    

