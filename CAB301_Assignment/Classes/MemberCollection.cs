﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class MemberCollection : iMemberCollection
    {

        /// <summary>
        /// REMEMBER TO ADD THE CONDITIONS OF ADD DELETE SO ON!!!!!!!!!!!!!!!!!!
        /// </summary>
        private MemberNode root;
        public int Number { get; } = 0;
        public MemberCollection()
        {
            root = null;
        }

        public void add(Member aMember)
        {
            if (root == null)
            {
                root = new MemberNode(aMember);
            }
            else
            {
                addNew(aMember, root);
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
                }

            }
        }

        public bool search(Member aMember)
        {
            return searchTree(aMember, root);
        }

        public Member[] toArray()
        {
            Member[] memberArray = new Member[Number];
            return memberArray;
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
        private bool searchTree(Member aMember, MemberNode root)
        {
            if (root != null)
            {
                if (aMember.CompareTo(root.Member) == 0)
                    return true;
                else
                    if (aMember.CompareTo(root.Member) < 0)
                    return searchTree(aMember, root.Lchild);
                else
                    return searchTree(aMember, root.Rchild);
            }
            else
            {
                return false;
            }
        }
    }

	public class MemberNode
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
