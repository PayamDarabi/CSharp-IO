using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("temp.txt",true);
            sw.Write(textBox1.Text);
            sw.Close();
            sw.Dispose();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line;
            using (StreamReader reader = new StreamReader("temp.txt"))
            {
                line = reader.ReadToEnd();
                reader.Dispose();
            }
            label1.Text = line;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd.FileName);
                if (ext == ".txt")
                {
                    button4.Enabled = true;
                    string line;
                    using (StreamReader reader = new StreamReader("temp.txt"))
                    {
                        line = reader.ReadToEnd();
                        reader.Dispose();
                    }
                    richTextBox1.Text = line;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("temp.txt", false);
            sw.Write(richTextBox1.Text);
            sw.Close();
            sw.Dispose();
            richTextBox1.Clear();
        }
    }
}
