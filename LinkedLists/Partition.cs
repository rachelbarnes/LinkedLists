using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {
    /*
        all nodes less than x should be to the left of x. If x is contianed within the list, the vales of x 
            only need to be after x (no distinguishment of the values greater than x...)

        **so, theoretically, if the hard requirement is to put all ints less than the designated partition int left of that, and there's
            no specific requirement for the ones that are greater, this can be done in 2 ways: 
                put all ints that are less than the partition to the left, and put all ints greater than the partition to the right ...or...
                put all values != partition to the left, and insert the partition to the right of all the values, having that as the only sorting logic


        For example: 
        Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition of 5]
        Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
    */
    public class Partition {
        /*
        "Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x. 
        If x is contained within the list, the values of x only need to be after the elements less than x (see below). The partition element x can appear anywhere in the 
        "right partition"; it does not need to appear between the left and right partitions."
        Example: Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition 5]
                 Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8

            it seems that there are a few ways to do this: 
                * sort the entire list and put the list in numerical order
                * put the partition value(s) (in case there's more than one instnace of the partition, like above) at the end of the  list
            
            the easiest thing to do that I can see if to remove the partition nodes, make a note of how many partitions there are (for example, what if there are
                2 or 3 partitions, you still need all nodes accounted for (I'm thinking either a list and foreach through each element in the list, or have a count, and 
                    count-- and when the count is 1 or 0 and all the partition nodes have been accounted for and the appropriate nodes have been attached, return the linked list). 

                I'm guessing that in order to add the partition nodes at the end of the linked list, I need to link them the previous nodes, and thus needing a DoubleNode? 
                    try a singly linked list first 


            I realized that this algorithm only accounts for one instance of the partition value in a linked list... that is something I have to account for when redoing this one
        */

        public DoubleNode<int> PartitionDoublyLL(DoubleNode<int> n, int partition) {
            var count = 0;
            var partitionTail = new DoubleNode<int>();
            while (n.next != null) {
                if (n.value == partition) {
                    count++; 
                    n.next.previous = n.previous;
                    n.previous.next = n.next;
                    n = n.next;
                }
                if (n.next != null) {
                    n = n.next;
                }
                if (n.next == null) {
                    //this is where I still have to mend some of my work, this only accounts for one of the nodes contianing the partition value, where there could be many
                    if (count == 1) {
                        count--;
                        partitionTail.value = partition;
                        n.next = partitionTail;
                        partitionTail.next = null;
                        while (n.previous != null) { 
                            partitionTail.previous = n;
                            n = n.previous; 
                        }
                        return n;
                    }
                }
            }
            return n;
        }
    }

    //n.value = partition;
    //n.previous.next = n;
    //n.next = null; 

    //n.previous = n; 
    //partitionTail.value = partition;
    //partitionTail.previous = n;
    //n.next = partitionTail; // this adds 10 to the previous partitionTail node... but doesn't add the rest? 


    //partitionTail = partitionTail.next; //i think this is the right thing to do, but its not adding this into n.... 
    [TestFixture]
    public class TestPartitions {
        public DoubleNode<int> LinkedListForPartitionTests() {
            var a = new DoubleNode<int>(1);
            var b = new DoubleNode<int>(2);
            var c = new DoubleNode<int>(3);
            var d = new DoubleNode<int>(6);
            var e = new DoubleNode<int>(9);
            var f = new DoubleNode<int>(22);
            var g = new DoubleNode<int>(12);
            var h = new DoubleNode<int>(10);
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
            g.next = h;
            h.previous = g;
            h.next = null;
            return a;
        }
        [Test]
        public void PartitionTest1() {
            var part = new Partition();
            var a = new DoubleNode<int>(1);
            var b = new DoubleNode<int>(2);
            var c = new DoubleNode<int>(3);
            var d = new DoubleNode<int>(6);
            var e = new DoubleNode<int>(22);
            var f = new DoubleNode<int>(12);
            var g = new DoubleNode<int>(10);
            var h = new DoubleNode<int>(9);
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
            g.next = h;
            h.previous = g;
            h.next = null;
            var expected = a;
            var actual = part.PartitionDoublyLL(LinkedListForPartitionTests(), 9);
            Assert.AreEqual(expected, actual);
        }
    }
}

