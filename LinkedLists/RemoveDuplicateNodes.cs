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
                    previous = current;//note the imptce of having the previous = current here, as opposed to at the end of the hwile loop and at the end of the else
                } else { 
                    previous/*a1*/.next = current/*a2*/.next /*b*/;
                }
                current = current.next;
            }
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