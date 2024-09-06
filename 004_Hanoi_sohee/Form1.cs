using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _004_Hanoi_sohee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // ListBox 초기화.
            Hanoi(4, 'a', 'b', 'c'); // a에서 b를 이용해서 c로 간다.
        }
        private void Hanoi(int n, char from, char to, char by)
        {
            if (n == 1)
            {
                listBox1.Items.Add($"Move {from} -> {by}");
            }
            else
            {
                Hanoi(n - 1, from, by, to);
                listBox1.Items.Add($"Move {from} -> {by}");
                Hanoi(n - 1, to, from, by);
            }
        }
    }
}
