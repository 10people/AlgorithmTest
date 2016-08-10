using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> TreeDatas = new List<int>() { 553, 663, 221, 243, 452, 334, 245, 975, 572, 558 };

            BiTree temp = new BiTree(TreeDatas[0]);

            for (int i = 1; i < TreeDatas.Count; i++)
            {
                temp.InsertNodeAsSorted(TreeDatas[i]);
            }

            temp.PreOrderTraverse();
        }
    }

    public class BiTree
    {
        public BiTreeNode RootNode;

        public int Depth { get; private set; }

        public BiTree(int p_data)
        {
            RootNode = new BiTreeNode(p_data, 1);

            Depth = 1;
        }

        public void PreOrderTraverse()
        {
            PreOrderTraverse(RootNode);
        }

        private void PreOrderTraverse(BiTreeNode p_parentNode)
        {
            if (p_parentNode == null)
            {
                return;
            }

            Console.Write(p_parentNode.Data + "," + p_parentNode.Level + "    ");

            PreOrderTraverse(p_parentNode.LeftChild);
            PreOrderTraverse(p_parentNode.RightChild);
        }

        public void InsertNodeAsSorted(int p_data)
        {
            BiTreeNode InsertParentNode = RootNode;

            while (true)
            {
                while (p_data <= InsertParentNode.Data && InsertParentNode.LeftChild != null)
                {
                    InsertParentNode = InsertParentNode.LeftChild;
                }

                if (p_data <= InsertParentNode.Data && InsertParentNode.LeftChild == null)
                {
                    InsertParentNode.LeftChild = new BiTreeNode(p_data, InsertParentNode.Level + 1);
                    UpdateDepthWithNewNode(InsertParentNode.LeftChild);
                    break;
                }

                while (p_data > InsertParentNode.Data && InsertParentNode.RightChild != null)
                {
                    InsertParentNode = InsertParentNode.RightChild;
                }

                if (p_data > InsertParentNode.Data && InsertParentNode.RightChild == null)
                {
                    InsertParentNode.RightChild = new BiTreeNode(p_data, InsertParentNode.Level + 1);
                    UpdateDepthWithNewNode(InsertParentNode.RightChild);
                    break;
                }
            }
        }

        private void UpdateDepthWithNewNode(BiTreeNode p_newOne)
        {
            if (p_newOne.Level > Depth)
            {
                Depth = p_newOne.Level;
            }
        }
    }

    public class BiTreeNode
    {
        public int Data;
        public int Level;
        public BiTreeNode LeftChild;
        public BiTreeNode RightChild;

        public BiTreeNode(int p_data)
        {
            Data = p_data;
        }

        public BiTreeNode(int p_data, int p_level)
        {
            Data = p_data;
            Level = p_level;
        }

        public BiTreeNode(int p_data, BiTreeNode p_lc, BiTreeNode p_rc)
        {
            Data = p_data;
            LeftChild = p_lc;
            RightChild = p_rc;
        }
    }
}
