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
            while (n != null) { 
                if (!list.Contains(n.value)) {
                    list.Add(n.value);
                }
                n = n.next; 
            }
            Cell<char> a = null; //note to self, this has to be null... 
            foreach (var item in list) {
                //if (item == list.Last()) {
                //    a.value = item;
                //    a.next = null; 
                //}
                a = new Cell<char> {
                    value = item,
                    next = a
                }; 
                 //look at line 32-36 in SumLists.cs... what's different that I get the linked list formed there, but not here?
            } // now the reversing of hte linked list...
                 //for future reference, having that if (item == list.last()) messes things up... it almost throws away the other 
                 //nodes in the linked list, forgets them and only returns the last, hwich is why i was only getting 'd' for my value 
                    //in my supposed to be 4 noded linked list but only having 1 node.
            return a.PrintCellRec();
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
    }
}
