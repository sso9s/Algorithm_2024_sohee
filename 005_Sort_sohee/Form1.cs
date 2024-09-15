using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms.DataVisualization.Charting;

namespace _005_Sort_sohee
{
    public partial class Form1 : Form
    {
        static int MAX = 1000000; // 100만
        int[] a = new int[MAX];
        int N = 0; // 데이터 갯수

        Random r = new Random();

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
                DisplayChart(); // 그래프 표시
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

            // 버블정렬 데이터와 함께 결과를 출력
            PrintData("버블 정렬 결과:", true);
            long tickBubble = watch.ElapsedTicks;
            long msBubble = watch.ElapsedMilliseconds;
            txtBubble.Text = "버블 정렬 : " + tickBubble + " Ticks, "
                + msBubble + " ms";
            DisplayChart(); // 그래프 표시


            watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(a, 0, N - 1);
            watch.Stop();

            // 버블정렬 데이터와 함께 결과를 출력
            PrintData("퀵 정렬 결과:", true);
            long tickQuick = watch.ElapsedTicks;
            long msQuick = watch.ElapsedMilliseconds;
            txtQuick.Text = "퀵 정렬 : " + tickQuick + " Ticks, "
                + msQuick + " ms";
            DisplayChart(); // 그래프 표시


            watch = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(a, 0, N - 1);
            watch.Stop();

            // 합병정렬 데이터와 함께 결과를 출력
            PrintData("합병 정렬 결과:", true);
            long tickMerge = watch.ElapsedTicks;
            long msMerge = watch.ElapsedMilliseconds;
            txtMerge.Text = "합병 정렬 : " + tickMerge + " Ticks, "
                + msMerge + " ms";
            DisplayChart(); // 그래프 표시

            Randomize();
        }
  
        private void DisplayChart()
        {
            // 차트 컨트롤의 모든 요소를 완전히 지웁니다
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // 새로운 차트 영역 생성
            ChartArea chartArea = new ChartArea
            {
                Name = "MainChartArea",
                BackColor = Color.White, // 차트 영역의 배경색 설정
                AxisX = { Title = "랜덤 숫자", Minimum = 0, Maximum = N + 1 }, // X축 설정
                AxisY = { Title = "정렬!", Interval = 1, Minimum = a.Min() - 1, Maximum = a.Max() + 2 } // Y축 설정
            };

            // X축과 Y축의 그리드 라인 제거
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;

            // X축과 Y축의 축선 제거
            chartArea.AxisX.MajorTickMark.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisX.MinorTickMark.Enabled = false;
            chartArea.AxisY.MinorTickMark.Enabled = false;

            // Y축 레이블 제거
            chartArea.AxisY.LabelStyle.Enabled = false;

            // 차트 영역을 차트에 추가
            chart1.ChartAreas.Add(chartArea);

            // 새로운 시리즈 생성
            var series = new Series
            {
                Name = "SortedData",
                Color = Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            // 시리즈를 차트에 추가
            chart1.Series.Add(series);

            // 데이터 추가
            for (int i = 0; i < N; i++)
            {
                series.Points.AddXY(i, a[i]);
            }

            // 차트 갱신
            chart1.Invalidate(); // 차트 갱신
            chart1.Update();     // 추가 갱신
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

        private void QuickSort(int[] a, int low, int high)
        {
            while (low < high)
            {
                int pivotIndex = partition(a, low, high);
                if (pivotIndex - low < high - pivotIndex)
                {
                    QuickSort(a, low, pivotIndex - 1);
                    low = pivotIndex + 1;
                }
                else
                {
                    QuickSort(a, pivotIndex + 1, high);
                    high = pivotIndex - 1;
                }
            }
        }

        private int partition(int[] a, int low, int high)
        {
            // 피벗을 배열의 중간값으로 선택
            int mid = (low + high) / 2;
            int pivot = a[mid];
            Swap(a, mid, high); // 피벗을 배열의 끝으로 이동

            int i = low;
            for (int j = low; j < high; j++)
            {
                if (a[j] <= pivot)
                {
                    Swap(a, i, j);
                    i++;
                }
            }
            Swap(a, i, high);
            return i;
        }


        private static void Swap(int[] arr, int a, int b)
        {
            // 인덱스가 유효한지 확인
            if (a < 0 || a >= arr.Length || b < 0 || b >= arr.Length)
                throw new ArgumentOutOfRangeException("인덱스가 배열의 범위를 초과합니다.");

            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        void Merge(int[] a, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // 왼쪽 부분 배열 복사
            Array.Copy(a, left, leftArr, 0, n1);

            // 오른쪽 부분 배열 복사
            Array.Copy(a, mid + 1, rightArr, 0, n2);

            int i = 0, j = 0, k = left;

            // 병합 과정
            while (i < n1 && j < n2)
            {
                if (leftArr[i] <= rightArr[j])
                    a[k++] = leftArr[i++];
                else
                    a[k++] = rightArr[j++];
            }

            // 남아 있는 왼쪽 배열 요소 복사
            while (i < n1)
                a[k++] = leftArr[i++];

            // 남아 있는 오른쪽 배열 요소 복사
            while (j < n2)
                a[k++] = rightArr[j++];
        }

        void MergeSort(int[] a, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(a, left, mid); // 왼쪽 부분 정렬
                MergeSort(a, mid + 1, right); // 오른쪽 부분 정렬
                Merge(a, left, mid, right); // 병합
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}