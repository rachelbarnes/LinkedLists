using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedLists {
    public class DeleteMiddleNode {
        /*
        Implement an algorithm to delete a node in the middle (i.e any node but the first and the and lsat node, not necessarily exact middle) 
            of a singly linked list, given only access to that node. 
        */

        public DoubleNode<char> DeleteMidNode(DoubleNode<char> n, char k) {
            var current = n;
            while (current != null) {
                if (current.value == k) {
                    current.previous.next = current.next;
                    current.next.previous = current.previous; 
                }
                current = current.next;
            }
            return n;
        }

        [TestFixture]
        public class DeleteMiddleNodeTests {
            public DoubleNode<char> MyLinkedList() { //this is a hard coded linked list... i was trying to figure out how to delcare and set the original linked list
                                                     //and manipulate it in the same method... 
                var a = new DoubleNode<char>('a');
                var b = new DoubleNode<char>('b');
                var c = new DoubleNode<char>('c');
                var d = new DoubleNode<char>('d');
                var e = new DoubleNode<char>('e');
                a.previous = null;
                a.next = b;
                b.previous = a;
                b.next = c;
                c.previous = b;
                c.next = d;
                d.previous = c;
                d.next = e;
                e.previous = d;
                e.next = null;
                return a;
            }
            [Test]
            public void DeleteMiddleNodeFromLinkedList() {
                var delete = new DeleteMiddleNode();
                var a = new DoubleNode<char>('a');
                var b = new DoubleNode<char>('b');
                var c = new DoubleNode<char>('c');
                var d = new DoubleNode<char>('d');
                var e = new DoubleNode<char>('e');
                a.previous = null;
                a.next = b;
                b.previous = a;
                b.next = d;
                d.previous = b;
                d.next = e;
                e.previous = d;
                e.next = null;
                var expected = a;
                var actual = delete.DeleteMidNode(MyLinkedList(), 'c');
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
