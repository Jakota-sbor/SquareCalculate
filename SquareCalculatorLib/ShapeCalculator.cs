using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculatorLib
{
    /// <summary>
    /// Статичесский класс для использования внешними клиентами
    /// </summary>
    public static class ShapeCalculator
    {
        /// <summary>
        /// Расчет площади фигуры
        /// </summary>
        /// <param name="shape">Фигура (класс, реализующий интерфейс IShape)</param>
        /// <param name="round">Округление площади, по умолчанию true (округлять)</param>
        /// <param name="digits">Количество цифр после запятой при округлении, по умолчанию 2</param>
        /// <returns>Площадь фигуры</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double CalculateSquare(IShape shape, bool round = false, int digits = 2)
        {
            if (shape == null) 
                throw new ArgumentNullException("Ссылка на объект не указывает на экземпляр объекта");

            return shape.SquareCalculate(round, digits);
        }
    }
}
