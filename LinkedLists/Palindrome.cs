using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
    /*
     Check to see if a linked list is a palindrome
     
     Count the number of nodes in the linked list, if it's an even number, 
        split the list in half and assign the other half to a new variable;     
        reverse one of the linked lists, and say while one is not null, if a.value == b.value bool = true, then at the end, return bool 

    Count the number of nodes in the linked list, and if it's an odd number, 
        divide count by 2, rounding either down or up. Put the rest in another variable. Reverse them. While a || b (whichever is shorter) != null, 
        reverse one of the lists and if a.value == b.value, bool = true;
            because you're using the shorter list to determine the condition of the while loop, there will be one node left over, 
            which is fine because that will be the middle node
    */
    public class Palindrome {
        public DoubleNode<char> CreateANewLinkedListAtHalfwayPoint(DoubleNode<char> n) {
            var countOfNodes = n.Count();
            DoubleNode<char> b = new DoubleNode<char>();
            int divide = countOfNodes / 2;
            int currentNodePosition = 0;
            while (n != null) {
                currentNodePosition++;
                if (currentNodePosition > divide) { //wow, so this is always true... which is why i'm getting the full linked list back... so i may be onthe right track when i fix this conditional
                    b.value = n.value;
                    b.next = n.next;
                    b.previous = null;
                    return b;
                }
                n = n.next;
            }
            return b;
        }

        //public DoubleNode<char> ReverseLinkedList(DoubleNode<char> a) {
        //    var head = new DoubleNode<char>();
        //    var secondA = a; 
        //    while (a != null) {
        //        head.value = a.value;
        //        head.next = a.previous;
        //        head.previous = null; 
        //        if (a.next == null) { //so if going bakcwards on a doesn't work becasue we remove the node from memory, then let's assemble the head backwards

        //            while (a.previous != null) { //as soon as I get here... i get a null reference point
        //                a.previous = head.next;
        //                head = head.next;
        //                a = a.previous;
        //            }
        //        }
        //        a = a.next; 
        //    }
        //    return head;
        //}

        public DoubleNode<char> ReverseLinkedList(DoubleNode<char> a) {
            var head = new DoubleNode<char>(); 
             
        }

        //public bool AmIAPalindrome(DoubleNode<char> a) {
        //    bool AmI;
        //    var head = new DoubleNode<char>(); //creating a new linked list of a/2, in effort to reverse that list
        //    var b = CreateANewLinkedListAtHalfwayPoint(a);
        //    while (b != null) {
        //        if (b.next == null)
        //    }
        //}
        //    public bool AmIAPalindrome(DoubleNode<char> a) {
        //        bool AmI;
        //        int countSimilarities = 0;
        //        var countOfNodes = a.Count();
        //        while (b != null) {
        //            if (b.next == null) {
        //                head = b;
        //                while (b.previous != null) {
        //                    b.previous = head.next;
        //                    head = head.next;
        //                    b = b.previous;
        //                }
        //            }
        //        }
        //        while (head != null) {
        //            if (head.value == a.value) {
        //                countSimilarities++;
        //                AmI = true;
        //            }
        //            if (head.value != a.value) {
        //                return false;
        //            }
        //            head = head.next;
        //            a = a.next;
        //        }
        //        if (countSimilarities == head.Count()) {
        //            AmI = true;
        //        } else AmI = false;
        //        return AmI;
        //    }
        //}
        //}
        //    if (countOfNodes % 2 != 0) {
        //        //if the count is odd, divide the number, and round up. 
        //        //
    }
    [TestFixture]
    public class PalindromeTests {
        public DoubleNode<char> PartOfX() {
            var d = new DoubleNode<char>('d');
            var e = new DoubleNode<char>('e');
            var f = new DoubleNode<char>('f');
            d.previous = null;
            d.next = e;
            e.previous = d;
            e.next = f;
            f.previous = e;
            f.next = null;
            return d;
        }
        public DoubleNode<char> ReversePartOfX() {
            var f = new DoubleNode<char>('f');
            var e = new DoubleNode<char>('e');
            var d = new DoubleNode<char>('d');
            f.previous = null;
            f.next = d;
            e.previous = f;
            e.next = d;
            d.previous = e;
            d.next = null;
            return f;
        }
        public DoubleNode<char> x() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d');
            var e = new DoubleNode<char>('e');
            var f = new DoubleNode<char>('f');
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = e;
            e.previous = d;
            e.next = f;
            f.previous = e;
            f.next = null;
            return a;
        }
        public DoubleNode<char> y() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d');
            var e = new DoubleNode<char>('e');
            var f = new DoubleNode<char>('f');
            var g = new DoubleNode<char>('g');
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = e;
            e.previous = d;
            e.next = f;
            f.previous = e;
            f.next = g;
            g.previous = f;
            g.next = null;
            return a;
        }
        public DoubleNode<char> xPalindrome() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('c');
            var e = new DoubleNode<char>('b');
            var f = new DoubleNode<char>('a');
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = e;
            e.previous = d;
            e.next = f;
            f.previous = e;
            f.next = null;
            return a;
        }
        public DoubleNode<char> yPalindrome() {
            var a = new DoubleNode<char>('a');
            var b = new DoubleNode<char>('b');
            var c = new DoubleNode<char>('c');
            var d = new DoubleNode<char>('d');
            var e = new DoubleNode<char>('c');
            var f = new DoubleNode<char>('b');
            var g = new DoubleNode<char>('a');
            a.previous = null;
            a.next = b;
            b.previous = a;
            b.next = c;
            c.previous = b;
            c.next = d;
            d.previous = c;
            d.next = e;
            e.previous = d;
            e.next = f;
            f.previous = e;
            f.next = g;
            g.previous = f;
            g.next = null;
            return a;
        }

        [Test]
        public void CreateANewLLFromOriginal() {
            var pal = new Palindrome();
            var expected = PartOfX();
            var actual = pal.CreateANewLinkedListAtHalfwayPoint(x());
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReverseLinkedListTest() {
            var pal = new Palindrome();
            var expected = ReversePartOfX();
            var actual = pal.ReverseLinkedList(PartOfX());
            Assert.AreEqual(expected, actual);
        }
        //[Test]
        //public void EvenNumberPalindrome() {
        //    var pal = new Palindrome();
        //    var expected = true;
        //    var actual = pal.AmIAPalindrome(xPalindrome());
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void OddNumberPalindrome() {
        //    var pal = new Palindrome();
        //    var expected = true;
        //    var actual = pal.AmIAPalindrome(yPalindrome());
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void EvenNumberNotAPalindrome() {
        //    var pal = new Palindrome();
        //    var expected = false;
        //    var actual = pal.AmIAPalindrome(x());
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void OddNumberNotAPalindrome() {
        //    var pal = new Palindrome();
        //    var expected = false;
        //    var actual = pal.AmIAPalindrome(y());
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
