using System;
using System.Collections.Generic;
using System.Text;

namespace project11
{
    public ref struct TempGradeCalc: IGradeCalculator
    {
        public double Calc(double grade)
        {
            double curvedGrade = 0;

            curvedGrade = grade *  1.1;

            return curvedGrade;
        }
    }
}
