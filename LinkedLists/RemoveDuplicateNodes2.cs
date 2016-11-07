﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
    public class RemoveDuplicateNodes2 {
        public Node<char> RemoveDuplicateNodes(Node<char> n) {
            var list = new List<char>();
            Node<char> previous = n;
            Node<char> ret = n; 
            while (n != null) {
                if (!list.Contains(n.value)) {
                    list.Add(n.value);
                    previous = n;
                } else {
                    previous.next = n.next;
                    //creating a new link to the next node... in this case, b2 gets ignored... draw this out and look at it 
                }
                    n = n.next; 
            }
            return ret;
        }
    }
    [TestFixture]
    public class RemoveDupTests {
        [Test]
        public void RemoveDup1() {
            var remove = new RemoveDuplicateNodes2();
            var x = new Node<char>('a', new Node<char>('b', new Node<char>('b', new Node<char>('c', new Node<char>('a', new Node<char>('d', null))))));
            var expected = new Node<char>('a', new Node<char>('b', new Node<char>('c', new Node<char>('d', null)))).ToString();
            var actual = remove.RemoveDuplicateNodes(x).ToString(); //having this ToString before was to dull some of the confusino that rose in the hierarchal structure, but it's much more useful when you have 2 generic lists that come back not seeing the values... 
            Assert.AreEqual(expected, actual);
        }
    }
}
//var dict = new Dictionary<char, int>(); 
//if (n.next != null) {
//    if (dict.Keys.Contains(n.value)) {
//        dict[n.value] = dict[n.value] + 1; 
//    }
//    if (!dict.Keys.Contains(n.value)) {
//        dict.Add(n.value, 1); 
//    }
//    n = n.next; 
//}
//foreach (KeyValuePair<char, int> pair in dict) {
//    n.value = pair.Key; //this is where I'm getting the null reference exception... 
//    n = n.next;
//    //i originally did this with a dictionary, however looking back at the debugging and what I know of dictionaries, it will not give me the exact order it came in... 
//}
//return n; 

//Node<char> b = null; 
//while (a != null) {
//    var current = new Node<char>() {
//        value = a.value,
//        next = b,
//    }; 
//    b = current;
//    a = a.next; 
//}

            //Node<char> a = null;
            //list.Reverse();
            //foreach (var element in list) {
            //    var current = new Node<char>() {
            //        value = element,
            //        next = a,
            //    };
            //    a = current;
            //}
