using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedLists {
    //Write code to remove duplicates from an unsoted linked list
    //FOLLOW UP: How would you solve this problem if a temporary buffer is not allowed?
    public class RemoveDups {
        public Node<char> RemoveDuplicateNodes(Node<char> n) {
            var dict = new Dictionary<char, int>();
            if (n.next != null) {
                var currentValue = n.value;
                if (!dict.Keys.Contains(currentValue)) {
                    dict.Add(currentValue, 1);
                }
                if (dict.Keys.Contains(currentValue)) {
                    dict[currentValue] = dict[currentValue] + 1;
                }
            }
            foreach (KeyValuePair<char, int> pair in dict) {
                n.value = pair.Key;
                n = n.next;
            }
            return n;
        }
    }

    [TestFixture]
    public class TestRemovingDuplicateNodes {
        [Test]
        public void RemoveDuplicateNodes() {
            var remove = new RemoveDups();
            var n = new Node<char>('a', new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null)))));
            var expected = new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null)))).ToString();
            var actual = remove.RemoveDuplicateNodes(n).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
