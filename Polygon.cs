using System;


namespace Lab3
{
    class Polygon : Figure
    {
        public override string ClassName { get { return "Polygon"; } }


        public Polygon(params Point[] Vertexes) : base(Vertexes)
        {
            if (this.IsSelfIntersecting)
            {
                throw new Exception("Polygon constructor => The polygon is self-intersecting");
            }
        }

        public Polygon(params double[] Vertexes) : base(Vertexes)
        {
            if (this.IsSelfIntersecting)
            {
                throw new Exception("Polygon constructor => The polygon is self-intersecting");
            }
        }


        public bool IsSelfIntersecting
        {
            get
            {
                int NumberOfVertexes = this.Vertexes.Count;
                for (int i = 0, j = 1; i < NumberOfVertexes - 1; i++, j = (j + 1) % NumberOfVertexes)
                {
                    for (int l = j, k = (j + 1) % NumberOfVertexes; l < NumberOfVertexes; l++, k = (k + 1) % NumberOfVertexes)
                    {
                        Point Vertex1 = Vertexes[i];
                        Point Vertex2 = Vertexes[j];
                        Point Vertex3 = Vertexes[l];
                        Point Vertex4 = Vertexes[k];

                        double x1 = Vertex1.x;
                        double y1 = Vertex1.y;
                        double x2 = Vertex2.x;
                        double y2 = Vertex2.y;
                        double x3 = Vertex3.x;
                        double y3 = Vertex3.y;
                        double x4 = Vertex4.x;
                        double y4 = Vertex4.y;

                        // Console.WriteLine($"({x1}; {y1}) - ({x2}; {y2})\n({x3}; {y3}) - ({x4}; {y4})");
                        if ((x1 - x2) * (y3 - y4) != (x3 - x4) * (y1 - y2))
                        {
                            double IntersectionX = ((x1 * y2 - x2 * y1) * (x3 - x4) - (x3 * y4 - x4 * y3) * (x1 - x2)) / ((x1 - x2) * (y3 - y4) - (x3 - x4) * (y1 - y2));
                            double IntersectionY = ((y1 * x2 - y2 * x1) * (y3 - y4) - (y3 * x4 - y4 * x3) * (y1 - y2)) / ((y1 - y2) * (x3 - x4) - (y3 - y4) * (x1 - x2));
                            // Console.WriteLine($"({IntersectionX}; {IntersectionY})\n");

                            if (Math.Min(x1, x2) < IntersectionX && IntersectionX < Math.Max(x1, x2)
                             || Math.Min(x3, x4) < IntersectionX && IntersectionX < Math.Max(x3, x4)
                             || Math.Min(y1, y2) < IntersectionY && IntersectionY < Math.Max(y1, y2)
                             || Math.Min(y3, y4) < IntersectionY && IntersectionY < Math.Max(y3, y4))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (x1 != x2 && y1 != y2)
                            {
                                bool SegmentsCollinear = (x1 - x2) / (y1 - y2) == (x1 - x3) / (y1 - y3);
                                if (SegmentsCollinear)
                                {
                                    bool SegmentsIntersect = (Math.Min(x1, x2) < x3 && x3 < Math.Max(x1, x2)) || (Math.Min(x1, x2) < x4 && x4 < Math.Max(x1, x2))
                                        || (j != k && (x1 == x3 || x1 == x4 || x2 == x3 || x2 == x4));

                                    if (SegmentsIntersect)
                                    {
                                        return true;
                                    }
                                }
                            }
                            else if (x1 == x2 && x2 == x3)
                            {
                                bool SegmentsIntersect = (Math.Min(y1, y2) < y3 && y3 < Math.Max(y1, y2)) || (Math.Min(y1, y2) < y4 && y4 < Math.Max(y1, y2))
                                    || (j != k && (y1 == y3 || y1 == y4 || y2 == y3 || y2 == y4));

                                if (SegmentsIntersect)
                                {
                                    return true;
                                }
                            }
                            else if (y1 == y2 && y2 == y3)
                            {
                                bool SegmentsIntersect = (Math.Min(x1, x2) < x3 && x3 < Math.Max(x1, x2)) || (Math.Min(x1, x2) < x4 && x4 < Math.Max(x1, x2))
                                    || (j != k && (x1 == x3 || x1 == x4 || x2 == x3 || x2 == x4));

                                if (SegmentsIntersect)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                return false;
            }
        }
    }
}