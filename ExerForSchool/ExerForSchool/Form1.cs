using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExerForSchool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           
            textBox1.Visible = false;

            

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);

            ToolStripMenuItem helpItem = new ToolStripMenuItem("Помощь");
            helpItem.Click += helpItem_Click;
            menuStrip1.Items.Add(helpItem);
            //listComboBox1.SelectedIndexChanged += listComboBox1_SelectedIndexChanged;
        }
        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа шифрует вводимый вами текст и полученный текст выводит в отдельном текстовом файле под названием Apple.txt\n Работу выполнил David Alexandr Gr.C-0220.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void helpItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обязательнно, чтобы программа работала необходимо:\n 1.Выбрать в параметре key поле\n 2.В параметре Input указать текст \n 3.После появиться кнопка, позволяющая зашифровать текст, необходимо её нажать.\n *Полученный текст выводит в отдельном текстовом файле под названием Apple.txt", "Как работает программа", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infoBox();

          /*  if (textOutLabel4.Text.Length > 0)
                textOutLabel4.Visible = true;*/
          
        }

        private void infoBox()
        {
            //label
            inLabel1.Text = "Текст: ";
           //outLabel3.Text = "Зашифрованный текст: ";
            
            //ComboBox
            //listComboBox1.Items.Add("Шифр Цезаря");
            listComboBox1.Items.Add("Сдвиг на 1 (домашняя работа)");



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


        private void doWork_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0 && listComboBox1.SelectedIndex == 0)
            {

                string s = textBox1.Text;
                char[] chars = new char[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    int index = Pos(strNorm, s[i]);

                    //int index = strNorm.IndexOf(s[i]);

                    // Console.WriteLine(i + " - " + index + " - ");

                    chars[i] = (index >= 0) ? strMod[index] : s[i];

                }

                string outs = new string(chars);
                // textOutLabel4.Text = outs;

                string faleName = textBox2.Text;
                string writePatch = faleName + ".txt";


                using (StreamWriter sw = new StreamWriter(writePatch))
                {
                    sw.WriteLine(outs);
                }

                label1.Visible = true;
                label1.Text = "Полученный текс в файле " + textBox2.Text + ".txt";
                
            }



            
        }


        private void listComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listComboBox1.SelectedIndex >= 0)
                textBox1.Visible = true;
        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && listComboBox1.SelectedIndex >= 0 && textBox2.TextLength > 0)
                doWork.Visible = true;
            else if (textBox1.Text.Length <= 0 || listComboBox1.SelectedIndex < 0 && textBox2.TextLength <= 0)
                doWork.Visible = false;
        }

    }
}
