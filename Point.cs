using System;


namespace Lab3
{
    class Point
    {
        public double x;
        public double y;


        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public void Print()
        {
            Console.WriteLine($"({this.x}; {this.y})\n");
        }
    }
}