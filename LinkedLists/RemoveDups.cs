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
        //testing this method with a string return type... 
        public string RemoveDuplicateNodesString(Node<char> n) {
            var dict = new Dictionary<char, int>();
            var current = n;
            while (current != null) { //what's the difference between (n.value != null) and (current != null) 
                                      //one is evaluating the value, and the other is evalutating 
                if (current.next != null) {
                    var currentValue = current.value;
                    if (!dict.Keys.Contains(currentValue)) {
                        dict.Add(currentValue, 1);
                    }
                    if (dict.Keys.Contains(currentValue)) {
                        dict[currentValue] = dict[currentValue] + 1;
                    }
                    if (current.next != null) {
                        current = current.next; //i'm getting the null reference exception here, because i tell 'd' to point to null, hence the null reference... 
                    }
                }
            }
            foreach (KeyValuePair<char, int> pair in dict) {
                n.value = pair.Key;
                n = n.next;
            }
            return n.ToString();
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
        [Test]
        public void RemoveDupsString() {
            var remove = new RemoveDups();
            var n = new Node<char>('a', new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null)))));
            var expected = "a -> b -> c -> d";
            var actual = remove.RemoveDuplicateNodesString(n);
            Assert.AreEqual(expected, actual);
        }
    }
}
