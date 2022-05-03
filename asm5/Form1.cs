using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace asm5
{
    /*
     * 尚未完成功能：
     * 1. 按鍵圖形化
     * 2. 不同form傳遞資料 OK
     * 3. 按鍵自動化生成  OK
     * 4. 再來一場(清除先前選擇、重新產生新兌獎數字) 
     * 5. 不同獎顯示不同圖片  OK
     * 6. 將對中的數字變顏色 OK
     * 
     * 技術：
     * 1. 按鈕陣列化，方便使用
     * 2. 無限迴圈檢查數字有無重複
     * 3. 利用 combobox.SelectedIndex 控制 for 迴圈數
     * 4. 利用 bool 控制按鍵是否作用
     * 5. 按下按鍵後，顯示其他按鍵
     * 6. 跳出新 form ，並自動生成按鍵
     * 
     * 功能：
     * 1. 下拉式選單，未選擇會跳提醒視窗
     * 2. 數字按下會改變顏色，再按一下可以取消選擇
     * 3. 追蹤玩家剩餘數字
     * 4. 當玩家想超選，會跳提醒視窗
     * 5. 玩家確定後，鎖住其他按鍵，清除後，解除鎖定
     * 6. 幫玩家自動選擇全部數字或剩餘數字
     * 7. 兌獎後，跳出新視窗，並返回上一頁
     */

    
    //這裡家gobal 也崩潰
    public partial class Form1 : Form
    {
        List<int> listPlay = new List<int>();
        List<Label> listselect = new List<Label>();
        List<Button> listButton = new List<Button>();
        List<int> listWin = new List<int>();
        int intNeed;
        bool isEnterClick = false;
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
            
            for (int i = 0; i < 20; i++)
            {
                string mystr = "";
                while (true)
                {
                    mystr = rand.Next(1, 81).ToString();
                    if (listWin.IndexOf(Convert.ToInt32(mystr)) == -1)
                    {
                        break;
                    }
                }
                listWin.Add(Convert.ToInt32(mystr));
                Console.WriteLine(listWin[i]);

            }

            //將按鍵圖形化

            {//請玩家選擇幾星、倍率(下拉式選單) ok


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

                //AUTO選擇 OK
                //1. 自動產生玩家選擇星數的數字出來
                //2. 若玩家沒有選擇星數提醒
                //3. 若玩家選擇到一半案AUTO，自動填入剩餘數字

                //將數字排序輸出 OK

                //猜大小

                //顯示中獎

                //再來一局
            }
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            pickNum(btn1);
        }

        //click 發生
        
        void pickNum(Button button)
        {
            if (isEnterClick == false)  //按確定後，不給點數字........防止按確定後，玩家還取消數字並去兌獎，會有BUG
            {
                if (comboxStar.SelectedIndex != -1)
                {
                    if (button.BackColor != Color.Gray && listPlay.Count != comboxStar.SelectedIndex)  //顏色轉灰不給使用者點
                    {
                        listPlay.Add(Convert.ToInt32(button.Text));
                        button.BackColor = Color.Gray;
                        intNeed -= 1;
                        lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
                        //foreach (string str in listPlay)
                        //{
                        //    Console.Write(str);
                        //}
                    }
                    else if (button.BackColor != Color.Gray && listPlay.Count == comboxStar.SelectedIndex)
                    {
                        MessageBox.Show("你已選擇完畢");
                    }
                    else
                    {
                        //把listPlay 中的數字刪除
                        //把顏色變回原本顏色
                        //intNeed也要加一
                        listPlay.Remove(Convert.ToInt32(button.Text));
                        button.BackColor = Button.DefaultBackColor;
                        intNeed += 1;
                        lblNumLeft.Text = string.Format($"還剩{intNeed}個數字需要選擇");
                    }
                }
                else
                {
                    MessageBox.Show("請選擇星數");
                }
            }
            else
            {
                MessageBox.Show("你已按確定鎖定數字，請解除確定");
            }
            
        }

        //確定所選數字 ENTER OK
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (btnEnter.Text=="確定")
            {
                btnCheck.Show();
                isEnterClick = true;
                if (listPlay.Count != comboxStar.SelectedIndex)
                {
                    MessageBox.Show($"還剩{intNeed}個數字需要選擇");
                }
                else
                {
                    listPlay.Sort();
                    btnEnter.Text = "解除確定";
                    for (int i = 0; i < comboxStar.SelectedIndex; i++)
                    {
                        listselect[i].Show();
                    }
                    for (int i = 0; i < comboxStar.SelectedIndex; i++)
                    {
                        listselect[i].Text = Convert.ToString(listPlay[i]);
                    }
                }
            }
            else
            {
                isEnterClick = false;
                btnEnter.Text = "確定";
                for (int i = 0; i < comboxStar.SelectedIndex; i++)
                {
                    listselect[i].Hide();
                }
            }

            
        }

        //下拉式選單確定剩餘數目 ok
        private void comboxStar_SelectedIndexChanged(object sender, EventArgs e)
        {
            intNeed = comboxStar.SelectedIndex-listPlay.Count;
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
                    listPlay.Add(Convert.ToInt32(listAuto[i]));
                }
            }
        }

        //清除所有選擇 ok
        private void btnClear_Click(object sender, EventArgs e)
        {
            btnCheck.Hide();
            isEnterClick = false;
            btnEnter.Text = "確定";
            listPlay = new List<int> { } ;       
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
            for (int i = 0; i < comboxStar.SelectedIndex; i++)
            {
                listselect[i].Hide();
                //listselect[i].Visible = false; 也可以喔~
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

        

        private void btnCheck_Click(object sender, EventArgs e)
        {
            listWin.Sort();
            if (listPlay.Count != comboxStar.SelectedIndex)  
            {
                MessageBox.Show($"還剩{intNeed}個數字需要選擇");
            }
            else
            {
                List<int> listGet = new List<int>();

                for (int i = 0; i < listPlay.Count; i++)
                {
                    if (listWin.IndexOf(listPlay[i]) != -1)
                    {
                        listGet.Add(listPlay[i]);
                    }

                }
                
                //foreach (int myint in listWin)
                //{
                //    Console.Write(myint + " ");
                //}
                //Console.WriteLine();
                //foreach (int myint in listPlay)
                //{
                //    Console.Write(myint + " ");
                //}
                //Console.WriteLine("中了" + listGet.Count);
        
                this.Hide(); //隱藏父視窗
                Form2 form2 = new Form2(); //創建子視窗
                form2.Set(listWin,listPlay,listGet);
                switch (form2.ShowDialog(this))
                {
                    case DialogResult.Yes: //Form2中按下ToForm1按鈕
                        this.Show(); //顯示父視窗
                        break;
                    case DialogResult.No: //Form2中按下關閉鈕
                        this.Close();  //關閉父視窗 (同時結束應用程式)
                        break;
                    default:
                        break;
                }
            }
            

        }

        public void reset()
        {
            for (int i = 0; i < comboxStar.SelectedIndex; i++)
            {
                listselect[i].Hide();
            }
            comboxStar.SelectedIndex = -1;
            comboxStar.Text = "--請選擇星數--";

            var rand = new Random();  //宣告為類別變數無用(?)
            for (int i = 0; i < 20; i++)
            {
                string mystr = "";
                while (true)
                {
                    mystr = rand.Next(1, 81).ToString();
                    if (listWin.IndexOf(Convert.ToInt32(mystr)) == -1)
                    {
                        break;
                    }
                }
                listWin[i] = Convert.ToInt32(mystr);
            }
            for (int i = 0; i < 80; i++)
            {
                if (listButton[i].BackColor == Color.Gray)
                {
                    //怪怪的，不給回最初的顏色
                    listButton[i].BackColor = Button.DefaultBackColor;
                }
            }
            listPlay.Clear();
            lblNumLeft.Text = "";
            btnEnter.Text = "確定";
            btnCheck.Hide();
            intNeed = 0;
            isEnterClick = false;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            pickNum(btn11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            pickNum(btn12);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            pickNum(btn13);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            pickNum(btn14);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            pickNum(btn15);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            pickNum(btn16);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            pickNum(btn17);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            pickNum(btn18);
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            pickNum(btn19);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            pickNum(btn20);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            pickNum(btn21);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            pickNum(btn22);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            pickNum(btn23);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            pickNum(btn24);
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            pickNum(btn25);
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            pickNum(btn26);
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            pickNum(btn27);
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            pickNum(btn28);
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            pickNum(btn29);
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            pickNum(btn30);
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            pickNum(btn31);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            pickNum(btn32);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            pickNum(btn33);
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            pickNum(btn34);
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            pickNum(btn35);
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            pickNum(btn36);
        }

        private void btn37_Click(object sender, EventArgs e)
        {
            pickNum(btn37);
        }

        private void btn38_Click(object sender, EventArgs e)
        {
            pickNum(btn38);
        }

        private void btn39_Click(object sender, EventArgs e)
        {
            pickNum(btn39);
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            pickNum(btn40);
        }

        private void btn41_Click(object sender, EventArgs e)
        {
            pickNum(btn41);
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            pickNum(btn42);
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            pickNum(btn43);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            pickNum(btn44);
        }

        private void btn45_Click(object sender, EventArgs e)
        {
            pickNum(btn45);
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            pickNum(btn46);
        }

        private void btn47_Click(object sender, EventArgs e)
        {
            pickNum(btn47);
        }

        private void btn48_Click(object sender, EventArgs e)
        {
            pickNum(btn48);
        }

        private void btn49_Click(object sender, EventArgs e)
        {
            pickNum(btn49);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            pickNum(btn50);
        }

        private void btn51_Click(object sender, EventArgs e)
        {
            pickNum(btn51);
        }

        private void btn52_Click(object sender, EventArgs e)
        {
            pickNum(btn52);
        }

        private void btn53_Click(object sender, EventArgs e)
        {
            pickNum(btn53);
        }

        private void btn54_Click(object sender, EventArgs e)
        {
            pickNum(btn54);
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            pickNum(btn55);
        }

        private void btn56_Click(object sender, EventArgs e)
        {
            pickNum(btn56);
        }

        private void btn57_Click(object sender, EventArgs e)
        {
            pickNum(btn57);
        }

        private void btn58_Click(object sender, EventArgs e)
        {
            pickNum(btn58);
        }

        private void btn59_Click(object sender, EventArgs e)
        {
            pickNum(btn59);
        }

        private void btn60_Click(object sender, EventArgs e)
        {
            pickNum(btn60);
        }

        private void btn61_Click(object sender, EventArgs e)
        {
            pickNum(btn61);
        }

        private void btn62_Click(object sender, EventArgs e)
        {
            pickNum(btn62);
        }

        private void btn63_Click(object sender, EventArgs e)
        {
            pickNum(btn63);
        }

        private void btn64_Click(object sender, EventArgs e)
        {
            pickNum(btn64);
        }

        private void btn65_Click(object sender, EventArgs e)
        {
            pickNum(btn65);
        }

        private void btn66_Click(object sender, EventArgs e)
        {
            pickNum(btn66);
        }

        private void btn67_Click(object sender, EventArgs e)
        {
            pickNum(btn67);
        }

        private void btn68_Click(object sender, EventArgs e)
        {
            pickNum(btn68);
        }

        private void btn69_Click(object sender, EventArgs e)
        {
            pickNum(btn69);
        }

        private void btn70_Click(object sender, EventArgs e)
        {
            pickNum(btn70);
        }

        private void btn71_Click(object sender, EventArgs e)
        {
            pickNum(btn71);
        }

        private void btn72_Click(object sender, EventArgs e)
        {
            pickNum(btn72);
        }

        private void btn73_Click(object sender, EventArgs e)
        {
            pickNum(btn73);
        }

        private void btn74_Click(object sender, EventArgs e)
        {
            pickNum(btn74);
        }

        private void btn75_Click(object sender, EventArgs e)
        {
            pickNum(btn75);
        }

        private void btn76_Click(object sender, EventArgs e)
        {
            pickNum(btn76);
        }

        private void btn77_Click(object sender, EventArgs e)
        {
            pickNum(btn77);
        }

        private void btn78_Click(object sender, EventArgs e)
        {
            pickNum(btn78);
        }

        private void btn79_Click(object sender, EventArgs e)
        {
            pickNum(btn79);
        }

        private void btn80_Click(object sender, EventArgs e)
        {
            pickNum(btn80);
        }
    }
}
    
    

