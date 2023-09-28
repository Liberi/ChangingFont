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

namespace Изменение_шрифта_Fount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //foundBolt.Text = comboBox1.Text;
            this.richTextBox1.Font = new Font(foundNameTXT, Num, fontStyleFT);
        }
        string foundNameTXT = "Microsoft Sans Serif", fontStyleTXT;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foundName.Text = listBox1.SelectedItem.ToString();
            foundNameTXT = listBox1.SelectedItem.ToString();
            this.label4.Font = new Font(foundNameTXT, Num, fontStyleFT);
        }

        float Num = 10f;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fountSize.Text = comboBox1.SelectedItem.ToString();
            Num = Convert.ToSingle(comboBox1.Text);
            this.label4.Font = new Font(foundNameTXT, Num, fontStyleFT);
        }

        FontStyle fontStyleFT = FontStyle.Regular;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opDialog = new OpenFileDialog();
            opDialog.Filter = "Фаилы текста (*.TXT) | *.txt;";
            if (opDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(opDialog.FileName);
                richTextBox1.Text = reader.ReadToEnd();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] mass = richTextBox1.Text.Split(' ');
            foreach (string item in mass)
            {
                if (item == " ")
                {
                    continue;
                }
                else
                {
                    listBox3.Items.Add(item);
                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontStyle.Text = listBox2.SelectedItem.ToString();
            fontStyleTXT = listBox2.SelectedItem.ToString();
            switch (fontStyleTXT)
            {
                case "Обычный":
                    fontStyleFT = FontStyle.Regular;
                    break;
                case "Наклонный":
                    fontStyleFT = FontStyle.Italic;
                    break;
                case "Полужирный":
                    fontStyleFT = FontStyle.Bold;
                    break;
            }
            this.label4.Font = new Font(foundNameTXT, Num, fontStyleFT);
        }
    }
}
