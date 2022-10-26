using System.Linq;

namespace ManageStudent.Class
{
    public class Login: School
    {
        public bool LoginUser(string username, int password)
        {
            int pass = 1212;
            foreach (Student student in listStudents)
            {
                if (username.Equals(student.IdStudent))
                {
                    return true;
                }
            }
            return false;
        }
        public bool LoginUser(string username, string password)
        {
            string lecture = "lecture";
            string pass = "1212";
            if (username==lecture&& password==pass)
            {
                return true;
            }
            return false;
        }
        
    }
}