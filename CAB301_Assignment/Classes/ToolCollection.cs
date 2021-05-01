using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolCollection : iToolCollection
    {

        //private string toolTypesArray;
        //could use with constructor to define teh tool types of a catergory?


        private Tool[] toolArray;
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public ToolCollection()
        {
            Number = 0;
            toolArray = new Tool[1];
        }

        public void add(Tool aTool)
        {
            if (Number >= toolArray.Length)
            {
                dynamicArray();
            }
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] == null)
                {
                    toolArray[i] = aTool;
                }
            }
            Number++;
        }

        public void delete(Tool aTool)
        {
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null)
                {
                    if (toolArray[i].Name.Equals(aTool.Name))
                    {
                        toolArray[i] = null;
                    }
                }
            }
        }
        


        public bool search(Tool aTool)
        {
            for(int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null)
                {
                    if (toolArray[i].Name.Equals(aTool.Name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// create this!!!!
        /// </summary>
        /// <returns></returns>
        public Tool[] toArray()
        {
            throw new NotImplementedException();
        }
        private void dynamicArray()
        {
            int tempLength = (toolArray.Length * 2);
            Tool[] tempArray = new Tool[tempLength];
            for(int i = 0; i < toolArray.Length; i++)
            {
                tempArray[i] = toolArray[i];
            }
            toolArray = tempArray;

        }
    }
}
