using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;

namespace ManageStudent.Class
{
    public class Grade 
    {
        private int id;
        private string idStudent;
        private string name;
        private double math;
        private double physical;
        private double chemistry;
        private double averagePoint;
        private string rank;
        public Grade() { }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string IdStudent1 { get => idStudent; set => idStudent = value; }
        public double Math { get => math; set => math = value; }
        public double Physical { get => physical; set => physical = value; }
        public double Chemistry { get => chemistry; set => chemistry = value; }
        public double AveragePoint { get => averagePoint; set => averagePoint = (Math+Chemistry+Physical)/3; }
        public string Rank { get => rank; set => rank=_Rank(); }
        public string _Rank()
        {
            if (AveragePoint>=8)
            {
                return "Excellent";
            }
            else if(8>AveragePoint&&AveragePoint>=6.5)
            {
                return "Good";
            }
            else if(AveragePoint<=6.5&&AveragePoint>=5)
            {
                return "Average";
            }
            else
            {
                return "Weak";
            }
        }
      
    }
    
}