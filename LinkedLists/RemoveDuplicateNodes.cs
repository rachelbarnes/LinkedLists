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
                a = new Cell<char> {
                    value = item,
                    next = a //this is a good point of recursion... it's actually setting up what's goin on in the tests... 
                             //value is the value, next is null. if there's another item in the list, then the next item is assigned to another node,
                             //and the link is null, and continues through the list of items in teh foreach loop, but when the foreach is done, there is no link, so a being delcared null in line 17 is > impt than it looks
                };
            }
            Cell<char> b = null; // new Cell<char>();//  = null; 
            while (a != null) {
                b = new Cell<char> {
                    value = a.value,
                    next = b
                };
                a = a.next; 
            }
                return b.PrintCellRec();
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
