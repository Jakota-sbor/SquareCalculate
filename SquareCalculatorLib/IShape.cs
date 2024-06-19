using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculatorLib
{
    public interface IShape
    {
        public double SquareCalculate(bool round, int digits);
    }
}
