using System;
using System.Collections.Generic;
using System.Text;

namespace project11
{
    public static class StudentExtensions
    {
        extension(Student s)
        {
            public string GetLetterGrade()
            {
                if (s.GPA >= 3.7)
                {
                    return "Letter Grade is an A";
                }
                if (s.GPA >= 2.7)
                {
                    return "Letter Grade is a B";
                }
                if (s.GPA >= 1.5)
                {
                    return "Letter Grade is a C";
                }
                if (s.GPA >= 0.5)
                {
                    return "Letter Grade is a D";
                }
                else
                {     
                    return "Letter Grade is a F";
                }

            }
            public bool IsHonorRole()
            {
                if (s.GPA >= 2.7)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public static double MinimiumPassingGpa => 2.7;
    }
    }
}
