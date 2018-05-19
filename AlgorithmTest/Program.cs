using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new Sort().TestSort();
        }

        void TestBiTree()
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

    public class Sort
    {
        public void TestSort()
        {
            TestSortInternal(InsertSort);
            TestSortInternal(SelectSort);
            TestSortInternal(MergeSort);
            TestSortInternal(QuickSort);
            TestSortInternal(ShellSort);
        }

        void TestSortInternal(Action<List<int>> p_action)
        {
            List<int> testData = new List<int>();
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                testData.Add(random.Next(0, 100000));
            }
            //Console.WriteLine(testData.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            p_action(testData);

            Console.WriteLine("Sort: " + watch.ElapsedMilliseconds);
            Console.WriteLine("Sorted: " + IsSorted(testData));
            //Console.WriteLine(testData.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
        }

        void ShellSort(List<int> p_data)
        {
            int step = 1;
            while (step * 3 < p_data.Count)
            {
                step = step * 3 + 1;
            }

            while (step >= 1)
            {
                for (int sorted = 0; sorted < p_data.Count - step; sorted++)
                {
                    int unsorted = sorted + step;

                    for (int compared = sorted; compared >= 0; compared -= step, unsorted -= step)
                    {
                        if (p_data[unsorted] < p_data[compared])
                        {
                            Exch(p_data, compared, unsorted);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                step /= 3;
            }
        }

        void QuickSort(List<int> p_data)
        {
            QuickSort(p_data, 0, p_data.Count - 1);
        }

        void QuickSort(List<int> p_data, int p_start, int p_end)
        {
            if (p_start >= p_end)
            {
                return;
            }

            int mid = Partition(p_data, p_start, p_end);
            QuickSort(p_data, p_start, mid - 1);
            QuickSort(p_data, mid + 1, p_end);
        }

        int Partition(List<int> p_data, int p_start, int p_end)
        {
            int key = p_data[p_start];

            int low = p_start + 1;
            int high = p_end;

            while (true)
            {
                while (p_data[low] <= key && low < high)
                {
                    low++;
                }

                while (p_data[high] >= key && low < high)
                {
                    high--;
                }

                if (low >= high)
                {
                    break;
                }
                else
                {
                    Exch(p_data, low, high);
                }
            }

            if (p_data[low] > key)
            {
                low--;
            }
            Exch(p_data, p_start, low);

            return low;
        }

        void MergeSort(List<int> p_data)
        {
            List<int> copiedData = new List<int>();
            for (int i = 0; i < p_data.Count; i++)
            {
                copiedData.Add(p_data[i]);
            }

            MergeSort(p_data, copiedData, 0, p_data.Count - 1);
        }

        void MergeSort(List<int> p_data, List<int> p_copiedData, int p_start, int p_end)
        {
            if (p_end >= p_start)
            {
                return;
            }

            MergeSort(p_data, p_copiedData, p_start, (p_start + p_end) / 2);
            MergeSort(p_data, p_copiedData, (p_start + p_end) / 2 + 1, p_end);
            Merge(p_data, p_copiedData, p_start, (p_start + p_end) / 2, p_end);
        }

        void Merge(List<int> p_data, List<int> p_copiedData, int p_start, int p_mid, int p_end)
        {
            int lowFirst = p_start;
            int highFirst = p_mid + 1;
            for (int sorted = p_start - 1; sorted < p_end - 1; sorted++)
            {
                int unsorted = sorted + 1;
                if (highFirst <= p_end && (lowFirst > p_mid || p_copiedData[highFirst] <= p_copiedData[lowFirst]))
                {
                    p_data[unsorted] = p_copiedData[highFirst];
                    highFirst++;
                }
                else if (lowFirst <= p_mid && (highFirst > p_end || p_copiedData[lowFirst] <= p_copiedData[highFirst]))
                {
                    p_data[unsorted] = p_copiedData[lowFirst];
                    lowFirst++;
                }
                else
                {
                    Console.WriteLine("Error when merge sort.");
                }
            }
        }

        void InsertSort(List<int> p_data)
        {
            for (int sorted = 0; sorted < p_data.Count - 1; sorted++)
            {
                int unsorted = sorted + 1;

                for (int compared = sorted; compared >= 0; compared--, unsorted--)
                {
                    if (p_data[compared] > p_data[unsorted])
                    {
                        Exch(p_data, compared, unsorted);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        void SelectSort(List<int> p_data)
        {
            for (int sorted = -1; sorted < p_data.Count - 1; sorted++)
            {
                int unsorted = sorted + 1;
                int minIndex = unsorted;

                for (int compare = unsorted + 1; compare < p_data.Count; compare++)
                {
                    if (p_data[minIndex] > p_data[compare])
                    {
                        minIndex = compare;
                    }
                }

                Exch(p_data, unsorted, minIndex);
            }
        }

        void TryExch(List<int> p_data, int p_first, int p_second)
        {
            if (p_data[p_first] > p_data[p_second])
            {
                int temp;
                temp = p_data[p_first];
                p_data[p_first] = p_data[p_second];
                p_data[p_second] = temp;
            }
        }

        void Exch(List<int> p_data, int p_first, int p_second)
        {
            int temp;
            temp = p_data[p_first];
            p_data[p_first] = p_data[p_second];
            p_data[p_second] = temp;
        }

        bool IsSorted(List<int> p_data)
        {
            int checkIndex = 0;
            while (checkIndex < p_data.Count - 1)
            {
                if (p_data[checkIndex] > p_data[checkIndex + 1])
                {
                    return false;
                }

                checkIndex++;
            }

            return true;
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
