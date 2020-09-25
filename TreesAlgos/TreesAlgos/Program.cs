using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TreesAlgos
{


    #region Data structure
    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public T Data { get; set; }

        public Node(T data)
        {
            Left = Right = null;
            Data = data;

        }

    }



    public class MyStack<T>
    {
        public List<Node<T>> data = new List<Node<T>>();

        public void push(Node<T> d)
        {

            data.Add(d);

        }

        public Node<T> pop()
        {
            var node = data[data.Count() - 1];
            data.RemoveAt(data.Count() - 1);
            return node;
        }

    }

    #endregion





    class Program
    {
        public bool FindTarget(Node<int> root, int k)
        {
            return true;
        }

        public bool SearchTree(Node<int> root,int target)
        {
            var key = target - root.Data;

            if (root == null)
                return false;

            if (root?.Data == key)
                return true;

           var val = SearchTree(root.Left, target);

            if (val)
                return val;

           val = SearchTree(root.Left, target);
           return val;


        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;


        }

        static int height_Tree<T>(Node<T> root)
        {
            if (root == null)
                return 0;

            else
            {
                return 1 + Max(height_Tree(root.Left),
                           height_Tree<T>(root.Right));
            }
        }


        static bool IsBalanced<T>(Node<T> root)
        {
            if (root == null)
                return true;

            else
            {
                var lh = height_Tree((root.Left));
                var rh = height_Tree((root.Right));

                if (Math.Abs(lh - rh) <= 1 &&
                    IsBalanced<T>(root.Left) && IsBalanced<T>(root.Right)

                )
                {

                    return true;

                }

                return false;



            }



        }

        static void TraveseInorder_Rec<T>(Node<T> root)
        {
            if (root == null)
                return;
            TraveseInorder_Rec<T>(root.Left);
            Console.WriteLine(root.Data);
            TraveseInorder_Rec<T>(root.Right);

        }


        static void TraveserInorderWithStack<T>(Node<T> root)
        {
            if (root == null)
                return;

            MyStack<T> s = new MyStack<T>();
            Node<T> current = root;
            while (current != null || s.data.Count() > 0)
            {

                while (current != null)
                {

                    s.push(current);
                    current = current.Left;

                }

                current = s.pop();

                Console.WriteLine(current.Data);

                current = current.Right;

            }
        }


        static void TraverseInOrder<T>(Node<T> root)
        {

            if (root == null)
                return;

            Node<T> current = root;

            while (current != null)
            {
                if (current.Left == null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Right;
                }
                else
                {
                    var pre = current.Left;
                    while (pre.Right != null && pre.Right != current)
                        pre = pre.Right;



                    if (pre.Right == null)
                    {
                        Console.WriteLine(current.Data);
                        pre.Right = current;
                        current = current.Left;
                        // Console.WriteLine(current.Data);

                    }
                    else
                    {
                        pre.Right = null;
                        // Console.WriteLine(current.Data);
                        current = current.Right;
                    }


                }

            }



        }


        static void TraversePreorder_Rec<T>(Node<T> root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.Data);
            TraversePreorder_Rec<T>(root.Left);
            TraversePreorder_Rec<T>(root.Right);

        }



        static void TraversePreorder<T>(Node<T> root)
        {

            if (root == null)
                return;

            var current = root;
            while (root != null)
            {
                if (root.Left == null)
                {
                    Console.WriteLine(root.Data);
                    root = root.Right;
                }
                else
                {
                    var pre = root.Left;
                    while (pre.Right != null && pre.Right != root)
                        current = current.Right;

                    if (current.Right != root)
                    {

                        Console.WriteLine(root.Data);
                        current.Right = root;
                        root = root.Left;
                    }
                    else
                    {
                        current.Right = null;
                        root = root.Right;

                    }


                }
            }




        }


        static void TraversePostorder_Rec<T>(Node<T> root)
        {

            if (root == null)
                return;

            TraversePostorder_Rec<T>(root.Left);
            TraversePostorder_Rec(root.Right);
            Console.WriteLine(root.Data);

        }




        static void Main(string[] args)
        {


            Node<int> root = new Node<int>(1);
            root.Left = new Node<int>(2);
            root.Right = new Node<int>(3);
            root.Left.Left = new Node<int>(4);
            root.Left.Right = new Node<int>(5);
          //  root.Left.Left.Left = new Node<int>(8);
           // root.Left.Left.Right = new Node<int>(9);
           // root.Left.Right.Left = new Node<int>(10);
            //root.Left.Right.Right = new Node<int>(11);
            Console.WriteLine(IsBalanced(root));
            //TraverseInOrder(root);
            // TraversePreorder(root);
            // TraveserInorderWithStack(root);
            // TraverseInOrder(root);
            //TraveseInorder_Rec((root));



            Console.Read();

        }
    }
}
