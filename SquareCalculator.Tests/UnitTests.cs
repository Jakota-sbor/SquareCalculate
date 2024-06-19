using SquareCalculatorLib;

namespace SquareCalculatorLib.Tests
{
    [TestClass]
    public class SquareCalculatorTests
    {
        [TestMethod("1. Вызов расчета площади у объекта без ссылки (null)")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoShapeCalculateSquare_ThrowsException()
        {
            ShapeCalculator.CalculateSquare(null);
        }

        [TestMethod("2. Инициализация треугольника с отрицательной длиной")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTriangleWithAnyNegativeOrZeroSideLength_ThrowsException()
        {
            var _ = new Triangle(-1, 1, 0);
        }

        [TestMethod("3. Инициализация круга с отрицательным радиусом")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateCircleWithAnyNegativeOrZeroRadius_ThrowsException()
        {
            var _ = new Circle(-1);
        }

        [TestMethod("4. Треугольник является прямоугольным")]
        public void TriangleCheckIsRightAngled()
        {
            var triangle = new Triangle(4, 3, 5);
            Assert.IsTrue(triangle.IsRightAngled);
        }

        [TestMethod("5. Треугольник не является прямоугольным")]
        public void TriangleCheckIsNotRightAngled()
        {
            var triangle = new Triangle(1, 3, 2);
            Assert.IsFalse(triangle.IsRightAngled);
        }

        [TestMethod("6. Расчет площади треугольника без округления")]
        public void TriangleCalculateSquareNoRound()
        {
            var triangle = new Triangle(4, 4, 4);
            var square = triangle.SquareCalculate();
            Assert.AreEqual(6.9282032302755088, square);
        }

        [TestMethod("7. Расчет площади треугольника с округлением")]
        public void TriangleCalculateSquareWithRound()
        {
            var triangle = new Triangle(4, 4, 4);
            var square = triangle.SquareCalculate(true, 2);
            Assert.AreEqual(6.93, square);
        }

        [TestMethod("8. Расчет площади круга без округления")]
        public void CircleCalculateSquare()
        {
            var circle = new Circle(3);
            var square = circle.SquareCalculate();
            Assert.AreEqual(Math.PI * 9, square);
        }

        [TestMethod("9. Расчет площади неизвестной во время компиляции фигуры")]
        public void UnknowShapeTypeCalculateSquare()
        {
            IShape circle = new Circle(3);
            var square = ShapeCalculator.CalculateSquare(circle);
            Assert.AreEqual(Math.PI * 9, square);
        }
    }
}