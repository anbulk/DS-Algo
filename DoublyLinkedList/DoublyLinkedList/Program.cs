using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class Node
    {
        public Node prv;
        public Node nxt;
        public int data;

       public  Node(int d)
       {
           data = d;
           nxt = prv = null;
       }



    }



    class Program
    {
        static void Main(string[] args)
        {
            Node dll = new Node(1);
            var n2 = new Node(2);
            n2.prv = dll;
            dll.nxt = n2;
            var n3 = new Node(3);
            n3.prv = n2;
            n2.nxt = n3;

            dll = Rev(dll);

            while (dll != null)
            {

                Console.WriteLine(dll.data);
                dll = dll.nxt;
            }

        }

        public static Node Rev(Node curr)
        {
            
            while (curr.nxt != null)
            {
                var temp = curr.prv;
                curr.prv = curr.nxt;
                curr.nxt = temp;

                curr = curr.prv;



            }

            curr.nxt = curr.prv;
            curr.prv = null;


            return curr;

        }
    }
}
