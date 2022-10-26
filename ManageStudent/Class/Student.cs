using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace ManageStudent.Class
{
    public class Student : People
    {
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