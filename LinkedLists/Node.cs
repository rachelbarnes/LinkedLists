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
        public string ToString() {
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

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            Node<T> p = (Node<T>)obj;
            return p.ToString() == this.ToString();
        }
    }

    public class DoubleNode<T> {
        public DoubleNode<T> previous;
        public DoubleNode<T> next;
        public T value;

        public DoubleNode() { }

        public DoubleNode(T _value) {
            value = _value;
        }
        public int Count() {
            if (next != null) {
                return 1 + next.Count();
            }
            return 1;
        }
        public override string ToString() {
            if (next == null) {
                return value.ToString();
            }
            return value.ToString() + " <-> " + next.ToString();
        }
        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            DoubleNode<T> p = (DoubleNode<T>)obj;
            return p.ToString() == this.ToString();
        }
    }


    [TestFixture]
    public class NodeTesting {
        [Test]
        public void NodeEqualsOverride() {
            var a = new Node<char>('a', new Node<char>('b', new Node<char>('c', null)));
            var b = new Node<char>('a', new Node<char>('b', new Node<char>('c', null)));
            var expected = true;
            var actual = a.Equals(b);
            Assert.AreEqual(expected, actual);
        }
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
    }
    [TestFixture]
    public class DoubleNodeTests {
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
        public DoubleNode<char> sampleDoubleLinkedNode() {
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
            return a;
        }
        public DoubleNode<char> secondSampleDoubleLinkedNode() {
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
            return a;
        }
        [Test]
        public void EqualsTestDoubleNode() {
            var expected = true;
            var actual = secondSampleDoubleLinkedNode().Equals(sampleDoubleLinkedNode());
            Assert.AreEqual(expected, actual);
        }
        //these are tests for both Nodes and DoubleNodes (singly and doubly linked lists)
    }
}