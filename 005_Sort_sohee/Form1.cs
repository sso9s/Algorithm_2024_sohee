using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace _005_Sort_sohee
{
    public partial class Form1 : Form
    {
        static int MAX = 1000000; // 백만
        int[] a = new int[MAX];
        int N = 0; // 데이터 갯수

        Random r = new Random();

        public object MAX_SIZE { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInput.Text, out N))
            {
                if (N > MAX)
                {
                    MessageBox.Show("데이터 갯수가 너무 큽니다.");
                    return;
                }

                txtBubble.Text = "버블 정렬 : ";
                txtQuick.Text = "퀵 정렬 : ";
                txtMerge.Text = "합병 정렬 : ";
                Randomize();
                PrintData("랜덤 숫자");
            }
            else
            {
                MessageBox.Show("올바른 숫자를 입력하세요.");
            }
        }

        private void Randomize()
        {
            for (int i = 0; i < N; i++)
                a[i] = r.Next(5 * N);   // 데이터 갯수의 5배까지의 랜덤 숫자 생성
        }

        private void PrintData(string title, bool showData = true)
        {            
            textBox1.AppendText($"{title}\r\n"); // 제목을 추가

            if (showData) // 데이터가 표시되어야 하는 경우에만 데이터를 추가
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < N; i++)
                {
                    sb.Append(a[i] + " ");
                }
                textBox1.AppendText(sb.ToString() + "\r\n");
            }
                        
            textBox1.AppendText("\r\n"); // 결과를 구분하기 위해 빈 줄 추가                        
            textBox1.ScrollToCaret(); // 스크롤을 텍스트 박스의 끝으로 이동
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort();
            watch.Stop();
            PrintData("버블 정렬 결과:", true); // 데이터와 함께 결과를 출력
            long tickBubble = watch.ElapsedTicks;
            long msBubble = watch.ElapsedMilliseconds;
            txtBubble.Text = "버블 정렬 : " + tickBubble + " Ticks, "
                + msBubble + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(a, 0, N - 1);
            watch.Stop();
            PrintData("퀵 정렬 결과:", true); // 데이터와 함께 결과를 출력
            long tickQuick = watch.ElapsedTicks;
            long msQuick = watch.ElapsedMilliseconds;
            txtQuick.Text = "퀵 정렬 : " + tickQuick + " Ticks, "
                + msQuick + " ms";

            Randomize();
            watch = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(a, 0, N - 1);
            watch.Stop();
            PrintData("합병 정렬 결과:", true); // 데이터와 함께 결과를 출력
            long tickMerge = watch.ElapsedTicks;
            long msMerge = watch.ElapsedMilliseconds;
            txtMerge.Text = "합병 정렬 : " + tickMerge + " Ticks, "
                + msMerge + " ms";
        }

        private void BubbleSort() // 버블
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }

        private void QuickSort(int[] a, int left, int right) // 퀵
        {
            if (left < right)
            {
                int pivotIndex = partition(a, left, right);
                QuickSort(a, left, pivotIndex - 1);
                QuickSort(a, pivotIndex + 1, right);
            }
        }
        private int partition(int[] a, int left, int right)
        {
            int pivot = a[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (a[j] <= pivot)
                {
                    i++;
                    Swap(a, i, j);
                }
            }
            Swap(a, i + 1, right);
            return i + 1;
        }
        private void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private void Merge(int[] a, int left, int mid, int right) // 합병
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (a[i] <= a[j])
                {
                    temp[k++] = a[i++];
                }
                else
                {
                    temp[k++] = a[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = a[i++];
            }

            while (j <= right)
            {
                temp[k++] = a[j++];
            }

            for (int l = 0; l < temp.Length; l++)
            {
                a[left + l] = temp[l];
            }
        }
        private void MergeSort(int[] a, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(a, left, mid);
                MergeSort(a, mid + 1, right);
                Merge(a, left, mid, right);
            }
        }                  
    }
}