using System;


namespace Lab3
{
    class RegularPolygon : Polygon
    {
        public override string ClassName { get { return "Regular polygon"; } }


        public RegularPolygon(params Point[] Vertexes) : base(Vertexes)
        {
            if (!this.IsRegular)
            {
                throw new Exception("RegularPolygon constructor => The polygon is not regular");
            }
        }

        public RegularPolygon(params double[] Vertexes) : base(Vertexes)
        {
            if (!this.IsRegular)
            {
                throw new Exception("RegularPolygon constructor => The polygon is not regular");
            }
        }


        public (double x, double y) Center
        {
            get
            {
                double SumX = 0;
                double SumY = 0;

                foreach (Point p in this.Vertexes)
                {
                    SumX += p.x;
                    SumY += p.y;
                }

                int NumberOfVertexes = this.Vertexes.Count;

                return (x: SumX / NumberOfVertexes, y: SumY / NumberOfVertexes);
            }
        }


        public bool IsRegular
        {
            get
            {
                double Distance(Point a, Point b) => Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2));

                (double x, double y) Center = this.Center;
                double DistanceFromCenter(Point a) => Math.Sqrt(Math.Pow((Center.x - a.x), 2) + Math.Pow((Center.y - a.y), 2));

                int NumberOfVertexes = this.Vertexes.Count;
                if (NumberOfVertexes > 3)
                {
                    for (int i = 0; i < NumberOfVertexes; i++)
                    {
                        Point Vertex1 = this.Vertexes[i];
                        Point Vertex2 = this.Vertexes[(i + 1) % NumberOfVertexes];
                        Point Vertex3 = this.Vertexes[(i + 2) % NumberOfVertexes];
                        Point Vertex4 = this.Vertexes[(i + 3) % NumberOfVertexes];

                        if (Distance(Vertex1, Vertex2) != Distance(Vertex2, Vertex3)
                         || Distance(Vertex1, Vertex3) != Distance(Vertex2, Vertex4)
                         || DistanceFromCenter(Vertex1) != DistanceFromCenter(Vertex2))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return Distance(Vertexes[0], Vertexes[1]) == Distance(Vertexes[1], Vertexes[2]) && Distance(Vertexes[1], Vertexes[2]) == Distance(Vertexes[2], Vertexes[0]);
                }

                return true;
            }
        }
    }
}