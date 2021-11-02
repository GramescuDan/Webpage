using System;

namespace As_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new Square(4);
            var b = new Circle(3);
            var c = new RightAngle(4, 3);
            a.printshapes();
            Console.WriteLine("Square area: {0}\nCircle area: {1}\nRightAngle area {2}", a.areaCalculator(),
                b.areaCalculator(), c.areaCalculator());
        }
    }

    internal abstract class Shape
    {
        private static int shapes;

        private double areaCalculator()
        {
            return 0;
        }

        public void printshapes()
        {
            Console.WriteLine(shapes);
        }

        public void addshape()
        {
            shapes += 1;
        }
    }

    internal class Square : Shape
    {
        public Square(int len)
        {
            addshape();
            this.len = len;
        }

        private int len { get; }

        public double areaCalculator()
        {
            return len * len;
        }
    }

    internal class Circle : Shape
    {
        public Circle(int rad)
        {
            addshape();
            this.rad = rad;
        }

        private int rad { get; }

        public double areaCalculator()
        {
            return rad * rad * 3.14;
        }

        public double areaCalculator(double pi)
        {
            return rad * rad * pi;
        }
    }

    internal class RightAngle : Shape
    {
        public RightAngle(int length, int width)
        {
            addshape();
            this.length = length;
            this.width = width;
        }

        private int width { get; }
        private int length { get; }

        public double areaCalculator()
        {
            return length * width;
        }
    }
}