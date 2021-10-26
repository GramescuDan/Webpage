using System;

namespace As_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Square a = new Square(4);
            Circle b = new Circle(3);
            RightAngle c = new RightAngle(4, 3);
            a.printshapes();
            Console.WriteLine("Square area: {0}\nCircle area: {1}\nRightAngle area {2}",a.areaCalculator(),b.areaCalculator(),c.areaCalculator());
        }
    }
    abstract class Shape
    {
        private static int shapes = 0;

        double areaCalculator()
        {
            return 0;
        }
        public void printshapes()
        {
            Console.WriteLine(shapes);
        }
        public void addshape()
        {
            Shape.shapes += 1;
        }
    }
    class Square : Shape ,ICloneable
    {
        private int len { get; set; }

        public Square(int len) : base()
        {
            base.addshape();
            this.len = len;
        }

        public double areaCalculator()
        {
            
            return this.len * this.len;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
    class Circle : Shape
    {
        private int rad { get; set; }
        public Circle(int rad)
        {
            base.addshape();
            this.rad = rad;
        }
        public double areaCalculator()
        {
            return this.rad * this.rad * 3.14;
        }
        public double areaCalculator(double pi)
        {
            return this.rad * this.rad * pi;
        }
    }
    class RightAngle : Shape
    {
        private int width { get; set; }
        private int length { get; set; }

        public RightAngle(int length,int width)
        {
            base.addshape();
            this.length = length;
            this.width = width;
        }
        
        public double areaCalculator()
        {
            return this.length * this.width;
        }
    }
}
