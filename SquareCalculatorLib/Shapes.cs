using System.Reflection.Metadata.Ecma335;

namespace SquareCalculatorLib
{
    public class Triangle : IShape
    {
        private readonly double A, B, C;

        /// <summary>
        /// Возвращает true, если треугольник является прямоугольным
        /// </summary>
        public bool IsRightAngled 
        {
            get
            {
                var sides = new double[] { A, B, C };
                Array.Sort(sides);
                return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
            }
        }

        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="a">Длина первой стороны (в сантиметрах)</param>
        /// <param name="b">Длина второй стороны (в сантиметрах)</param>
        /// <param name="c">Длина третьей стороны (в сантиметрах)</param>
        public Triangle(double a, double b, double c) 
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException("Длина каждой стороны должна быть больше нуля");

            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <param name="round">Округление площади, по умолчанию true (округлять)</param>
        /// <param name="digits">Количество цифр после запятой при округлении, по умолчанию 2</param>
        /// <returns></returns>
        public double SquareCalculate(bool round = false, int digits = 2)
        {
            double halfPerimeter = (A + B + C) / 2;
            double square = Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
            return round ? Math.Round(square, digits) : square;
        }
    }

    public class Circle : IShape
    {
        private readonly double radius;

        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="r">Радиус круга (в сантиметрах)</param>
        public Circle(double r)
        {
            if (r <= 0)
                throw new ArgumentOutOfRangeException("Радиус должен быть больше нуля");

            this.radius = r;
        }

        /// <summary>
        /// Расчет площади круга
        /// </summary>
        /// <param name="round">Округление площади, по умолчанию true (округлять)</param>
        /// <param name="digits">Количество цифр после запятой при округлении, по умолчанию 2</param>
        /// <returns></returns>
        public double SquareCalculate(bool round = false, int digits = 2)
        {
            double square = Math.PI * radius * radius;
            return round ? Math.Round(square, digits) : square;
        }
    }
}