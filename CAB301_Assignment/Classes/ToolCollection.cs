using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolCollection : iToolCollection
    {

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
                    Number++;
                    i = toolArray.Length;
                }
            }
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
                        toolArraySort();
                        Number--;
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

        public Tool[] toArray()
        {
            return toolArray;
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

        private void toolArraySort()
        {
            int counter = 0;
            for(int i = 0; i < toolArray.Length; i++)
            {
                if(toolArray[i] != null)
                {
                    toolArray[counter] = toolArray[i];
                    counter++;
                }
            }
            for(int i = counter; i < toolArray.Length; i++)
            {
                toolArray[i] = null;
            }
        }
    }
}
