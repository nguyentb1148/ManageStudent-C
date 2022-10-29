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
   static School school = new School();

    static void Main(string[] args)
    {
      school.AddStudentList();
      Login();
    }

    private  static void Login()
    {
      Login login = new Login();
      int choice;
      while (true)
      {
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("| STUDENTS MANAGEMENT SYSTEM |");
        Console.WriteLine("+----------------------------+");
        Console.WriteLine("|1. Login student            |");
        Console.WriteLine("|2. Login Lecture            |");
        Console.WriteLine("|3. Exit                     |");
        Console.WriteLine("+----------------------------+");
        Console.Write("Your choice: ");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            Console.Write("Input IdStudent: ");
            string input = Console.ReadLine();
            string idStudent = input.ToUpper();
            Console.Write("Input password: ");
            int password = int.Parse(Console.ReadLine());
            if (login.LoginUser(idStudent,password))
            {
              school.Display(idStudent);
            }
            else
            {
              Console.WriteLine("Wrong");
            }
            break;
          case 2:
            Console.Write("Input email: ");
            string user = Console.ReadLine();
            Console.Write("Input password: ");
            string password1 = Console.ReadLine();
            if (login.LoginUser(user,password1))
            {
              Console.WriteLine("Login success.");
              MenuStudent();
            }
            else
            {
              Console.WriteLine("Wrong");

            }
            break;
          case 3: 
            return;
        }
      }
    }
    // private static void MainMenu()
    // {
    //   int choice;
    //   while (true)
    //   {
    //     Console.WriteLine("+----------------------------+");
    //     Console.WriteLine("| STUDENTS MANAGEMENT SYSTEM |");
    //     Console.WriteLine("+----------------------------+");
    //     Console.WriteLine("|1. Manage Students          |");
    //     Console.WriteLine("|2. Manage Grades            |");
    //     Console.WriteLine("|3. Login                     |");
    //     Console.WriteLine("+----------------------------+");
    //     Console.Write("Your choice: ");
    //     choice = int.Parse(Console.ReadLine());
    //     switch (choice)
    //     {
    //       case 1:
    //         MenuStudent();
    //         break;
    //       case 2:
    //         break;
    //       case 3:
    //         Login();
    //         break;
    //     }
    //   }
    //   
    // }
    private static void MenuStudent()
    {
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
        Console.WriteLine("|6. Back to Login            |");
        Console.WriteLine("+----------------------------+");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            school.AddNew();
            break;
          case 2:
            school.ViewList();
            break;
          case 3:
            Console.Write("Input something to search: ");
            string search = Console.ReadLine();
            string search1=search.ToUpper();
            school.Search(search1);
            break;
          case 4:
            school.Delete();
            break;
          case 5 :
            school. Update();
            break;
          case 6:
            Login();
            break;
        }
      }
    }
  }
}