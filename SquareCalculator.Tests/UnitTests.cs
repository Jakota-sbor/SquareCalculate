using SquareCalculatorLib;

namespace SquareCalculatorLib.Tests
{
    [TestClass]
    public class SquareCalculatorTests
    {
        [TestMethod("1. ����� ������� ������� � ������� ��� ������ (null)")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoShapeCalculateSquare_ThrowsException()
        {
            ShapeCalculator.CalculateSquare(null);
        }

        [TestMethod("2. ������������� ������������ � ������������� ������")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTriangleWithAnyNegativeOrZeroSideLength_ThrowsException()
        {
            var _ = new Triangle(-1, 1, 0);
        }

        [TestMethod("3. ������������� ����� � ������������� ��������")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateCircleWithAnyNegativeOrZeroRadius_ThrowsException()
        {
            var _ = new Circle(-1);
        }

        [TestMethod("4. ����������� �������� �������������")]
        public void TriangleCheckIsRightAngled()
        {
            var triangle = new Triangle(4, 3, 5);
            Assert.IsTrue(triangle.IsRightAngled);
        }

        [TestMethod("5. ����������� �� �������� �������������")]
        public void TriangleCheckIsNotRightAngled()
        {
            var triangle = new Triangle(1, 3, 2);
            Assert.IsFalse(triangle.IsRightAngled);
        }

        [TestMethod("6. ������ ������� ������������ ��� ����������")]
        public void TriangleCalculateSquareNoRound()
        {
            var triangle = new Triangle(4, 4, 4);
            var square = triangle.SquareCalculate();
            Assert.AreEqual(6.9282032302755088, square);
        }

        [TestMethod("7. ������ ������� ������������ � �����������")]
        public void TriangleCalculateSquareWithRound()
        {
            var triangle = new Triangle(4, 4, 4);
            var square = triangle.SquareCalculate(true, 2);
            Assert.AreEqual(6.93, square);
        }

        [TestMethod("8. ������ ������� ����� ��� ����������")]
        public void CircleCalculateSquare()
        {
            var circle = new Circle(3);
            var square = circle.SquareCalculate();
            Assert.AreEqual(Math.PI * 9, square);
        }

        [TestMethod("9. ������ ������� ����������� �� ����� ���������� ������")]
        public void UnknowShapeTypeCalculateSquare()
        {
            IShape circle = new Circle(3);
            var square = ShapeCalculator.CalculateSquare(circle);
            Assert.AreEqual(Math.PI * 9, square);
        }
    }
}