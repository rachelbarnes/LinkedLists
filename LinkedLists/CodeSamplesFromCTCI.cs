using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists {
    class CodeSamplesFromCTCI {
        //These are examples from Cracking the Coding Interview on Linked Nodes: 
        
        //Creating a Linked List: 
        public class CTCINode {
            CTCINode next = null;
            int data; 

            public CTCINode(int d) {
                data = d; 
            }
            void appendoTail(int d) {
                CTCINode end = new CTCINode(d);
                CTCINode n = this; 
                while (n.next != null) {
                    n = n.next; 
                }
                n.next = end; 
            }

        //Deleting a Node from a Single Linked List: 
            CTCINode deleteNode(CTCINode head, int d) {
                CTCINode n = head; 

                if (n.data == d) {
                    return head.next; //moved head
                }

                while (n.next != null) {
                    if (n.next.data == d) {
                        n.next = n.next.next;
                        return head; //head didn't change
                    }
                    n = n.next; 
                }
                return head; 
            }
        }
    }
}

//Looking at the Runner Technique: 
    /* 
    This is often called a second pointer. Two runners iterate through the linked list at the same time, one going regular paced, and the other
        going twice as fast (n = n.next.next as opposed to n.next). 
    */