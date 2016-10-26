using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedLists {
    /*
    Implement an algorithm to find the kth to last element of a singly linked list
    */
    public class ReturnKthToLast {
        public DoubleNode<char> ReturnNodes(DoubleNode<char> n, char k) {
            DoubleNode<char> alternateNode = null;
            DoubleNode<char> currentNode = n;
            while (currentNode != null) {
                if (currentNode.value == k) {
                    alternateNode = currentNode;
                    return alternateNode;
                }
                currentNode = currentNode.next; 
            }
            return alternateNode;
        }
    }

    [TestFixture]
    public class ReturnKthToLastTests {
        public DoubleNode<char> MyLinkedList() {
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
        public Func<DoubleNode<char>, string> MyLinkedListString = n => n.ToString();

        //this test is not passing, although the expected and the actual are the same in the TestExplorer...
            //is it the issue of comparing two different objects not being exactly equal? 
        [Test]
        public void ReturnPartOfALinkedListTest() {
            var remove = new ReturnKthToLast();
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d');
            var e = new DoubleNode<char>('e');
            c.previous = null;
            c.next = d;
            d.previous = c;
            d.next = e;
            e.previous = d;
            e.next = null;
            var expected = c;
            var actual = remove.ReturnNodes(MyLinkedList(), 'c');
            Assert.AreEqual(expected, actual);
        }
    }
}

