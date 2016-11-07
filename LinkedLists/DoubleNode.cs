using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
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
        public List<char> TranslateToList() {
            var n = this.ToString();
            var list = new List<char>();
            foreach (var ch in n) {
                if ((ch != '-') && (ch != '>') && (ch != '<') && (ch != ' ')) { //i was doing this before, and i was incorrect in that I had an || condition, as opposed to an && condition... 
                    list.Add(ch); 
                }
            }
                return list; //so does this translate to being the reversed form of this... reverse as a method for the lists has a null return value
        }
        public List<char> ReverseList(List<char> n) {
            var copy = new List<char>();
            foreach (var val in n) {
                copy.Add(val);
            }; //using a foreach here, i got diff results from assiging n to a copy than using the foreach...
                //when i didn't use a foreach, as n is manipulated in the for loop below, copy was also manipulated, despite being instantiated before
            for (int i = 0, j = n.Count() - 1; i < n.Count(); i++, j--) {
                n[i] = copy[j];
            }
            return n;
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
    public class DoubleNodeTests {
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
        public DoubleNode<char> ReversedDoubleLinkedList() {
            var d = new DoubleNode<char>('d');
            var c = new DoubleNode<char>('c');
            var b = new DoubleNode<char>('b');
            var a = new DoubleNode<char>('a');
            d.previous = null;
            d.next = c;
            c.previous = d;
            c.next = b;
            b.previous = c;
            b.next = a;
            a.previous = b;
            a.next = null;
            return d; 
        }
        public List<char> SampleList() {
            return new List<char> { 'a', 'b', 'c', 'd' }; 
        }

        [Test]
        public void CountMethodForDoublyLinkedNodes() {
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
        [Test]
        public void EqualsTestDoubleNode() {
            var expected = true;
            var actual = secondSampleDoubleLinkedNode().Equals(sampleDoubleLinkedNode());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReverseList() {
            var reverse = new DoubleNode<char>(); 
            var expected = new List<char>() { 'd', 'c', 'b', 'a' };
            var actual = reverse.ReverseList(SampleList()); 
            Assert.AreEqual(expected, actual); 
        }
        //[Test]
        //public void ReverseLinkedListTest() {
        //    var expected = ReversedDoubleLinkedList();
        //    var actual = ();
        //    Assert.AreEqual(expected, actual); 
        //}
    }
}