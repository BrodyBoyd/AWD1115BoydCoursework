using System;
using System.Collections.Generic;
using System.Text;

namespace project11
{
    public record Student
    {
        public string Name { get; init; }
        private double _gpa;
        public double GPA
        {
            get => _gpa;
            init
            {
                if (value < 0 || value > 4.0)
                    throw new ArgumentOutOfRangeException(nameof(value), "GPA must be between 0 and 4");
                _gpa = value;
            } 
        }
        public Student(string name, double gpa)
        {
            Name = name;
            GPA = gpa;
        }
    }

}
