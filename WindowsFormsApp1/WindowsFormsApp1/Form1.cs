using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoBox();
        }

        public int count = 0;

        
        public void InfoBox ()
        {
            label1.Text = "Money: 0";

            label2.Text = "Name:        Sasha";
            label3.Text = "HP:      100";
            label5.Text = "Sword:     Рука";

            label7.Text = "10";
            label4.Text = "Дубинка";
            button2.Text = "Купить";
            button2.Visible = false;

            label8.Text = "100";
            label6.Text = "Пистолет";
            button3.Text = "Купить";
            button3.Visible = false;

            label9.Text = "Цена";
            label10.Text = "Вид орудия";


            comboBox1.Items.Add("Шифр Цезаря");
            comboBox1.Items.Add("Сдвиг на 1");

            label12.Text = "Текст который зашифровать: ";
            label13.Text = "Ключь";
            label14.Text = "Зашифрованный текст: ";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Кликай больше!";
            
            count++;

            if (count >= 10)
                button2.Visible = true;
            if (count >= 100)
            {
                button3.Visible = true;

                if (label5.Text == label6.Text)
                {
                    label7.Visible = false;
                    label4.Visible = false;
                    button2.Visible = false;
                }

            }
            label1.Text =  count.ToString();

           
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = label4.Text;
            count = Convert.ToInt32(label1.Text) - Convert.ToInt32(label7.Text);
            
            if (count < 10)
            {
                
                button2.Visible = false;
            }
            label1.Text = count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = label6.Text;

            count = Convert.ToInt32(label1.Text) - Convert.ToInt32(label8.Text);

            if (count < 100)
            {

                button2.Visible = false;
                button3.Visible = false;
            }
            label1.Text = count.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        const string strNorm = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string strMod = "-BCDEFGHIJKLMNOPQRSTUVWXYZAbcdefghijklmnopqrstuvwxyza";

        public int Pos(string str, char c)
        {
            int val = -1;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    val = i;
            }

            return val;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
                string s = textBox2.Text;
                char[] chars = new char[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    int index = Pos(strNorm, s[i]);

                    //int index = strNorm.IndexOf(s[i]);

                    // Console.WriteLine(i + " - " + index + " - ");

                    chars[i] = (index >= 0) ? strMod[index] : s[i];

                }

                string outs = new string(chars);
                label11.Text = outs;
               // Console.WriteLine(outs);
            }

        }
    }
}
