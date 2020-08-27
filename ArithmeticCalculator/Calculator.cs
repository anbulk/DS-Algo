using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticCalculator
{
    public class BinaryCalculator : ICalculator
    {

        

        public int Add(int x, int y)
        {
            while (y != 0)
            {
                int carry = x & y;


                x = x ^ y;

                y = carry << 1;

            }

            return x;

        }
    }
}
