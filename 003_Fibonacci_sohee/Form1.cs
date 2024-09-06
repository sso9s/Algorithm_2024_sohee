using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _003_Fibonacci_sohee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);

            listBox1.Items.Add("Recursive Fibonacci: ");
            for (int i = 1; i <= n; i++)
                listBox1.Items.Add(recFibo(i));

            loopFibo(n);
        }
        private void loopFibo(int n)
        {
            int[] a = new int[n+1];

            listBox1.Items.Add("Loop Fibonacci: ");
            for (int i = 1; i <= n; i++)
                if (i == 1 || i == 2)
                    a[i] = i;
                else
                    a[i] = a[i - 2] + a[i - 1];

            for (int i = 1; i <= n; i++)
                listBox1.Items.Add(a[i]);
        }
        private long recFibo (int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else
                return recFibo(n-1) + recFibo(n-2);
        }
    }
}
