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
            TestBSTree();
            TestRBBSTree();
        }

        static void TestBSTree()
        {
            BSTNode tree = new BSTNode(50);
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = new BSTNode(random.Next(0, 100));
            tree = BSTNode.Add(tree, find);
            for (int i = 0; i < 10000; i++)
            {
                tree = BSTNode.Add(tree, new BSTNode(random.Next(0, 100000)));
            }

            Console.WriteLine("BST: " + watch.ElapsedMilliseconds);

            //for (int i = 0; i < 10; i++)
            //{
            //    tree = tree.Delete(new BSTNode(random.Next(0, 100)));
            //}

            //tree.MidOrderIterate();

            watch.Restart();

            Console.WriteLine("Find: " + find.Key + " in BST");
            var result = tree.Get(find);
            Console.WriteLine("Find: " + result.Key + " in: " + watch.ElapsedTicks);
        }

        static void TestRBBSTree()
        {
            RBBSTNode tree = new RBBSTNode(50);
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = new RBBSTNode(random.Next(0, 100));
            tree = RBBSTNode.Add(tree, find);
            for (int i = 0; i < 10000; i++)
            {
                tree = RBBSTNode.Add(tree, new RBBSTNode(random.Next(0, 100000)));
            }

            Console.WriteLine("RBBST: " + watch.ElapsedMilliseconds);

            //for (int i = 0; i < 10; i++)
            //{
            //    tree = tree.Delete(new RBBSTNode(random.Next(0, 100)));
            //}

            //tree.MidOrderIterate();

            watch.Restart();

            Console.WriteLine("Find: " + find.Key + " in RBBST");
            var result = tree.Get(find);
            Console.WriteLine("Find: " + result.Key + " in: " + watch.ElapsedTicks);
        }
    }

    public class RBBSTNode : BSTNode
    {
        public bool IsRed;
        public RBBSTNode Left { get { return (RBBSTNode)base.Left; } set { base.Left = value; } }
        public RBBSTNode Right { get { return (RBBSTNode)base.Right; } set { base.Right = value; } }

        public static bool GetIsRed(RBBSTNode p_node)
        {
            return p_node != null && p_node.IsRed;
        }

        public RBBSTNode(int p_key) : base(p_key)
        {
            IsRed = true;
        }

        public RBBSTNode Get(RBBSTNode p_node)
        {
            return (RBBSTNode)base.Get(p_node);
        }

        public static RBBSTNode LeftRotate(RBBSTNode source)
        {
            var other = source.Right;
            source.Right = other.Left;
            other.Left = source;

            other.IsRed = source.IsRed;
            source.IsRed = true;

            other.Size = source.Size;
            source.Size = 1 + SizeOf(source.Left) + SizeOf(source.Right);

            return other;
        }

        public static RBBSTNode RightRotate(RBBSTNode source)
        {
            var other = source.Left;
            source.Left = other.Right;
            other.Right = source;

            other.IsRed = source.IsRed;
            source.IsRed = true;

            other.Size = source.Size;
            source.Size = 1 + SizeOf(source.Left) + SizeOf(source.Right);

            return other;
        }

        public static void FlipColor(RBBSTNode source)
        {
            source.Left.IsRed = false;
            source.Right.IsRed = false;
            source.IsRed = true;
        }

        public static RBBSTNode Add(RBBSTNode source, RBBSTNode add)
        {
            if (source == null)
            {
                source = add;
                return source;
            }

            if (add > source)
            {
                source.Right = Add(source.Right, add);
            }
            else if (add < source)
            {
                source.Left = Add(source.Left, add);
            }
            else
            {
                //to implement change contents.
            }

            if (GetIsRed(source.Right) && !GetIsRed(source.Left))
            {
                source = LeftRotate(source);
            }

            if (GetIsRed(source.Left) && GetIsRed(source.Left.Left))
            {
                source = RightRotate(source);
            }

            if (GetIsRed(source.Left) && GetIsRed(source.Right))
            {
                FlipColor(source);
            }

            source.Size = 1 + SizeOf(source.Left) + SizeOf(source.Right);

            return source;
        }

        public RBBSTNode Delete(RBBSTNode p_node)
        {
            return (RBBSTNode)base.Delete(p_node);
        }
    }

    public class BSTNode : IComparable<BSTNode>
    {
        public int Key;
        public virtual BSTNode Left { get; set; }
        public virtual BSTNode Right { get; set; }
        public int Size;

        public static int SizeOf(BSTNode p_node)
        {
            return p_node == null ? 0 : p_node.Size;
        }

        public BSTNode(int p_key)
        {
            Key = p_key;
            Left = null;
            Right = null;
            Size = 1;
        }

        public static void MidOrderIterate(BSTNode source)
        {
            if (source != null)
            {
                source.MidOrderIterate();
            }
        }

        public void MidOrderIterate()
        {
            MidOrderIterate(Left);
            Console.Write(Key + " ");
            MidOrderIterate(Right);
        }

        public static BSTNode Get(BSTNode source, BSTNode find)
        {
            return source == null ? null : source.Get(find);
        }

        public BSTNode Get(BSTNode p_node)
        {
            if (p_node > this)
            {
                return Get(Right, p_node);
            }
            else if (p_node < this)
            {
                return Get(Left, p_node);
            }
            else
            {
                return this;
            }
        }

        public static BSTNode Add(BSTNode source, BSTNode add)
        {
            if (source == null)
            {
                source = add;
                return source;
            }
            else
            {
                return source.Add(add);
            }
        }

        private BSTNode Add(BSTNode p_node)
        {
            if (p_node > this)
            {
                if (Right == null)
                {
                    Right = p_node;
                }
                else
                {
                    Right = Right.Add(p_node);
                }

                Size = 1 + SizeOf(Left) + SizeOf(Right);
            }
            else if (p_node < this)
            {
                if (Left == null)
                {
                    Left = p_node;
                }
                else
                {
                    Left = Left.Add(p_node);
                }

                Size = 1 + SizeOf(Left) + SizeOf(Right);
            }
            else
            {
                //to implement change contents.
            }

            return this;
        }

        public static BSTNode Delete(BSTNode source, BSTNode del)
        {
            return source == null ? null : source.Delete(del);
        }

        public BSTNode Delete(BSTNode p_node)
        {
            if (p_node > this)
            {
                Right = Delete(Right, p_node);
                return this;
            }
            else if (p_node < this)
            {
                Left = Delete(Left, p_node);
                return this;
            }
            else
            {
                if (Left == null)
                {
                    return Right;
                }
                else if (Right == null)
                {
                    return Left;
                }
                else
                {
                    var min = Right.Min();
                    Right = Right.Delete(min);

                    min.Left = Left;
                    min.Right = Right;

                    return min;
                }
            }
        }

        public BSTNode Min()
        {
            return Left != null ? Left.Min() : this;
        }

        public BSTNode Max()
        {
            return Right != null ? Right.Max() : this;
        }

        public static BSTNode Floor(BSTNode source, BSTNode find)
        {
            return source == null ? null : source.Floor(find);
        }

        public BSTNode Floor(BSTNode p_node)
        {
            if (p_node.Equals(this))
            {
                return this;
            }

            if (p_node < this)
            {
                return Floor(Left, p_node);
            }
            else
            {
                if (Right == null)
                {
                    return this;
                }
                else
                {
                    var floor = Right.Floor(p_node);
                    if (floor == null)
                    {
                        return this;
                    }
                    else
                    {
                        return floor;
                    }
                }
            }
        }

        public static BSTNode Ceiling(BSTNode source, BSTNode find)
        {
            return source == null ? null : source.Ceiling(find);
        }

        public BSTNode Ceiling(BSTNode p_node)
        {
            if (p_node.Equals(this))
            {
                return this;
            }

            if (p_node > this)
            {
                return Ceiling(Right, p_node);
            }
            else
            {
                if (Left == null)
                {
                    return this;
                }
                else
                {
                    var ceiling = Left.Ceiling(p_node);
                    if (ceiling == null)
                    {
                        return this;
                    }
                    else
                    {
                        return ceiling;
                    }
                }
            }
        }

        public static bool operator >(BSTNode first, BSTNode second)
        {
            return first.CompareTo(second) > 0;
        }

        public static bool operator <(BSTNode first, BSTNode second)
        {
            return first.CompareTo(second) < 0;
        }

        public bool Equals(BSTNode other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(BSTNode other)
        {
            return Key.CompareTo(other.Key);
        }
    }

    //public class BST
    //{
    //    private BTNode root;

    //    public int Size
    //    {
    //        get
    //        {
    //            if (root == null)
    //            {
    //                return 0;
    //            }
    //            else
    //            {
    //                return root.Size;
    //            }
    //        }
    //    }

    //    public BTNode Get(BTNode p_node)
    //    {
    //        if (root == null)
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            return root.Get(p_node);
    //        }
    //    }

    //    public void Add(BTNode p_node)
    //    {
    //        if (root == null)
    //        {
    //            root = p_node;
    //        }
    //        else
    //        {
    //            root.Add(p_node);
    //        }
    //    }
    //}

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
}
