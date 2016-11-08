using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
    public class Cell<T> {
        public T value;
        public Cell<T> next;

        public Cell(T value, Cell<T> next) {
            this.value = value;
            this.next = next;
        }

        public string Print() { //recursive ToString()
            if (next == null) {
                return value.ToString(); //these are character type ToString()... it's T.ToString, not Cell.ToString()
            }
            return value.ToString() + " -> " + next.Print(); //this next is a link... you're not pointing to the next value, you're pointing to the next node
        }
    }

    public class CellHelper { //recursive Print method (similar to above (previously ToString(), now Print())... the only difference is this takes parameters
        public string Print<T>(Cell<T> head) {
            if (head.next == null) {
                return head.value.ToString(); //look at this in the recursive pattern shown in SICP... look at the collapsing values... 
            }
            return head.value.ToString() + " -> " + Print(head.next);   
        }
        public string PrintIter<T>(Cell<T> head) {
            var ret = "";
            while (head != null) {
                if (head.next != null) {
                    ret += head.value.ToString() + " -> ";   //are they identitcal vs are they same string (comparing the objects and the values)
                                                             //reference vs value... referencial equality and structural equality 
                                                             //(two identical objects can have 2 different places in memory, but are differetn becasue 
                                                                //they're not pointing to the same reference despite possibly having hte same values (lookat at the exact same reference)
                } else { 
                    ret += head.value.ToString(); 
                }
                head = head.next; 
            }
            return ret; 
        }
    }

    [TestFixture]
    public class CellTests {
        [Test]
        public void CellToStringTest() {
            var helper = new CellHelper(); 
            var x = new Cell<char>('a', new Cell<char>('b', new Cell<char>('b', new Cell<char>('c', new Cell<char>('a', new Cell<char>('d', null))))));
            var expected = "a -> b -> b -> c -> a -> d"; 
            var actual = helper.Print(x);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CellToStringTest2() {
            var helper = new CellHelper();
            var x = new Cell<char>('a', new Cell<char>('b', new Cell<char>('b', new Cell<char>('c', new Cell<char>('a', new Cell<char>('d', null))))));
            var expected = "a -> b -> b -> c -> a -> d";
            var actual = helper.PrintIter(x);
            Assert.AreEqual(expected, actual);
        }
    }
}
