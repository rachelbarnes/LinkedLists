using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedLists {
    public class Node<T> {
        public Node<T> next;
        public T value;

        public Node() { }

        public Node(T _value, Node<T> _next) {
            value = _value;
            next = _next;
        }

        public int Count() {
            if (next != null) {
                return 1 + next.Count();
            }
            return 1;
        }

        /*
        This was my code before, the second ToString() method for Node<T> is from Steve's suggestion
            missing the adding the next value
        public string ToString() { //
            if (next != null) {
                return value.ToString() + " -> "; //I realized no recursion
            }
            return value.ToString();
        } */
        public string ToString() { //Steve's suggested code
            if (next == null) {
                return value.ToString();
            }
            return value.ToString() + " -> " + next.ToString();
        }

        //static bool Compare<T> (T x, T y) where T : class {
        //    return x == y; 
        //}

        //public static bool operator == (Node<T> a, Node<T> b) {
        //    return a.Equals(b); 
        //}
        //public static bool operator != (Node<T> a, Node<T> b) {
        //    return (!a.Equals(b)); 
        //}
        //public Node<T> ListToLinkedList(List<T> list) {
        //    Node<T> LL;
        //    var count = list.Count(); 
        //    for (int i = 0; i < count; i++) {
        //        if (list[i] == list[count])
        //    }
        //    //var listArr = list.Split(' '); 
        //    //while (listArr != null) {
        //    //    LL = 
        //    //}
        //}
    }

    public class DoubleNode<T> {
        public DoubleNode<T> previous;
        public DoubleNode<T> next;
        public T value;

        public DoubleNode() { }

        public DoubleNode(T _value) {
            value = _value; 
        }
        //public DoubleNode(DoubleNode<T> _previous, T _value, DoubleNode<T> _next) {
        //    previous = _previous;
        //    value = _value;
        //    next = _next;
        //}
        //i don't see a need for this method to be any different from the method, you're still counting the nodes in the linked list, which 
        //having a link to the previous node makes no difference on how many there are
        public int Count() {
            if (next != null) {
                return 1 + next.Count();
            }
            return 1;
        }

        public override string ToString() {
            if (next == null) { //I had if (next == null || previous == null), 
                    //but if we're only "writing" this one way (in this case, from left to right), then it shouldn't matter if the previous is null. The head is the head. 
                return value.ToString(); 
            }
            return value.ToString() + " <-> " + next.ToString(); 
        }
        //why did I have to override this DoubleNode<T>.ToString() and not Node<T>.ToString()? they're in different classes?
        // Is the DoubleNode<T>.ToString() overriding the Node<T>? 

    }

    [TestFixture]
    public class NodeTesting {
        //these are tests for both Nodes and DoubleNodes (singly and doubly linked lists)
        [Test]
        public void CountMethodForNode() {
            var b = new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null))));
            var expected = 4;
            var actual = b.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void StringMethodForNode() {
            var b = new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null))));
            var expected = "a -> b -> c -> d";
            var actual = b.ToString();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountMethodForDoublyLinkedNodes() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d'); 
            /*
            Because the only way to do declare a doubly linked list is to declare their links separate from the constructor, the DoubleNode<char>(T value) only takes the value...
                There may be a way of making the links in constructors and objects, but no easy way for sure. It is going to be better to assign their links elsewhere (like below)
            */
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = null;
            var expected = 4; 
            var actual = a.Count();
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ToStringForDoublyLinkedNodes() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d');
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = null;
            var expected = "a <-> b <-> c <-> d";
            var actual = a.ToString();
            Assert.AreEqual(expected, actual); 
        }
    }
}