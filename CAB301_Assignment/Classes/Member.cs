using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Member : iMember, IComparable<Member>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }

        public string[] Tools { get; } = new string[3];

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
                }
            }
        }

        public void deleteTool(Tool aTool)
        {
            for (int i = 0; i < Tools.Length; i++)
            {
                if (Tools[i].Contains(aTool.Name))
                {
                    Tools[i] = null;
                    i = Tools.Length;
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
