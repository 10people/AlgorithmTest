using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new Sort().TestSort();
            TestBSTree();
            TestRBBSTree();
            TestSCHash();
            TestLPHash();
            TestGraph();
            TestDiGraph();
            TestMST();
        }

        static void TestMST()
        {
            Graph graph = new DiGraph();
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            graph.AddEdge(0, 1);
            int toAdd;
            int from;
            for (int i = 2; i < 10000; i++)
            {
                toAdd = i;
                from = random.Next(0, i);
                graph.AddEdge(from, toAdd, random.Next(1, 4));
            }

            Console.WriteLine("Weight DiGraph: " + watch.ElapsedMilliseconds);

            Console.WriteLine("MST in Weight DiGraph");
            watch.Restart();

            MinimumSpanningTree mst = new MinimumSpanningTree(graph);
            mst.MST(0);
            Console.WriteLine("MST in: " + watch.ElapsedTicks);
            //dfp.OutputOrder();
            mst.OutputOrder();
        }

        static void TestGraph()
        {
            Graph graph = new Graph();
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            graph.AddEdge(0, 1);
            int toAdd;
            int from;
            for (int i = 2; i < 10000; i++)
            {
                toAdd = i;
                from = random.Next(0, i);
                graph.AddEdge(from, toAdd);
            }

            Console.WriteLine("Graph: " + watch.ElapsedMilliseconds);

            Console.WriteLine("DFP in Graph");
            watch.Restart();

            DepthFirstSearch dfp = new DepthFirstSearch(graph);
            dfp.DFS(0);
            Console.WriteLine("DFP in: " + watch.ElapsedTicks);
            //dfp.OutputOrder();
            dfp.OutputPath(5000);

            Console.WriteLine("BFP in Graph");
            watch.Restart();

            BreadthFirstSearch bfp = new BreadthFirstSearch(graph);
            bfp.BFS(0);
            Console.WriteLine("BFP in: " + watch.ElapsedTicks);
            //bfp.OutputOrder();
            bfp.OutputPath(5000);
        }

        static void TestDiGraph()
        {
            Graph graph = new DiGraph();
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            graph.AddEdge(0, 1);
            int toAdd;
            int from;
            for (int i = 2; i < 10000; i++)
            {
                toAdd = i;
                from = random.Next(0, i);
                graph.AddEdge(from, toAdd);
            }

            Console.WriteLine("DiGraph: " + watch.ElapsedMilliseconds);

            Console.WriteLine("DFP in DiGraph");
            watch.Restart();

            DepthFirstSearch dfp = new DepthFirstSearch(graph);
            dfp.DFS(0);
            Console.WriteLine("DFP in: " + watch.ElapsedTicks);
            //dfp.OutputOrder();
            dfp.OutputPath(5000);

            Console.WriteLine("BFP in DiGraph");
            watch.Restart();

            BreadthFirstSearch bfp = new BreadthFirstSearch(graph);
            bfp.BFS(0);
            Console.WriteLine("BFP in: " + watch.ElapsedTicks);
            //bfp.OutputOrder();
            bfp.OutputPath(5000);

            Console.WriteLine("Cycle in DiGraph");
            watch.Restart();

            GraphCycle cycle = new GraphCycle(graph);
            cycle.CS();
            Console.WriteLine("CS in: " + watch.ElapsedTicks);
            cycle.OutputCycle();

            Console.WriteLine("Topo sort in DiGraph");
            watch.Restart();

            DepthFirstOrder order = new DepthFirstOrder(graph);
            order.DFO();
            Console.WriteLine("Topo sort in: " + watch.ElapsedTicks);
            //order.OutputReversePost();
        }

        static void TestLPHash()
        {
            LPHash<int, int> hash = new LPHash<int, int>();
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = random.Next(0, 10000);
            hash.Add(find, find);
            int toAdd;
            for (int i = 0; i < 10000; i++)
            {
                toAdd = random.Next(0, 10000);
                hash.Add(toAdd, toAdd);
            }

            Console.WriteLine("LPHash: " + watch.ElapsedMilliseconds);

            Console.WriteLine("Find: " + 5000 + " in LPHash");
            int result = 0;
            bool success = false;
            watch.Restart();

            success = hash.Get(5000, ref result);
            Console.WriteLine("Find: " + result + " success: " + success + " in: " + watch.ElapsedTicks);
        }

        static void TestSCHash()
        {
            SCHash<int, int> hash = new SCHash<int, int>();
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = random.Next(0, 10000);
            hash.Add(find, find);
            int toAdd;
            for (int i = 0; i < 10000; i++)
            {
                toAdd = random.Next(0, 10000);
                hash.Add(toAdd, toAdd);
            }

            Console.WriteLine("SCHash: " + watch.ElapsedMilliseconds);

            Console.WriteLine("Find: " + 5000 + " in SCHash");
            int result = 0;
            bool success = false;
            watch.Restart();

            success = hash.Get(5000, ref result);
            Console.WriteLine("Find: " + result + " success: " + success + " in: " + watch.ElapsedTicks);
        }

        static void TestBSTree()
        {
            BSTNode tree = new BSTNode(50);
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = new BSTNode(random.Next(0, 10000));
            tree = BSTNode.Add(tree, find);
            for (int i = 0; i < 10000; i++)
            {
                tree = BSTNode.Add(tree, new BSTNode(random.Next(0, 10000)));
            }

            Console.WriteLine("BST: " + watch.ElapsedMilliseconds);

            //for (int i = 0; i < 10; i++)
            //{
            //    tree = tree.Delete(new BSTNode(random.Next(0, 100)));
            //}

            //tree.MidOrderIterate();

            Console.WriteLine("Find: " + find.Key + " in BST");
            watch.Restart();

            var result = tree.Get(find);
            Console.WriteLine("Find: " + result.Key + " in: " + watch.ElapsedTicks);
        }

        static void TestRBBSTree()
        {
            RBBSTNode tree = new RBBSTNode(50);
            var random = new Random();

            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var find = new RBBSTNode(random.Next(0, 10000));
            tree = RBBSTNode.Add(tree, find);
            for (int i = 0; i < 10000; i++)
            {
                tree = RBBSTNode.Add(tree, new RBBSTNode(random.Next(0, 10000)));
            }

            Console.WriteLine("RBBST: " + watch.ElapsedMilliseconds);

            //for (int i = 0; i < 10; i++)
            //{
            //    tree = tree.Delete(new RBBSTNode(random.Next(0, 100)));
            //}

            //tree.MidOrderIterate();

            Console.WriteLine("Find: " + find.Key + " in RBBST");
            watch.Restart();

            var result = tree.Get(find);
            Console.WriteLine("Find: " + result.Key + " in: " + watch.ElapsedTicks);
        }
    }

    public class DiGraph : Graph
    {
        public override void AddEdge(int p_first, int p_second, int p_weight = -1)
        {
            if (p_first == p_second)
            {
                return;
            }

            while (size <= p_first || size <= p_second)
            {
                Resize();
            }

            AddAdj(p_first, p_second, p_weight);
        }

        public void Reverse()
        {
            var reverse = new DiGraph();

            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < AdjArray[i].Count; j++)
                {
                    reverse.AddEdge(i, AdjArray[i][j], WeightArray[i][j]);
                }
            }

            AdjArray = reverse.AdjArray;
            WeightArray = reverse.WeightArray;
        }
    }

    public class MinimumSpanningTree : BreadthFirstSearch
    {
        public MinimumSpanningTree(Graph p_graph) : base(p_graph)
        {

        }

        public void MST(int p_startVertex)
        {
            //assuming graph in connected
            BFS(p_startVertex);
        }

        protected override void bfs(Graph p_graph, int p_startVertex)
        {
            List<int> processList = new List<int>();
            processList.Add(p_startVertex);
            addedToQueue[p_startVertex] = true;

            while (processList.Count > 0)
            {
                var current = processList.First();
                processList.RemoveAt(0);

                connected[current] = true;
                searchOrder.Add(current);

                for (int i = 0; i < p_graph.AdjArray[current].Count; i++)
                {
                    var adj = p_graph.AdjArray[current][i];

                    if (!connected[adj])
                    {
                        //change search from to smaller weight
                        if (graph.GetWeight(SearchFrom[adj], adj) > graph.GetWeight(current, adj))
                        {
                            SearchFrom[adj] = current;
                        }

                        if (!addedToQueue[adj])
                        {
                            addedToQueue[adj] = true;
                            processList.Add(adj);
                            processList = processList.OrderBy(item => graph.GetWeight(SearchFrom[item], item)).ToList();
                        }
                    }
                }
            }
        }
    }

    public class BreadthFirstSearch
    {
        public bool[] connected;
        public bool[] addedToQueue;
        public List<int> searchOrder = new List<int>();
        public Graph graph;

        public int[] SearchFrom;

        public bool IsConnected(int p_targetVertex)
        {
            return p_targetVertex < connected.Length && connected[p_targetVertex];
        }

        public void OutputPath(int p_targetVertex)
        {
            if (IsConnected(p_targetVertex))
            {
                Stack<int> path = new Stack<int>();
                var current = p_targetVertex;

                do
                {
                    path.Push(current);
                    current = SearchFrom[current];
                }
                while (current >= 0);

                Console.WriteLine(path.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
            }
        }

        public BreadthFirstSearch(Graph p_graph)
        {
            connected = new bool[p_graph.VertexCount];
            addedToQueue = new bool[p_graph.VertexCount];
            SearchFrom = new int[p_graph.VertexCount];
            graph = p_graph;
        }

        public void BFS(int p_startVertex)
        {
            SearchFrom[p_startVertex] = -1;
            bfs(graph, p_startVertex);
        }

        protected virtual void bfs(Graph p_graph, int p_startVertex)
        {
            Queue<int> processQueue = new Queue<int>();
            processQueue.Enqueue(p_startVertex);
            addedToQueue[p_startVertex] = true;

            while (processQueue.Count > 0)
            {
                //dequeue the lowest weight (SearchFrom[item]--item) to implement minimum spanning tree
                var dequeue = processQueue.Dequeue();

                connected[dequeue] = true;
                searchOrder.Add(dequeue);

                for (int i = 0; i < p_graph.AdjArray[dequeue].Count; i++)
                {
                    if (!addedToQueue[p_graph.AdjArray[dequeue][i]])
                    {
                        SearchFrom[p_graph.AdjArray[dequeue][i]] = dequeue;
                        addedToQueue[p_graph.AdjArray[dequeue][i]] = true;
                        processQueue.Enqueue(p_graph.AdjArray[dequeue][i]);
                    }
                }
            }
        }

        /// <summary>
        /// May cause serious memory problem if vertex count large.
        /// </summary>
        public void OutputOrder()
        {
            Console.WriteLine(searchOrder.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
        }
    }

    public class GraphCycle : DepthFirstSearch
    {
        public bool[] OnProcess;

        public Stack<int> Cycle = new Stack<int>();

        public GraphCycle(Graph p_graph) : base(p_graph)
        {
            OnProcess = new bool[graph.VertexCount];
        }

        public void CS()
        {
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!connected[i])
                {
                    dfs(graph, i);
                }
            }
        }

        protected override void dfs(Graph p_graph, int p_startVertex)
        {
            connected[p_startVertex] = true;
            searchOrder.Add(p_startVertex);
            OnProcess[p_startVertex] = true;

            for (int i = 0; i < p_graph.AdjArray[p_startVertex].Count; i++)
            {
                if (Cycle.Count > 0)
                {
                    return;
                }

                if (!connected[p_graph.AdjArray[p_startVertex][i]])
                {
                    SearchFrom[p_graph.AdjArray[p_startVertex][i]] = p_startVertex;
                    dfs(p_graph, p_graph.AdjArray[p_startVertex][i]);
                }
                else if (OnProcess[p_graph.AdjArray[p_startVertex][i]])
                {
                    for (int j = p_startVertex; j != p_graph.AdjArray[p_startVertex][i]; j = SearchFrom[j])
                    {
                        Cycle.Push(j);
                    }

                    Cycle.Push(p_graph.AdjArray[p_startVertex][i]);
                    Cycle.Push(p_startVertex);
                }
            }

            OnProcess[p_startVertex] = false;
        }

        public void OutputCycle()
        {
            if (Cycle.Count > 0)
            {
                Console.WriteLine(Cycle.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
            }
        }
    }

    public class DepthFirstOrder : DepthFirstSearch
    {
        public List<int> PreOrder = new List<int>();
        public List<int> PostOrder = new List<int>();
        public Stack<int> ReversePostOrder = new Stack<int>();

        public DepthFirstOrder(Graph p_graph) : base(p_graph)
        {

        }

        public void DFO()
        {
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!connected[i])
                {
                    dfs(graph, i);
                }
            }
        }

        protected override void dfs(Graph p_graph, int p_startVertex)
        {
            connected[p_startVertex] = true;
            PreOrder.Add(p_startVertex);

            for (int i = 0; i < p_graph.AdjArray[p_startVertex].Count; i++)
            {
                if (!connected[p_graph.AdjArray[p_startVertex][i]])
                {
                    SearchFrom[p_graph.AdjArray[p_startVertex][i]] = p_startVertex;
                    dfs(p_graph, p_graph.AdjArray[p_startVertex][i]);
                }
            }

            PostOrder.Add(p_startVertex);
            ReversePostOrder.Push(p_startVertex);
        }

        public void OutputReversePost()
        {
            Console.WriteLine(ReversePostOrder.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
        }
    }

    public class DepthFirstSearch
    {
        public bool[] connected;
        public List<int> searchOrder = new List<int>();
        public Graph graph;

        public int[] SearchFrom;

        public bool IsConnected(int p_targetVertex)
        {
            return p_targetVertex < connected.Length && connected[p_targetVertex];
        }

        public void OutputPath(int p_targetVertex)
        {
            if (IsConnected(p_targetVertex))
            {
                Stack<int> path = new Stack<int>();
                var current = p_targetVertex;

                do
                {
                    path.Push(current);
                    current = SearchFrom[current];
                }
                while (current >= 0);

                Console.WriteLine(path.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
            }
        }

        public DepthFirstSearch(Graph p_graph)
        {
            connected = new bool[p_graph.VertexCount];
            graph = p_graph;
            SearchFrom = new int[p_graph.VertexCount];
        }

        public void DFS(int p_startVertex)
        {
            SearchFrom[p_startVertex] = -1;
            dfs(graph, p_startVertex);
        }

        protected virtual void dfs(Graph p_graph, int p_startVertex)
        {
            connected[p_startVertex] = true;
            searchOrder.Add(p_startVertex);

            for (int i = 0; i < p_graph.AdjArray[p_startVertex].Count; i++)
            {
                if (!connected[p_graph.AdjArray[p_startVertex][i]])
                {
                    SearchFrom[p_graph.AdjArray[p_startVertex][i]] = p_startVertex;
                    dfs(p_graph, p_graph.AdjArray[p_startVertex][i]);
                }
            }
        }

        /// <summary>
        /// May cause serious memory problem if vertex count large.
        /// </summary>
        public void OutputOrder()
        {
            Console.WriteLine(searchOrder.Select(item => item.ToString()).Aggregate((i, j) => i + "," + j));
        }
    }

    /// <summary>
    /// Adj list repersentation, no duplicate edge, no self loop edge.
    /// </summary>
    public class Graph
    {
        public int VertexCount;
        public int EdgeCount;
        public List<int>[] AdjArray;

        public List<int>[] WeightArray;

        protected int size;

        public Graph()
        {
            size = 16;
            AllocateArray();
        }

        public Graph(int p_count)
        {
            size = p_count;
            AllocateArray();
        }

        private void AllocateArray()
        {
            AdjArray = new List<int>[size];
            WeightArray = new List<int>[size];
        }

        protected void Resize()
        {
            size *= 2;
            var tempAdj = new List<int>[size];
            AdjArray.CopyTo(tempAdj, 0);

            AdjArray = tempAdj;

            var tempWeight = new List<int>[size];
            WeightArray.CopyTo(tempWeight, 0);

            WeightArray = tempWeight;
        }

        /// <summary>
        /// Bad performance
        /// </summary>
        /// <param name="p_first"></param>
        /// <param name="p_second"></param>
        /// <returns></returns>
        public int GetWeight(int p_first, int p_second)
        {
            if (p_first >= 0 && p_first < AdjArray.Length && AdjArray[p_first].Contains(p_second))
            {
                int index = AdjArray[p_first].IndexOf(p_second);

                return WeightArray[p_first][index];
            }
            else
            {
                return -1;
            }
        }

        public virtual void AddEdge(int p_first, int p_second, int p_weight = -1)
        {
            if (p_first == p_second)
            {
                return;
            }

            while (size <= p_first || size <= p_second)
            {
                Resize();
            }

            AddAdj(p_first, p_second, p_weight);
            AddAdj(p_second, p_first, p_weight);
        }

        protected void AddAdj(int p_first, int p_second, int p_weight = -1)
        {
            if (p_first >= AdjArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (AdjArray[p_first] == null)
            {
                AdjArray[p_first] = new List<int>();
                WeightArray[p_first] = new List<int>();
                VertexCount++;
            }

            if (AdjArray[p_second] == null)
            {
                AdjArray[p_second] = new List<int>();
                WeightArray[p_second] = new List<int>();
                VertexCount++;
            }

            if (!AdjArray[p_first].Contains(p_second))
            {
                AdjArray[p_first].Add(p_second);
                WeightArray[p_first].Add(p_weight);
                EdgeCount++;
            }
        }
    }

    public abstract class BaseHash
    {
        public virtual int GetHashCode(object p_key)
        {
            if (p_key.GetType() == typeof(int))
            {
                var hash = Convert.ToInt32(p_key);
                return hash;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    public class LPHash<Key, Value> : BaseHash where Key : struct
    {
        public LPItem<Key, Value>[] tables;
        private int number;
        private int size;

        public LPHash()
        {
            size = 16;
            GenerateEmptyArray();
        }

        public LPHash(int p_size)
        {
            size = p_size;
            GenerateEmptyArray();
        }

        private void GenerateEmptyArray()
        {
            tables = new LPItem<Key, Value>[size];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new LPItem<Key, Value>();
            }
        }

        private void Resize(int p_size)
        {
            var temp = new LPHash<Key, Value>(p_size);

            for (int i = 0; i < size; i++)
            {
                if (!tables[i].IsEmpty)
                {
                    temp.Add(tables[i].key, tables[i].value);
                }
            }

            tables = temp.tables;
            number = temp.number;
            size = temp.size;
        }

        public override int GetHashCode(object p_key)
        {
            return base.GetHashCode(p_key) * 2 % size;
        }

        public void Add(Key p_key, Value p_value)
        {
            var hash = GetHashCode(p_key);
            for (int i = hash; ; i = (i + 1) % size)
            {
                if (tables[i].IsEmpty)
                {
                    tables[i] = new LPItem<Key, Value>(p_key, p_value);
                    number++;

                    if (number > size / 2)
                    {
                        Resize(2 * size);
                    }

                    return;
                }
                else if (tables[i].key.Equals(p_key))
                {
                    tables[i].value = p_value;
                }
            }
        }

        public bool Get(Key p_key, ref Value p_value)
        {
            var hash = GetHashCode(p_key);
            for (int i = hash; ; i = (i + 1) % size)
            {
                if (tables[i].IsEmpty)
                {
                    return false;
                }
                else if (tables[i].key.Equals(p_key))
                {
                    p_value = tables[i].value;
                    return true;
                }
            }
        }
    }

    public class LPItem<Key, Value> where Key : struct
    {
        public Key key;
        public Value value;
        public bool IsEmpty = true;

        public LPItem()
        {

        }

        public LPItem(Key p_key, Value p_value)
        {
            key = p_key;
            value = p_value;
            IsEmpty = false;
        }
    }

    public class SCHash<Key, Value> : BaseHash where Key : struct
    {
        public SCItem<Key, Value>[] tables;
        private int size;

        public SCHash()
        {
            size = 10000;
            GenerateEmptyArray();
        }

        public SCHash(int p_size)
        {
            size = p_size;
            GenerateEmptyArray();
        }

        private void GenerateEmptyArray()
        {
            tables = new SCItem<Key, Value>[size];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new SCItem<Key, Value>();
            }
        }

        public override int GetHashCode(object p_key)
        {
            return base.GetHashCode(p_key) % size;
        }

        public void Add(Key p_key, Value p_value)
        {
            tables[GetHashCode(p_key)].Add(p_key, p_value);
        }

        public bool Get(Key p_key, ref Value p_value)
        {
            return tables[GetHashCode(p_key)].Get(p_key, ref p_value);
        }
    }

    public class SCItem<Key, Value> where Key : struct
    {
        public Key key;
        public Value value;
        public bool IsEmpty = true;

        public SCItem<Key, Value> Next;

        public SCItem()
        {

        }

        public SCItem(Key p_key, Value p_value)
        {
            key = p_key;
            value = p_value;
            IsEmpty = false;
        }

        public void Add(Key p_key, Value p_value)
        {
            if (IsEmpty)
            {
                key = p_key;
                value = p_value;
                IsEmpty = false;
            }
            else
            {
                SCItem<Key, Value> previous = null;
                SCItem<Key, Value> current = this;
                do
                {
                    if (Equals(p_key, current.key))
                    {
                        current.value = p_value;
                        return;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
                while (current != null);
                previous.Next = new SCItem<Key, Value>(p_key, p_value);
            }
        }

        public bool Get(Key p_key, ref Value p_value)
        {
            if (IsEmpty)
            {
                return false;
            }
            else
            {
                var current = this;
                do
                {
                    if (Equals(p_key, current.key))
                    {
                        p_value = value;
                        return true;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                while (current != null);

                return false;
            }
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

        public void TestSortInternal(Action<List<int>> p_action)
        {
            Console.WriteLine(p_action.Method.Name);

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

        public void ShellSort(List<int> p_data)
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

        public void QuickSort(List<int> p_data)
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

        public void MergeSort(List<int> p_data)
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

        public void InsertSort(List<int> p_data)
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

        public void SelectSort(List<int> p_data)
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
