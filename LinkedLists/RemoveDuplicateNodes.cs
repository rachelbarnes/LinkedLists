using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedLists {
    public class RemoveDuplicateNodes {
        public string RemoveDupNodes(Cell<char> n) {
            var list = new List<char>();
            Cell<char> previous = null;
            var current = n;
            while (current != null) {
                if (!list.Contains(current.value)) {
                    list.Add(current.value);
                    previous = current;//note the imptce of having the previous = current here, as opposed to at the end of the while loop and at the end of the else
                } else {
                    /*
                        if the condition above on line 15 is true, then previous is equal to the current. if that is not true, it comes to this else
                        and the previous node (which has not yet been assigned to the current node) is linked to the node after the current node 
                            the current node at this point is the repeated char
                        
                        with this code, we are saying that the previous node (which is still a unique char) is linked to the node after the current node
                    */
                    previous/*a1*/.next = current/*a2*/.next/*b*/;
                }
                current = current.next;
            } 
            /*
            why return n? why have the other variables for n? 
                These pointers allow manipulation in different and more efficient ways, and uses considerably less memory
                The previous pointer is able to point to the node previous to the current, based on assigning that pointer only when the character is
                    unique, allowing current to be moved to the next node, and previous pointing to the node that (at line 30) is now one previous to current
                The current pointer goes through the linked list one at a time, doing the manipulation and being the pointer to determine if that is a unique 
                    node within the list
                n, as the head of the list as a parameter, doesn't get moved and it doesn't get filtered through and manipulated, so when we return n on
                    line 43, we are returning the head of the list, that has all the work done that current did, so we are returning the updated list by 
                    simply calling n
            */
            return n.PrintCellRec(); 
        }
    }

    [TestFixture]
    public class RemoveDupsTests {
        [Test]
        public void RemoveDupsTest() {
            var rem = new RemoveDuplicateNodes();
            var n = new Cell<char>('a', new Cell<char>('b', new Cell<char>('a', new Cell<char>('b', new Cell<char>('c', new Cell<char>('d', new Cell<char>('a', null)))))));
            var expected = "a -> b -> c -> d";
            var actual = rem.RemoveDupNodes(n);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveDupsTest2() {
            var rem = new RemoveDuplicateNodes();
            var n = new Cell<char>('a', new Cell<char>('b', new Cell<char>('a', new Cell<char>('b', new Cell<char>('c', new Cell<char>('d', new Cell<char>('a', new Cell<char>('b', new Cell<char>('r', new Cell<char>('e', new Cell<char>('f', new Cell<char>('f', null))))))))))));
            var expected = "a -> b -> c -> d -> r -> e -> f";
            var actual = rem.RemoveDupNodes(n);
            Assert.AreEqual(expected, actual);
        }
    }
}

//this was the previous code before the refactoring
//Cell<char> a = null; //note to self, this has to be null... 
//foreach (var item in list) {
//    a = new Cell<char> {
//        value = item,
//        next = a 
//    };
//}
//Cell<char> b = null; // new Cell<char>();//  = null; 
//while (a != null) {
//    b = new Cell<char> {
//        value = a.value,
//        next = b
//    };
//    a = a.next; 
//}
//    return b.PrintCellRec();