using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _007
{
    public partial class Form1 : Form
    {
        int count;
        int score;
        int partsc = 60;
        int m, t;
        int time = 0;
        Button first = null;
        Button second = null;
        Button[] btn = new Button[36];
        Random rnd = new Random();
        int[] Num = new int[36];
        int[] RndArr = new int[36];
        List<string> arr = new List<string>()
        { "a","a","!","!","A","A",".",".","?","?","@","@","2","2",
           "6","6","q","q","#","#","j","j","o","o","/","/","<","<","0","0","f","f",
           "u","u","&","&"};
        public Form1()
        {
            InitializeComponent();
            btn = new Button[36] { button1, button2, button3, button4, button5, button6,
                button7, button8, button9, button10, button11, button12, button13, button14,
                button15, button16, button17, button18, button19, button20, button21, button22,
                button23, button24, button25, button26, button27, button28, button29, button30,
                button31, button32, button33, button34, button35, button36 };

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            int num;
            m = 0;
            t = 0;
            time = 0;
            count = 0;
            score = 0;
            timer2.Start();
            for (int i = 0; i < 36; i++)
            {
                btn[i].Click += new EventHandler(this.buttons_Click);
                num = rnd.Next(arr.Count());
                btn[i].Text = arr[num];
                arr.RemoveAt(num);
                btn[i].ForeColor = System.Drawing.Color.Moccasin;
            }
            button37.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (partsc > 0)
                partsc -= 5;
            else
                partsc = 0;
            timer1.Stop();
            Thread.Sleep(300);
            first.ForeColor = Color.Moccasin;
            first.BackColor = Color.Moccasin;
            second.ForeColor = Color.Moccasin;
            second.BackColor = Color.Moccasin;
            first = null;
            second = null;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (t >= 60)//計時器
            {
                m++;
                t =0;

            }
            /*if (m < 0)
            {
                timer2.Stop();//時間到
                var result = MessageBox.Show("時間已到，挑戰失敗\n是否花費200分來接關？", "時間結束", MessageBoxButtons.YesNo);
               if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    if (score >= 200)
                        score -= 200;
                    else
                        score = 0;

                    m += 3;
                }
                timer2.Start();
            }*/
            label2.Text = " Time：" + m + " min " + t + " s ";
            timer2.Interval = 1000;
            t++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttons_Click(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            if (button.ForeColor == Color.Black) return;
            if (first == null)
            {
                first = button;
                first.ForeColor = Color.Black;
                first.BackColor = Color.Wheat;
                return;
            }
            second = button;
            second.ForeColor = Color.Black;
            second.BackColor = Color.Wheat;
            if (first.Text != second.Text)
            {
                timer1.Start();
            }
            else
            {
                count = 0;
                for (int i = 0; i < 36; i++)
                {
                    if (btn[i].ForeColor == Color.Black)
                        count++;

                    if (count == 35)
                    {
                        score += m * 200;
                        score += t * 3;
                        timer2.Stop();
                        label1.Text = " Score ： " + score;
                        time = m * 60 + t;
                        MessageBox.Show(" 完成遊戲!! \n " + "共得到 ：" + score + " 分 \n 完成時間 ：" + time+ "秒");
                        this.Close();
                    }
                }
                if (partsc == 60)
                {
                    score += 30 * (36 - count);
                }
                else if (partsc > 40)
                {
                    score += partsc + (36 - count);
                }
                else if (partsc > 20)
                {
                    score += partsc;
                }
                else
                {
                    score += 20;
                }
                partsc = 60;
                label1.Text = " Score ： " + score;
                first = null;
                second = null;
            }
        }


}
}
