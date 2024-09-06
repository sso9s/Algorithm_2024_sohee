using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002_Factorial_sohee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long rfact = rFactorial(n);
            listBox1.Items.Add("\nrecursive = " + rfact);

            watch.Stop();
            var elapedTicks = watch.ElapsedTicks;
            string result = elapedTicks + " Ticks, " + elapedTicks / 10000.0 + " ms";
            listBox1.Items.Add(result);

            watch = System.Diagnostics.Stopwatch.StartNew();

            long fact = Factorial(n);
            listBox1.Items.Add("\nloop = " + fact);

            watch.Stop();
            elapedTicks = watch.ElapsedTicks;
            result = elapedTicks + " Ticks, " + elapedTicks / 10000.0 + " ms";
            listBox1.Items.Add(result);
        }

        private long Factorial(int n)
        {
            long f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;
            return f;
        }

        private long rFactorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return rFactorial(n - 1) * n;
        }
    }
}
