using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab3
{
    class Figure
    {
        public virtual string ClassName { get { return "Figure"; } }

        public List<Point> Vertexes = new List<Point>();


        public Figure(params Point[] Vertexes)
        {
            if (Vertexes.Length < 3)
            {
                throw new Exception("Figure constructor => Figure must have at least 3 vertexes");
            }

            this.Vertexes = Vertexes.ToList();
        }

        public Figure(params double[] Coords)
        {
            if (Coords.Length % 2 == 1)
            {
                throw new Exception("Figure constructor => Number of coordinates must be even");
            }

            if (Coords.Length < 6)
            {
                throw new Exception("Figure constructor => Figure must have at least 3 vertexes");
            }

            for (int i = 0; i < Coords.Length / 2; i++)
            {
                double x = Coords[2 * i];
                double y = Coords[2 * i + 1];
                Point NewVertex = new Point(x, y);
                this.Vertexes.Add(NewVertex);
            }
        }


        public Point this[int i]
        {
            get
            {
                return this.Vertexes[i];
            }
        }


        public void Print()
        {
            Console.WriteLine(this.ClassName);

            foreach (Point p in this.Vertexes)
            {
                Console.Write($"({p.x}; {p.y}) ");
            }

            Console.WriteLine("\b\n");
        }


        public double Perimeter
        {
            get
            {
                double Distance(Point a, Point b) => Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2));

                double P = 0;

                int NumberOfVertexes = this.Vertexes.Count;
                for (int i = 0; i < NumberOfVertexes; i++)
                {
                    Point Vertex1 = this[i];
                    Point Vertex2 = this[(i + 1) % NumberOfVertexes];
                    P += Distance(Vertex1, Vertex2);
                }

                return P;
            }
        }


        public double Area
        {
            get
            {
                double S = 0;

                int NumberOfVertexes = this.Vertexes.Count;
                for (int i = 0; i < NumberOfVertexes; i++)
                {
                    Point Vertex1 = this[i];
                    Point Vertex2 = this[(i + 1) % NumberOfVertexes];

                    S += (Vertex1.x * Vertex2.y - Vertex1.y * Vertex2.x);
                }

                S = Math.Abs(S / 2);

                return S;
            }
        }


        public void MoveOnVector(double VectorX, double VectorY)
        {
            foreach (Point p in this.Vertexes)
            {
                p.x += VectorX;
                p.y += VectorY;
            }
        }


        public void MultiplyRadiusVector(double Multiply)
        {
            foreach (Point p in this.Vertexes)
            {
                p.x *= Multiply;
                p.y *= Multiply;
            }
        }
    }
}