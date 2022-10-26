using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace ManageStudent.Class
{
    public class Student : People
    {
        public static List <Student> listStudents = new List<Student>();
        int id;
        string address;
        string fullName;
        DateTime dateOfBirth;
        string email;
        string idStudent;
        string idClass;
        public Student(int id, string address, string fullName, DateTime dateOfBirth, string email, 
          string idStudent, string idClass)
        {
            this.id = id;
            this.address = address;
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.idStudent = idStudent;
            this.idClass = idClass;
        }
        public void AddStudentList()
        {
            listStudents.Add(new Student(1,"abc address","Vo Nguyen Kim Bao Thanh",DateTime.Parse("04/18/2002"),"thanhdaubuoi@gmail.com","GCD201808","GCD1001"));
            listStudents.Add(new Student(2,"123 address","Phan Minh Tien",DateTime.Parse("01/02/2002"),"tiendaubuoi@gmail.com","GCD201914","GCD1001" ));
            listStudents.Add(new Student(3,"abcxyz address","nguuen tran", DateTime.Parse("01/10/2002"),"nguuentran1148@gmail.com","GCD201888","GCD1102" ));
            listStudents.Add(new Student(4,"abcd address","Vo Nguyen Kim Bao Thanh2",DateTime.Parse("04/18/2002"),"thanhdaubuoi@gmail.com","GCD201809","GCD1001"));

        }
        public Student()
        {
        }

        public string Address { get { return address; } set { address = value; } }
        public DateTime DateOfBirth
        { get { return dateOfBirth; } set { dateOfBirth = value; } }
        public string FullName
        { get { return fullName; } set { fullName = value; } }
        public int ID { get { return id; } set { id = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string IdStudent { get { return idStudent; } set { idStudent = value; } }
        public string IdClass { get { return idClass; } set { idClass = value; } }
        public override void ViewList()
        {
          var table = new Table();

          table.SetHeaders("No", "ID student", "Fullname","Class", "Email", "Birthday", "Address");

          foreach (Student i in listStudents)
          {
            table.AddRow($"{i.ID}", i.IdStudent, i.FullName, i.IdClass,i.Email, i.DateOfBirth.ToString("dd/MM/yyyy")
              , i.Address);
          }

          Console.WriteLine(table.ToString());
        }
        public override void AddNew()
        {
          Student student = new Student();
          //Increament ID
          student.ID = listStudents.Count + 1;
          InputIdStudent:
          //Input Id Student
          Console.Write("Enter Id Student: ");
          string idstudent = Console.ReadLine();
          student.IdStudent = idstudent.ToUpper();
          foreach (Student s in listStudents)
          {
              if (s.IdStudent.Equals(student.IdStudent))
              {
                  Console.WriteLine("This id already exists");
                  goto InputIdStudent;
              }
          }
          //Input Name
          Console.Write("Enter Fullname: ");
          student.FullName = Console.ReadLine();
          //Input Email
          while (true)
          {
            Console.Write("Enter Email: ");
            try
            {
              string emailvaild = Console.ReadLine();
              var email = new MailAddress(emailvaild); //VALID EMAIL
              student.Email = Convert.ToString(email);
              break;
            }
            catch (Exception ex)
            {
              Console.WriteLine("The email is not in the correct format!");
              Console.WriteLine("Should be abc123@abc.abc");
            }
          }
          //Input class
          Console.Write("Enter Class Id: ");
          string idclass= Console.ReadLine();
          student.IdClass = idclass.ToUpper();
          //Input date
          while (true)
          {
            Console.Write("Enter Date of Birth: ");
            try
            {
              student.DateOfBirth = DateTime.Parse(Console.ReadLine());
              break;
            }
            catch (Exception ex)
            {
              Console.WriteLine("The date is not in the correct format!");
              Console.WriteLine("Should be mm/dd/yyyy"); 
            }
          }
          //Input Address
          Console.Write("Enter Address: ");
          student.Address = Console.ReadLine();
          //Add people
          listStudents.Add(student);
          Console.WriteLine("Successfully inserted a student !");
        }
        public override void Search()
        {
          bool found = false;
            Console.Write("Input something to search: ");
            string search = Console.ReadLine();
            string search1=search.ToUpper();
            foreach (Student student in listStudents)
            {
               if (student.IdStudent.Equals(search1))
                  {
                      Console.WriteLine("----------------------------------------");
                      student.Display();
                      found = true;
                  }
            }
            if (!found)
            {
                Console.WriteLine("No students were found!");
            }
        }
        public override void Delete()
        {
            bool found = false;
            Console.Write("Input Id student to search: ");
            string search = Console.ReadLine();
            string search1 = search.ToUpper();
            var studentDB = listStudents.FirstOrDefault(s => s.IdStudent == search1);
            studentDB.Display();
            listStudents.Remove(studentDB);
            Console.WriteLine("Delete successfully!");
            
        }
        public override void Update()
        {
          bool found = false;
          Console.Write("Input Something to search: ");
          String search = Console.ReadLine();
          string search1 = search.ToUpper();
          foreach (Student student in listStudents)
          {
            if (student.IdStudent.Equals(search1))
            {
              Console.WriteLine("----------------------------------------");
              var table = new Table();
              table.SetHeaders("No", "ID student", "Fullname","Class", "Email","Class ID", "Birthday", "Address");
              table.AddRow($"{student.ID}", student.IdStudent, student.FullName,student.IdClass, student.Email,
                student.IdClass, student.DateOfBirth.ToString("dd/MM/yyyy"), student.Address);
              Console.WriteLine(table.ToString());
              found = true;
              //Input Name
              Console.Write("Enter Fullname: ");
              student.FullName = Console.ReadLine();
              //Input Email
              while (true)
              {
                Console.Write("Enter Email: ");
                try
                {
                  string emailvaild = Console.ReadLine();
                  var email = new MailAddress(emailvaild); //VALID EMAIL
                  student.Email = Convert.ToString(email);
                  break;
                }
                catch (Exception ex)
                {
                  Console.WriteLine("The email is not in the correct format!");
                  Console.WriteLine("Should be abc123@abc.abc");
                }
              }
              //Input class
              Console.Write("Enter Class Id: ");
              string idclass = Console.ReadLine();
              student.IdClass = idclass.ToUpper();
              //Input date
              while (true)
              {
                Console.Write("Enter Date of Birth: ");
                try
                {
                  student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                  break;
                }
                catch (Exception ex)
                {
                  Console.WriteLine("The date is not in the correct format!");
                  Console.WriteLine("Should be mm/dd/yyyy"); 
                }
              }
              //Input Address
              Console.Write("Enter Address: ");
              student.Address = Console.ReadLine();
              break;
            }
          }
          if (!found)
          {
            Console.WriteLine("No student were found!");
          }
        }
        public override void Display()
        {
            Console.WriteLine("Id : " + IdStudent);
            Console.WriteLine("Full Name: " + FullName);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Date of Birth: " + DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Class: " + IdClass);
            Console.WriteLine("Address: " + Address);
        }
    }
}