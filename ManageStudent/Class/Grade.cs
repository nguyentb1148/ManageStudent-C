using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;

namespace ManageStudent.Class
{
    public class Grade : Student 
    {
        private static List<Grade> listGrade = new List<Grade>();
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
        public void Add()
        {
            foreach (Student s in listStudents)
            {
                Grade grade = new Grade();
                grade.Id = s.ID;
                grade.Name = s.FullName;
                grade.IdStudent1 = s.IdStudent;
                grade.Math = 0;
                grade.Physical = 0;
                grade.Chemistry = 0;
                grade.AveragePoint = grade.AveragePoint;
                grade.Rank = "";
                listGrade.Add(grade);
            }
        }
        public void ViewGrade()
        {
            var table = new Table();

            
            table.SetHeaders("No","Id student","Name","Math","Physical","Chemistry","Average","Rank");

            foreach (Grade i in listGrade)
            {
                table.AddRow($"{i.Id}",i.IdStudent1,i.Name,$"{i.Math}",$"{i.Physical}",$"{i.Chemistry}",
                    $"{i.AveragePoint}",i.Rank);
            }
            Console.WriteLine(table.ToString());
        }
        public void SearchGrade(string search)
        {
            Boolean found = false;
            foreach (Grade i in listGrade)
            {
                if (search.Equals(i.IdStudent1))
                {
                    var table = new Table();
                    table.SetHeaders("No","Id student","Name","Math","Physical","Chemistry","Average","Rank");
                    
                    table.AddRow($"{i.Id}",i.IdStudent1,i.Name,$"{i.Math}",$"{i.Physical}",$"{i.Chemistry}",
                        $"{i.AveragePoint}",i.Rank);
                    Console.WriteLine(table.ToString());
                    found = true;
                }
            }
            if (found==false)
            {
                Console.WriteLine("No student have id : "+search);
            }
        }
        public void UpdateGrade()
        {
            Boolean found = false;
            Console.Write("Input Id student to search: ");
            string search=Console.ReadLine();
            string search1 = search.ToUpper();
            foreach (Grade i in listGrade)
            {
                if (search1.Equals(i.IdStudent1))
                {
                    var table = new Table();
                    table.SetHeaders("No", "Id student", "Name", "Math", "Physical", "Chemistry", "Average", "Rank");
                    table.AddRow($"{i.Id}", i.IdStudent1, i.Name, $"{i.Math}", $"{i.Physical}", $"{i.Chemistry}",
                        $"{i.AveragePoint}", i.Rank);
                    Console.WriteLine(table.ToString());
                    found = true;
                    Console.Write("Enter math point: ");
                    double math = double.Parse(Console.ReadLine());
                    while (math < 0 || math > 10)
                    {
                        Console.WriteLine("Wrong point!! ");
                        Console.Write("Enter math point: ");
                        math = double.Parse(Console.ReadLine());
                    }
                    i.Math = math;
                    Console.Write("Enter physical point: ");
                    double physical = double.Parse(Console.ReadLine());
                    while (physical < 0 || physical > 10)
                    {
                        Console.WriteLine("Wrong point !! ");
                        Console.Write("Enter physical point: ");
                        physical = double.Parse(Console.ReadLine());
                    }
                    i.Physical = physical;
                    Console.Write("Enter chemistry point: ");
                    double chemistry = double.Parse(Console.ReadLine());
                    while (chemistry < 0 || chemistry > 10)
                    {
                        Console.WriteLine("Wrong point!! ");
                        Console.Write("Enter chemistry point: ");
                        chemistry = double.Parse(Console.ReadLine());
                    }
                    i.Chemistry = chemistry;
                    i.AveragePoint = i.AveragePoint;
                    i.Rank = i.Rank;
                    Console.WriteLine("Update successfully.");
                }
            }
        }
        public void DeleteGrade()
        {
            Boolean found = false;
            Console.Write("Input Id student to search: ");
            string search=Console.ReadLine();
            foreach (Grade i in listGrade)
            {
                if (search.Equals(i.IdStudent1))
                {
                    var table = new Table();
                    table.SetHeaders("No", "Id student", "Name", "Math", "Physical", "Chemistry", "Average", "Rank");

                    table.AddRow($"{i.Id}", i.IdStudent1, i.Name, $"{i.Math}", $"{i.Physical}", $"{i.Chemistry}",
                        $"{i.AveragePoint}", i.Rank);
                    Console.WriteLine(table.ToString());
                }
                i.Math = 0;
                i.Physical = 0;
                i.Chemistry = 0;
                i.AveragePoint = 0;
                i.Rank = "";
                found = true;
            }
            if (found==true)
            {
                Console.WriteLine("Delete grade successfully");
            }
            if (found==false)
            {
                Console.WriteLine("No student have id : "+search);
                
            }
        }
    }
    
}