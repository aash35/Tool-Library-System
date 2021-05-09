using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Member : iMember, IComparable<Member>
    {
        private string firstname;
        private string lastname;
        private string contactnumber;
        private string pin;
        private string[] tools = new string[3];

        public string FirstName {
            get { return firstname; }
            set { firstname = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string ContactNumber
        {
            get { return contactnumber; }
            set { contactnumber = value; }
        }
        public string PIN
        {
            get { return pin; }
            set { pin = value; }
        }

        public string[] Tools {
            get { return tools; }
        }

        public Member(string firstName, string lastName, string number, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = number;
            PIN = password;
        }

        public void addTool(Tool aTool)
        {
            for(int i = 0; i < Tools.Length; i++)
            {
                if (Tools[i] == null)
                {
                    Tools[i] = aTool.Name;
                    i = Tools.Length;
                }
            }
        }

        public void deleteTool(Tool aTool)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                if(Tools[i] != null)
                {
                    if (Tools[i].Equals(aTool.Name))
                    {
                        Tools[i] = null;
                        i = Tools.Length;
                    }
                }
            }
        }

        public override string ToString()
        {
            string returnStatement = String.Format("Name: {0} {1}\nPhone Number: {2}", FirstName,LastName, ContactNumber);
            return returnStatement;
        }

        public int CompareTo(Member other)
        {
            if (this.LastName.CompareTo(other.LastName) < 0)
            {
                return -1;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 && (this.FirstName.CompareTo(other.FirstName) == 0))
            {
                return 0;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 && (this.FirstName.CompareTo(other.FirstName) < 0))
            {
                return -1;
            }
            return 1;

        }
    }
}
