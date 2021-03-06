using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// DONT FORGET TO COMMENT
    /// </summary>
    public class MemberCollection : iMemberCollection
    {
        private MemberNode root;
        private Member[] memberArray = new Member[0];
        private int number;
        private int oldCheck = 0;
        private int newCheck = 1;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public MemberCollection()
        {
            root = null;
            Number = 0;
        }


        public void add(Member aMember)
        {
            if (search(aMember) == false)
            {
                if (root == null)
                {
                    root = new MemberNode(aMember); 
                }
                else
                {
                    addNew(aMember, root);
                }
                Number++;
                newCheck++;
            }
        }

        public void delete(Member aMember)
        {
            // search for item and its parent
            MemberNode currentNode = root; // search reference
            MemberNode parent = null; // parent of currentNode
            while ((currentNode != null) && (aMember.CompareTo(currentNode.Member) != 0))
            {
                parent = currentNode;
                if (aMember.CompareTo(currentNode.Member) < 0) // move to the left child of currentNode
                    currentNode = currentNode.Lchild;
                else
                    currentNode = currentNode.Rchild;
            }

            if (currentNode != null) // if the search was successful
            {
                // case 3: item has two children
                if ((currentNode.Lchild != null) && (currentNode.Rchild != null))
                {
                    // find the right-most node in left subtree of currentNode
                    if (currentNode.Lchild.Rchild == null) // a special case: the right subtree of currentNode.Lchild is empty
                    {
                        currentNode.Member = currentNode.Lchild.Member;
                        currentNode.Lchild = currentNode.Lchild.Lchild;
                    }
                    else
                    {
                        MemberNode p = currentNode.Lchild;
                        MemberNode pp = currentNode; // parent of p
                        while (p.Rchild != null)
                        {
                            pp = p;
                            p = p.Rchild;
                        }
                        // copy the item at p to currentNode
                        currentNode.Member = p.Member;
                        pp.Rchild = p.Lchild;
                    }
                    Number--;
                    newCheck++;
                }
                else // cases 1 & 2: item has no or only one child
                {
                    MemberNode c;
                    if (currentNode.Lchild != null)
                        c = currentNode.Lchild;
                    else
                        c = currentNode.Rchild;

                    // remove node currentNode
                    if (currentNode == root) //need to change root
                        root = c;
                    else
                    {
                        if (currentNode == parent.Lchild)
                            parent.Lchild = c;
                        else
                            parent.Rchild = c;
                    }
                    Number--;
                    newCheck++;
                }  
            }
        }

        public bool search(Member aMember)
        {
            return searchTree(aMember, root);
        }

        /// <summary>
        /// Doesnt do the calculation uselss it has too
        /// </summary>
        /// <returns></returns>
        public Member[] toArray()
        {
            if(oldCheck != newCheck)
            {
                int i = 0;
                Member[] newmemberArray = new Member[Number];
                InOrderTraverse(root, ref newmemberArray, ref i);
                memberArray = newmemberArray;
                oldCheck = newCheck;
            }
            return memberArray;
        }
        private void InOrderTraverse(MemberNode root, ref Member[] memberArray, ref int i)
        {
            //pointer for the memberArray
            if (root != null)
            {
                InOrderTraverse(root.Lchild, ref memberArray, ref i);
                memberArray[i] = root.Member;
                i++;
                InOrderTraverse(root.Rchild, ref memberArray, ref i);
            }
        }

        private void addNew(Member aMember, MemberNode parentNode)
        {
            if (aMember.CompareTo(parentNode.Member) < 0)
            {
                if (parentNode.Lchild == null)
                    parentNode.Lchild = new MemberNode(aMember);
                else
                    addNew(aMember, parentNode.Lchild);
            }
            else
            {
                if (parentNode.Rchild == null)
                    parentNode.Rchild = new MemberNode(aMember);
                else
                    addNew(aMember, parentNode.Rchild);
            }

        }
        private bool searchTree(Member aMember, MemberNode node)
        {
            //could change this to the member class Icomparable
            if (node != null)
            {
                if (aMember.CompareTo(node.Member) == 0)
                {
                    return true;
                }
                else if (aMember.CompareTo(node.Member) < 0)
                {

                    return searchTree(aMember, node.Lchild);
                }
                else
                {
                    return searchTree(aMember, node.Rchild);
                }
            }
            else
            {
                return false;
            }
        }
        private class MemberNode
        {
            private Member member;
            private MemberNode lchild;

            private MemberNode rchild;

            public MemberNode(Member member)
            {
                this.member = member;
                lchild = null;
                rchild = null;
            }
            public Member Member
            {
                get { return member; }
                set { member = value; }
            }

            public MemberNode Lchild
            {
                get { return lchild; }
                set { lchild = value; }
            }

            public MemberNode Rchild
            {
                get { return rchild; }
                set { rchild = value; }
            }
        }
    }

	


}
