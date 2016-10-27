using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
    /*
    Two linked lists in reverse (when a linked list is written, it starts with the head, and adds the nodes to the left)
        add the reverse of 2 int linked lists, then write it a linked list form, making that reversed as well:
        for example: input: (817 + 549)
            7 -> 1 -> 8 > ; 9 -> 4 -> 5; 
                     output: (1366)
    */
    public class SumLists {
        public Node<int> SumLinkedLists(Node<int> X, Node<int> Y) {
            Node<int> current = X;
            var xInt = "";
            var yInt = "";
            var result = 0;
            while (current != null) {
                xInt = current.value + xInt;
                current = current.next; //this one didn't get the 2!!!
            }
            current = Y;
            while (current != null) {
                yInt = current.value + yInt;
                current = current.next; //this one didn't get the 3!!! , so
            }
            //var resultString = (xInt + yInt).ToString(); 
            result = int.Parse(xInt) + int.Parse(yInt);
            Node<int> z = null;
            foreach (var num in result.ToString()) { //having the ToString() here does something different than above in line 30
                z = new Node<int> {
                    value = Int32.Parse(num.ToString()),
                    next = z,
                }; 
            }
            return z;
        }
    }
    //the code I have in that foreach loop is modeled after the code in the practice file, the code below is mine... 
             // i would like to see the difference, as the code below is giving me a null reference exception when it comes 
             //to assigning z.value = num (I think the num is giving me the exception
                //z.value = num;
                //z = z.next;
    [TestFixture]
    public class TestingSumLinkedLists {
        [Test]
        public void SumTwoLinkedLists() {
            var sum = new SumLists();
            var x = new Node<int>(6, new Node<int>(5, new Node<int>(8, new Node<int>(2, null)))); //  2856
            var y = new Node<int>(7, new Node<int>(4, new Node<int>(9, new Node<int>(3, null)))); // +3947 = 6803
            var expected = new Node<int>(3, new Node<int>(0, new Node<int>(8, new Node<int>(6, null))));
            var actual = sum.SumLinkedLists(x, y);
            Assert.AreEqual(expected, actual);

        }
    }
}
