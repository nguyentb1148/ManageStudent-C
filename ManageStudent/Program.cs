using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using ConsoleTables;
using ManageStudent.Class;

namespace ManageStudent
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Student student = new Student();
      student.AddStudentList();
      MainMenu();
    }

    private static void MainMenu()
    {
      int choice;
      Console.WriteLine("+----------------------------+");
      Console.WriteLine("| STUDENTS MANAGEMENT SYSTEM |");
      Console.WriteLine("+----------------------------+");
      Console.WriteLine("|1. Manage Students          |");
      Console.WriteLine("|2. Manage Lectures          |");
      Console.WriteLine("|3. Exit                     |");
      Console.WriteLine("+----------------------------+");
      Console.Write("Your choice: ");
      choice = int.Parse(Console.ReadLine());
      switch (choice)
      {
        case 1:
          MenuStudent();
          break;
        case 2:
          MenuLecture();
          break;
        case 3:
          
          return;
      }
    }

    private static void MenuStudent()
    {
      Student student = new Student();
      student.AddStudentList();
      while (true)
      {
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("| STUDENTS MANAGEMENT SYSTEM |");
        Console.WriteLine("|----------------------------|");
        Console.WriteLine("|1. Add new Student          |");
        Console.WriteLine("|2. View all Students        |");
        Console.WriteLine("|3. Search Student           |");
        Console.WriteLine("|4. Delete Student           |");
        Console.WriteLine("|5. Update Student           |");
        Console.WriteLine("|6. Back to Main Menu        |");
        Console.WriteLine("+----------------------------+");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            student.AddNew();
            break;
          case 2:
            student.ViewList();
            break;
          case 3:
            student.Search();
            break;
          case 4:
            student.Delete();
            break;
          case 5 :
           student. Update();
            break;
          case 6:
            MainMenu();
            break;
        }
      }
    }
    private static void MenuLecture()
    {
      Lecture lecture = new Lecture();
      lecture.AddLectureList();
      while (true)
      {
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("| Lecture MANAGEMENT SYSTEM |");
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("|1. Insert new Lecture       |");
        Console.WriteLine("|2. View list of Lectures    |");
        Console.WriteLine("|3. Search Lecture           |");
        Console.WriteLine("|4. Delete Lecture           |");
        Console.WriteLine("|5. Update Lecture           |");
        Console.WriteLine("|6. Grade Menu               |");
        Console.WriteLine("|7. Back to Main Menu        |");
        Console.WriteLine("+----------------------------+");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            lecture.AddNew();
            break;
          case 2:
            lecture.ViewList();
            break;
          case 3:
            lecture.Search();
            break;
          case 4:
            lecture.Delete();
            break;
          case 5:
            lecture.Update();
            break;
          case 6:
            MenuGrade();
            break;
          case 7:
            MainMenu();
            break;
        }
      }
    }
    private static void MenuGrade()
    {
      Grade grade = new Grade();
      int choice;
      grade.Add();
      while (true)
      {
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("|  Grade MANAGEMENT SYSTEM   |");
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("|1. View list grade          |");
        Console.WriteLine("|2. Update grade             |");
        Console.WriteLine("|3. Search grade             |");
        Console.WriteLine("|4. Delete grade             |");
        Console.WriteLine("|5. Back to Menu Student     |");
        Console.WriteLine("+----------------------------+");
        Console.Write("Your choice: ");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            grade.ViewGrade();
            break;
          case 2:
            grade.UpdateGrade();
            break;
          case 3:
            Console.Write("Input id student to search: ");
            string search = Console.ReadLine();
            string search1 = search.ToUpper();
            grade.SearchGrade(search1);
            break;
          case 4:
            grade.DeleteGrade();
            break;
          case 5:
            MainMenu();
            break;
        }
      }
    }
  }
}