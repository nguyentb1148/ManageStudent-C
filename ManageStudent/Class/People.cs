using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ManageStudent.Class
{
    public abstract class People
    {
        int id;
        string address;
        string fullName;
        DateTime dateOfBirth;
        string email;

        public virtual void Display()
        {
            
        }
        
    }
}

