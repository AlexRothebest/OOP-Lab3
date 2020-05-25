using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon a = new Polygon(1, 2, 3, 1, 4, 3, 2, 4);
            a.Print();

            Console.WriteLine(a.Perimeter);
            Console.WriteLine(a.Area);

            a[1].Print();

            a.MoveOnVector(6, 7);
            a.Print();

            a.MultiplyRadiusVector(0.133);
            a.Print();

            RegularPolygon b = new RegularPolygon(1, 1, 1, 4, 4, 4, 4, 1);
            b.Print();

            RegularPolygon c = new RegularPolygon(1, 1, 2, 4, 4, 4, 4, 1);
            c.Print();
        }
    }
}