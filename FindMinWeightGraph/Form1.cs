using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMinWeightGraph
{
    public partial class Form1 : Form
    {
        private CalculateGraph calculateGraph = new CalculateGraph();
        
        private Point point1 = new Point(500, 50);
        private Point point2 = new Point(600, 50);
        private Point point3 = new Point(700, 150);
        private Point point4 = new Point(600, 250);
        private Point point5 = new Point(500, 250);
        private Point point6 = new Point(400, 150);

        private Point treePoint1 = new Point(730, 250);
        private Point treePoint2 = new Point(815, 350);
        private Point treePoint3 = new Point(900, 400);
        private Point treePoint4 = new Point(730, 400);
        private Point treePoint5 = new Point(800, 500);
        private Point treePoint6 = new Point(660, 500);


        public Form1()
        {
            InitializeComponent();
            FillTheFieldsInGraphFirstStart();
            calculateGraph.CalculateMinGraphWeight();
            FillInMinPathFields();
        }

        private void FillInMinPathFields()
        {
            label38.Text = (calculateGraph.list[0][0] + 1).ToString() + " - " + (calculateGraph.list[0][1] + 1).ToString();
            label41.Text = calculateGraph.list[0][2].ToString();

            label42.Text = (calculateGraph.list[1][0] + 1).ToString() + " - " + (calculateGraph.list[1][1] + 1).ToString();
            label44.Text = calculateGraph.list[1][2].ToString();

            label45.Text = (calculateGraph.list[2][0] + 1).ToString() + " - " + (calculateGraph.list[2][1] + 1).ToString();
            label47.Text = calculateGraph.list[2][2].ToString();

            label48.Text = (calculateGraph.list[3][0] + 1).ToString() + " - " + (calculateGraph.list[3][1] + 1).ToString();
            label50.Text = calculateGraph.list[3][2].ToString();

            label51.Text = (calculateGraph.list[4][0] + 1).ToString() + " - " + (calculateGraph.list[4][1] + 1).ToString();
            label53.Text = calculateGraph.list[4][2].ToString();

            if (calculateGraph.list.Count > 5)
            {
                label54.Text = (calculateGraph.list[5][0] + 1).ToString() + " - " + (calculateGraph.list[5][1] + 1).ToString();
                label56.Text = calculateGraph.list[5][2].ToString();
            }
            else
            {
                label54.Text = null;
                label56.Text = null;
            }

            int summ = 0;

            for (int i = 0; i < calculateGraph.list.Count; i++)
                summ += calculateGraph.list[i][2];

            label40.Text = summ.ToString();
        }

        private void FillTheFieldsInGraphFirstStart()
        {
            int count = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.Controls["textbox" + count.ToString()].Text = convertInputValue(calculateGraph.fullGraph, i, j);
                    count++;
                }
            }
        }
        private string convertInputValue(int[,] graph, int i, int j)
        {
            string text;

            if (graph[i, j] == int.MaxValue)
                text = "∞";
            else if (graph[i, j] == 0)
                text = "-";
            else
                text = graph[i, j].ToString();

            return text;
        }

        private void FillTheFieldsInGraph()
        {
            int count = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    calculateGraph.fullGraph[i, j] = convertOutputText(this.Controls["textbox" + count.ToString()].Text);
                    count++;
                }
            }
        }

        private int convertOutputText(string text)
        {
            int value;

            if (text == "-")
                value = 0;
            else if (text == "∞")
                value = int.MaxValue;
            else
                value = Convert.ToInt32(text);

            return value;
        }
               

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //graph points number
            e.Graphics.DrawString("1", new Font(Font, FontStyle.Bold), Brushes.Black, point1.X, point1.Y - 20);
            e.Graphics.DrawString("2", new Font(Font, FontStyle.Bold), Brushes.Black, point2.X, point2.Y - 20);
            e.Graphics.DrawString("3", new Font(Font, FontStyle.Bold), Brushes.Black, point3.X + 20, point3.Y);
            e.Graphics.DrawString("4", new Font(Font, FontStyle.Bold), Brushes.Black, point4.X, point4.Y + 20);
            e.Graphics.DrawString("5", new Font(Font, FontStyle.Bold), Brushes.Black, point5.X, point5.Y + 20);
            e.Graphics.DrawString("6", new Font(Font, FontStyle.Bold), Brushes.Black, point6.X - 20, point6.Y);
            
            //tree points number
            e.Graphics.DrawString("1", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint1.X, treePoint1.Y - 20);
            e.Graphics.DrawString("2", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint2.X, treePoint2.Y - 20);
            e.Graphics.DrawString("3", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint3.X + 10, treePoint3.Y);
            e.Graphics.DrawString("4", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint4.X, treePoint4.Y - 20);
            e.Graphics.DrawString("5", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint5.X + 10, treePoint5.Y);
            e.Graphics.DrawString("6", new Font(Font, FontStyle.Bold), Brushes.Black, treePoint6.X - 20, treePoint6.Y);
            
            
            DrawTree(e.Graphics);
            DrawGraph(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillTheFieldsInGraph();
            calculateGraph.CalculateMinGraphWeight();
            FillInMinPathFields();

            DrawGraph(this.CreateGraphics());
            DrawTree(this.CreateGraphics());
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculateGraph.fullGraph = new int[,]
            {
                {0, 5, 6, 9, int.MaxValue, int.MaxValue},
                {5, 0, 3, 3, int.MaxValue, 14},
                {6, 3, 0, 13, 4, 16},
                {9, 3, 13, 0, 3, 4},
                {int.MaxValue, int.MaxValue, 4, 3, 0, int.MaxValue},
                {int.MaxValue, 14, 16, 4, int.MaxValue, 0}
            };

            FillTheFieldsInGraphFirstStart();
            calculateGraph.CalculateMinGraphWeight();
            FillInMinPathFields();

            DrawGraph(this.CreateGraphics());
            DrawTree(this.CreateGraphics());
            this.Invalidate();
        }

        private void DrawGraph(Graphics e)
        {
            Pen pen1 = new Pen(Color.Blue, 3);
            Pen pen2 = new Pen(Color.Red, 3);
            Pen pen3 = new Pen(Color.Orange, 3);
            Pen pen4 = new Pen(Color.Green, 3);
            Pen pen5 = new Pen(Color.Yellow, 3);
            Pen pen6 = new Pen(Color.Purple, 3);

            Point[] points1 = new Point[12];
            Point[] points2 = new Point[12];
            Point[] points3 = new Point[12];
            Point[] points4 = new Point[12];
            Point[] points5 = new Point[12];
            Point[] points6 = new Point[12];

            Dictionary<string, Point> pointDict = new Dictionary<string, Point>();
            Dictionary<string, Point[]> pointsDict = new Dictionary<string, Point[]>();

            pointDict["p1"] = point1;
            pointDict["p2"] = point2;
            pointDict["p3"] = point3;
            pointDict["p4"] = point4;
            pointDict["p5"] = point5;
            pointDict["p6"] = point6;

            pointsDict["points1"] = points1;
            pointsDict["points2"] = points2;
            pointsDict["points3"] = points3;
            pointsDict["points4"] = points4;
            pointsDict["points5"] = points5;
            pointsDict["points6"] = points6;


            for (int i = 0; i < 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (calculateGraph.fullGraph[i, j] != 0)
                    {
                        pointsDict["points" + (i + 1)][count] = pointDict["p" + (i + 1)];
                        pointsDict["points" + (i + 1)][count + 1] = pointDict["p" + (j + 1)];
                        count += 2;
                    }
                    else
                    {
                        pointsDict["points" + (i + 1)][count] = pointDict["p" + (i + 1)];
                        pointsDict["points" + (i + 1)][count + 1] = pointDict["p" + (i + 1)];
                        count += 2;
                    }
                }
            }

            e.DrawLines(pen6, pointsDict["points6"]);
            e.DrawLines(pen5, pointsDict["points5"]);
            e.DrawLines(pen4, pointsDict["points4"]);
            e.DrawLines(pen3, pointsDict["points3"]);
            e.DrawLines(pen2, pointsDict["points2"]);
            e.DrawLines(pen1, pointsDict["points1"]);
        }
                
        private void DrawTree(Graphics e)
        {
            Dictionary<string, Point> pointDict = new Dictionary<string, Point>();
            Pen pen = new Pen(Color.Black, 5);
            Point[] treePoints = new Point[10];

            pointDict["p1"] = treePoint1;
            pointDict["p2"] = treePoint2;
            pointDict["p3"] = treePoint3;
            pointDict["p4"] = treePoint4;
            pointDict["p5"] = treePoint5;
            pointDict["p6"] = treePoint6;

            int count = 0;

            for (int i = 0; i < calculateGraph.list.Count; i++)
            {
                List<int> tempList = calculateGraph.list[i];

                treePoints[count] = pointDict["p" + (tempList[0] + 1)];
                treePoints[count + 1] = pointDict["p" + (tempList[1] + 1)];

                count += 2;
            }

            e.DrawLines(pen, treePoints);
        }
    }
}
