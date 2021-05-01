using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private ToolCollection[] gardeningTools  = new ToolCollection[5];
        private ToolCollection[] flooringTools = new ToolCollection[6];
        private ToolCollection[] fencingTools = new ToolCollection[5];
        private ToolCollection[] measuringTools = new ToolCollection[6];
        private ToolCollection[] cleaningTools = new ToolCollection[6];
        private ToolCollection[] paintingTools = new ToolCollection[6];
        private ToolCollection[] electronicTools = new ToolCollection[5];
        private ToolCollection[] electricityTools = new ToolCollection[5];
        private ToolCollection[] automotiveTools = new ToolCollection[6];



        private MemberCollection membersOfLibrary = new MemberCollection();

        //Constructor
        public ToolLibrarySystem()
        {
            //create all the ToolCollections needed for the Categories
            initialiseToolCollections();

        }

        private void initialiseToolCollections()
        {
            for(int i = 0;i < 5; i++)
            {
                gardeningTools[i] = new ToolCollection();
                flooringTools[i] = new ToolCollection();
                fencingTools[i] = new ToolCollection();
                measuringTools[i] = new ToolCollection();
                cleaningTools[i] = new ToolCollection();
                paintingTools[i] = new ToolCollection();
                electronicTools[i] = new ToolCollection();
                electricityTools[i] = new ToolCollection();
                automotiveTools[i] = new ToolCollection();
            }
            flooringTools[5] = new ToolCollection();
            measuringTools[5] = new ToolCollection();
            cleaningTools[5] = new ToolCollection();
            paintingTools[5] = new ToolCollection();
            automotiveTools[5] = new ToolCollection();
        }

        public void add(Tool aTool)
        {
            throw new NotImplementedException();
        } 

        public void add(Tool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void add(Member aMember)
        {
            if (membersOfLibrary.search(aMember) != true)
            {
                membersOfLibrary.add(aMember);
            }
            else
            {
                Console.WriteLine("This memeber is already added");
            }
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                theMemeber.addTool(aTool);
                //add the memeber to tool borrow list (need to find the tool first, different from the above aTool)
            }
        }

        private Member selectMemeber(Member aMember)
        {
            Member[] arrayOfMember = membersOfLibrary.toArray();
            for (int i = 0; i < arrayOfMember.Length; i++)
            {
                if(arrayOfMember[i].CompareTo(aMember) == 0)
                {
                    return arrayOfMember[i];
                }
            }
            return null;
        }

        public void delete(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public void delete(Tool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        public void delete(Member aMember)
        {
            if(membersOfLibrary.search(aMember) == true)
            {
                membersOfLibrary.delete(aMember);
            }
            else
            {
                Console.WriteLine("Memeber does not exist");
            }
        }

        public void displayBorrowingTools(Member aMember)
        {
            aMember = selectMemeber(aMember);
            string[] borrowedTools = aMember.Tools;
            foreach(string element in borrowedTools)
            {
                if (!string.IsNullOrEmpty(element))
                {
                    Console.WriteLine(element);
                }
            }
        }

        public void displayTools(string aToolType)
        {
            throw new NotImplementedException();
        }

        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(Member aMember)
        {

            throw new NotImplementedException();
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            if (membersOfLibrary.search(aMember))
            {
                Member theMemeber = selectMemeber(aMember);
                theMemeber.deleteTool(aTool);
                //delete the memeber from tool borrowlist (need to find the tool first, different from the above aTool)
            }
        }
    }
    /*
    public void delete(Tool aTool)
    {
        for (int i = 0; i < toolArray.Length; i++)
        {
            if (toolArray[i] != null)
            {
                if (toolArray[i].Name.Equals(aTool.Name))
                {
                    if (toolArray[i].AvailableQuantity >= aTool.Quantity)
                    {
                        toolArray[i].Quantity -= aTool.Quantity;
                        toolArray[i].AvailableQuantity -= aTool.Quantity;
                    }
                    else
                    {
                        //this will be ToolCollectionName.delete(tool)
                        toolArray[i] = null;
                    }
                }
            }
        }
    }

    public void add(Tool aTool)
    {
        if (search(aTool) == true)
        {
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] != null)
                {
                    if (toolArray[i].Name.Equals(aTool.Name))
                    {
                        toolArray[i].Quantity += aTool.Quantity;
                        toolArray[i].AvailableQuantity += aTool.Quantity;
                    }
                }
            }
        }
        else
        {
            if (Number >= toolArray.Length)
            {
                dynamicArray();
            }
            for (int i = 0; i < toolArray.Length; i++)
            {
                if (toolArray[i] == null)
                {
                    //this will be ToolCollectionName.add(tool)
                    toolArray[i] = aTool;
                }
            }
            Number++;
        }
    }
    */
}
