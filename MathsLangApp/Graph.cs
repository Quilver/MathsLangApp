using MathsLangApp.Language;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MathsLangApp
{
    //This references the code I found in:
    //https://www.smokycogs.com/blog/a-mathematical-graphing-application-in-c-sharp/
    //I split the code into two functions: one that handles the background and one that draws a line
    //The line draw function has been further modified to 
    public partial class Graph : UserControl
    {
        public Color axisColor = Color.Black;
        public Color drawColor = Color.Red;
        public Color gridColor = Color.LightGray;
        public Color backgroundColor = Color.White;
        public int axisFontSize = 5;
        public Boolean drawAxes = true;
        public Boolean drawGrid = true;

        public Graph()
        {
            //InitializeComponent();
        }
        public Bitmap GetBackground(int width, int height, double xScale=10, double yScale=10)
        {
            Bitmap image = new Bitmap(width, height);
            int midX = width / 2;
            int midY = height / 2;
            double xLabelIncrement = xScale / 10;
            double yLabelIncrement = yScale / 10;
            double xOffset = 0;
            double yOffset = 0;
            Graphics g = Graphics.FromImage(image);
            SolidBrush backgroundBrush = new SolidBrush(backgroundColor);
            SolidBrush axisBrush = new SolidBrush(axisColor);
            SolidBrush drawBrush = new SolidBrush(drawColor);
            SolidBrush gridBrush = new SolidBrush(gridColor);

            Pen drawPen = new Pen(drawColor);
            Pen axisPen = new Pen(axisColor);
            Pen gridPen = new Pen(gridColor);
            Font axisFont = new Font(FontFamily.GenericSansSerif, axisFontSize);
            //Clear background  
            g.FillRectangle(backgroundBrush, 0, 0, width, height);

            //Draw Axes  
            if (drawAxes)
            {
                g.DrawLine(axisPen, 0, midY, width, midY);
                g.DrawLine(axisPen, midX, 0, midX, height);

                //draw labels  
                float xIncrementSize = (float)(width*xLabelIncrement/xScale)/2;

                float curX = midX;
                while (curX < width)
                {
                    if (curX != midX)
                    {
                        if (drawGrid)
                        {
                            g.DrawLine(gridPen, curX, 0, curX, height);
                        }
                        g.DrawLine(axisPen, curX, midY, curX, midY + 3);
                        double label = 100 * (curX/midX) * (xLabelIncrement / xScale) - 10;
                        g.DrawString(Math.Round(label, 2).ToString(), axisFont, axisBrush, curX - 3, midY + 5);
                    }
                    curX += xIncrementSize;
                }
                curX = midX;
                while (curX > 0)
                {
                    if (curX != midX)
                    {
                        if (drawGrid)
                        {
                            g.DrawLine(gridPen, curX, 0, curX, height);
                        }
                        g.DrawLine(axisPen, curX, midY, curX, midY + 3);
                        double label = 100 * (curX / midX) * (xLabelIncrement / xScale) - 10;
                        g.DrawString(Math.Round(label, 2).ToString(), axisFont, axisBrush, curX - 3, midY + 5);
                    }
                    curX -= xIncrementSize;

                }

                float yIncrementSize = (float)(height * yLabelIncrement / yScale) / 2;

                float curY = midY;
                while (curY < height)
                {
                    if (curY != midY)
                    {
                        if (drawGrid)
                        {
                            g.DrawLine(gridPen, 0, curY, width, curY);
                        }
                        g.DrawLine(axisPen, midX, curY, midX + 3, curY);
                        double label = 100 * (curY / midY) * (yLabelIncrement / yScale) - 10;
                        g.DrawString(Math.Round(-label, 2).ToString(), axisFont, axisBrush, midX + 5, curY - 3);
                    }
                    curY += yIncrementSize;
                }
                curY = midY;
                while (curY > 0)
                {
                    if (curY != midY)
                    {
                        if (drawGrid)
                        {
                            g.DrawLine(gridPen, 0, curY, width, curY);
                        }
                        g.DrawLine(axisPen, midX, curY, midX + 3, curY);
                        double label = 100 * (curY / midY) * (yLabelIncrement / yScale) - 10;
                        g.DrawString(Math.Round(-label,2).ToString(), axisFont, axisBrush, midX + 5, curY - 3);
                    }
                    curY -= yIncrementSize;
                }

            }
            return image;
        }
        public Bitmap DrawLine(Bitmap graph, string equation, double xScale=10, double yScale = 10)
        {
            Graphics g = Graphics.FromImage(graph);
            SolidBrush drawBrush = new SolidBrush(drawColor);
            Pen drawPen = new Pen(drawColor);
            int width = graph.Width;
            int height = graph.Height;
            int midX = width / 2;
            int midY = height / 2;
            //Draw graph  
            float prevX = 0;
            float prevY = 0;
            double x = 0;
            double y = 0;
            float xImage = 0;
            float yImage = 0;
            Parser parser= new Parser();
            for (int i = 0; i < width; i++)
            {

                x = ((double)(i - midX) * xScale);
                x /= midX;
                var output = parser.Parse(equation, x.ToString());
                if (output.type == ReturnType.DivideByZero || output.type== ReturnType.NumberTooLarge) continue;
                y = midX * output.outputNum;

                xImage = i;
                yImage = (int)(y * (-1) / yScale) + midY;
                if (i > 0)
                {
                    g.DrawLine(drawPen, prevX, prevY, xImage, yImage);
                }
                prevX = xImage;
                prevY = yImage;
            }
            return graph;
        }
       
    }
}