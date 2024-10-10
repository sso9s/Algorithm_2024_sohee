using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _006_ClosestPair
{
    // IComparer는 Array.Sort() 메소드에서 사용할 비교를 위한 인터페이스
    public class XComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            double diff = ((Point)x).X - ((Point)y).X;
            if (diff > 0)
                return 1;
            else if (diff < 0)
                return -1;
            else
                return 0; // X 좌표가 같은 경우
        }
    }

    public partial class MainWindow : Window
    {
        int noOfPoints;
        Point[] points;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            can.Children.Clear();
            noOfPoints = int.Parse(txtNo.Text);
            points = new Point[noOfPoints];
            MakePointArray();
            SortPointArray();
        }

        private void SortPointArray()
        {
            IComparer xComp = new XComparer();
            Array.Sort(points, xComp);
        }

        private void PrintPoints()
        {
            //foreach(Point p in points)
            for (int i = 0; i < noOfPoints; i++)
            {
                Console.WriteLine(points[i].X + ", " + points[i].Y);
            }
        }

        // random하게 점의 좌표를 만들고 배열에 저장
        private void MakePointArray()
        {
            Random r = new Random();

            for (int i = 0; i < noOfPoints; i++)
            {
                points[i] = new Point(r.NextDouble() * can.Width,
                  r.NextDouble() * can.Height);
            }
            foreach (var p in points)
            {
                Rectangle rect = new Rectangle();
                rect.Width = rect.Height = 3;
                rect.Stroke = Brushes.Black;
                Canvas.SetLeft(rect, p.X - 1);
                Canvas.SetTop(rect, p.Y - 1);
                can.Children.Add(rect);
            }
        }

        // Brute Force 방법
        private void btnBrute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            PointPair result = FindClosestPair(points, 0, noOfPoints - 1);
            watch.Stop();
            long tickBF = watch.ElapsedTicks;
            long msBF = watch.ElapsedMilliseconds;
            MessageBox.Show("BF: " + tickBF + " ticks, " + msBF + "ms");

            HighLight(result);
            MessageBox.Show(String.Format("({0},{1})-({2},{3}) = {4}",
              result.P1.X, result.P1.Y, result.P2.X, result.P2.Y,
              result.Dist));
        }

        private void HighLight(PointPair result)
        {
            // 사각형으로 두 점을 둘러싸도록 그린다
            int size = 12;
            Rectangle r = new Rectangle();
            double left = 0;
            if (result.P1.X < result.P2.X)
            {
                r.Width = result.P2.X - result.P1.X + size;
                left = result.P1.X - size / 2;
            }
            else
            {
                r.Width = result.P1.X - result.P2.X + size;
                left = result.P2.X - size / 2;
            }

            double top = 0;
            if (result.P1.Y < result.P2.Y)
            {
                r.Height = result.P2.Y - result.P1.Y + size;
                top = result.P1.Y - size / 2;
            }
            else
            {
                r.Height = result.P1.Y - result.P2.Y + size;
                top = result.P2.Y - size / 2;
            }

            r.Stroke = Brushes.Red;
            r.StrokeThickness = 1;
            Canvas.SetLeft(r, left);
            Canvas.SetTop(r, top);
            can.Children.Add(r);
        }


        private void btnDivde_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            PointPair result = FindClosestPairDC(points, 0, noOfPoints - 1);
            watch.Stop();
            long tickDC = watch.ElapsedTicks;
            long msDC = watch.ElapsedMilliseconds;
            MessageBox.Show("DC: " + tickDC + " ticks, " + msDC + "ms");

            HighLight(result);
            MessageBox.Show(String.Format("({0},{1})-({2},{3}) = {4}",
              result.P1.X, result.P1.Y, result.P2.X, result.P2.Y,
              result.Dist));
        }

        private PointPair FindClosestPairDC(Point[] points, int left, int right)
        {
            Console.WriteLine("FCDC(" + left + ", " + right + ")");
            if (right - left <= 100)   // 점의 갯수가 100 이상일 때 분할 // 원래 3인데 100으로 해야 더 빠름(교수님 say)
                return FindClosestPair(points, left, right);

            int mid = (left + right) / 2;
            CenterLine(points[mid].X);

            PointPair cPL = FindClosestPairDC(points, left, mid);
            PointPair cPR = FindClosestPairDC(points, mid + 1, right);
            double d = Math.Min(cPL.Dist, cPR.Dist);
            PointPair cPC = FindMidRange(points, mid, d);

            return MinPointPair(cPL, cPR, cPC);
        }

        private void CenterLine(double mid)
        {
            Line line = new Line();
            line.X1 = line.X2 = mid;
            line.Y1 = 0;
            line.Y2 = can.Height;
            line.Stroke = Brushes.Blue;
            line.StrokeThickness = 1;
            can.Children.Add(line);
        }

        private PointPair MinPointPair(PointPair cPL, PointPair cPR, PointPair cPC)
        {
            if (cPL.Dist <= cPR.Dist && cPL.Dist <= cPC.Dist)
                return cPL;
            else if (cPR.Dist <= cPL.Dist && cPR.Dist <= cPC.Dist)
                return cPR;
            else
                return cPC;
        }

        private PointPair FindMidRange(Point[] points, int mid, double d)
        {
            int left = 0, right = 0;

            for (int i = mid; i >= 0; i--)
                if (points[mid].X - points[i].X > d)
                {
                    left = i;
                    break;
                }

            for (int i = mid; i < points.Length; i++)
                if (points[i].X - points[mid].X > d)
                {
                    right = i;
                    break;
                }

            return FindClosestPair(points, left, right);
        }

        private double Dist(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private PointPair FindClosestPair(Point[] points, int start, int end)
        {
            double min = double.MaxValue;
            int minI = 0, minJ = 0;

            for (int i = start; i < end - 1; i++)
                for (int j = i + 1; j < end; j++)
                    if (Dist(points[i], points[j]) < min)
                    {
                        min = Dist(points[i], points[j]);
                        minI = i;
                        minJ = j;
                    }

            PointPair pp = new PointPair(points[minI], points[minJ], min);
            return pp;
        }
    }
}

