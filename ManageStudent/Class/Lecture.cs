using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
namespace ManageStudent.Class
{
    public class Lecture : People
    {
        static List< Lecture> listLectures = new List<Lecture>();
        int id;
        string address;
        string fullName;
        DateTime dateOfBirth;
        string email;
        string idLecture;
        string _certificate;

        public Lecture(int id, string address, string fullName, DateTime dateOfBirth, string email, string idLecture,
          string certificate)
        {
            this.id = id;
            this.address = address;
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.idLecture = idLecture;
            this._certificate = certificate;
        }

        public void AddLectureList()
        {
          listLectures.Add(new Lecture(1,"abc123 address","a b c",DateTime.Parse("07/12/1994"),"abc@gmail.com","LEC123456","Professor" ));
          listLectures.Add(new Lecture(2,"abcxyz123 address","c b a",DateTime.Parse("02/12/1991"), "abc123@gmail.com","LEC123000","Professor"));
          listLectures.Add(new Lecture(3,"abcxyz456 address","a b c d",DateTime.Parse("12/10/1989"), "abc123456@gmail.com","LEC123001","Doctor"));

        }
        public Lecture()
        {
            
        }
         public string Address { get { return address; } set { address = value; } } 
         public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }
        public string FullName { get { return fullName; } set { fullName = value; } }
        public int ID { get { return id; } set { id = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string IdLecture { get { return idLecture; } set { idLecture = value; } }
        public string Certificate { get { return _certificate; } set { _certificate = value; } }
        public override void ViewList()
        {
            var table = new Table();

            table.SetHeaders("No", "ID lecture", "Fullname","Certificate", "Email", "Birthday", "Address");

            foreach (Lecture i in listLectures)
            {
                table.AddRow($"{i.ID}", i.IdLecture, i.FullName, i.Certificate,i.Email, 
                  i.DateOfBirth.ToString("dd/MM/yyyy"), i.Address);
            }
            Console.WriteLine(table.ToString());
        }
        public override void AddNew()
          {
            Lecture lecture = new Lecture();
            //Increament ID
            lecture.ID = listLectures.Count + 1;
            InputId:
            //Input Id 
            Console.Write("Enter Id Lecture: ");
            string idLecture = Console.ReadLine();
            lecture.IdLecture = idLecture.ToUpper();
            foreach (Lecture l in listLectures)
            {
              if (l.IdLecture.Equals(lecture.IdLecture))
              {
                Console.WriteLine("This id already exists");
                goto InputId;
              }
            }
            //Input Name
            Console.Write("Enter Fullname: ");
            lecture.FullName = Console.ReadLine();
            //Input Email
            while (true)
            {
              Console.Write("Enter Email: ");
              try
              {
                string emailvaild = Console.ReadLine();
                var email = new MailAddress(emailvaild); //VALID EMAIL
                lecture.Email = Convert.ToString(email);
                break;
              }
              catch (Exception ex)
              {
                Console.WriteLine("The email is not in the correct format!");
                Console.WriteLine("Should be abc123@abc.abc");
              }
            }
            //Input date
            while (true)
            {
              Console.Write("Enter Date of Birth: ");
              try
              {
                lecture.DateOfBirth = DateTime.Parse(Console.ReadLine());
                break;
              }
              catch (Exception ex)
              {
                Console.WriteLine("The date is not in the correct format!");
                Console.WriteLine("Should be mm/dd/yyyy");
                // Console.WriteLine(ex.Message);
              }
            }
            //Input Department
            Console.Write("Enter Depart: ");
            lecture.Certificate = Console.ReadLine();
            //Input Address
            Console.Write("Enter Address: ");
            lecture.Address = Console.ReadLine();
            //Add people
            listLectures.Add(lecture);
            Console.WriteLine("Successfully inserted new lecture!");
          }
        public override void Search()
        {
          bool found = false;
          Console.Write("Input something to search: ");
          string search = Console.ReadLine();
          string search1 = search.ToUpper();
          foreach (Lecture l in listLectures)
          {
            if (l.IdLecture.Equals(search1))
            {
              Console.WriteLine("----------------------------------------");
              l.Display();
              found = true;
            }
          }
          if (!found)
          {
            Console.WriteLine("No Lecture were found!");
          }
        }
        public override void Delete()
          {
            bool found = false;
            Console.Write("Input Id Lecture to search: ");
            string search = Console.ReadLine();
            string search1 = search.ToUpper();
            var lectureDB = listLectures.FirstOrDefault((l => l.IdLecture == search1));
            lectureDB.Display();
            listLectures.Remove(lectureDB);
            Console.WriteLine("Delete successfully!");
          }
         public override void Update()
        {
          bool found = false;
          Console.Write("Input Something to search: ");
          String search = Console.ReadLine();
          string search1 = search.ToUpper();
          foreach (Lecture lecture in listLectures)
          {
            if (lecture.IdLecture.Equals(search1))
            {
              Console.WriteLine("----------------------------------------");
              var table = new Table();
              table.SetHeaders("No", "ID Lecture", "Fullname","Certificate", "Email", "Birthday", "Address");
              table.AddRow($"{lecture.ID}", lecture.IdLecture, lecture.FullName,lecture.Certificate, lecture.Email, 
                lecture.DateOfBirth.ToString("dd/MM/yyyy"), lecture.Address);
              Console.WriteLine(table.ToString());
              found = true;
              //Input Name
              Console.Write("Enter Fullname: ");
              lecture.FullName = Console.ReadLine();
              //Input Email
              while (true)
              {
                Console.Write("Enter Email: ");
                try
                {
                  string emailvaild = Console.ReadLine();
                  var email = new MailAddress(emailvaild); //VALID EMAIL
                  lecture.Email = Convert.ToString(email);
                  break;
                }
                catch (Exception ex)
                {
                  Console.WriteLine("The email is not in the correct format!");
                  Console.WriteLine("Should be abc123@abc.abc");
                }
              }
              Console.Write("Enter Depart: ");
              lecture.Certificate = Console.ReadLine();
              //Input date
              while (true)
              {
                Console.Write("Enter Date of Birth: ");
                try
                {
                  lecture.DateOfBirth = DateTime.Parse(Console.ReadLine());
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
              lecture.Address = Console.ReadLine();
              break;
            }
          }
          if (!found)
          {
            Console.WriteLine("No lecture were found!");
          }
        }
        public override void Display()
        {
            Console.WriteLine("Id : " + IdLecture);
            Console.WriteLine("Full Name: " + FullName);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Certificate: " + Certificate);
            Console.WriteLine("Date of Birth: " + DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Address: " + Address);
          
        }
    }
}