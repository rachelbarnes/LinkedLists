using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework;

namespace LinkedLists {
    /*
    Implement an algorithm to find the kth to last element of a singly linked list
    */
    public class ReturnKthToLast {
        public Node<char> ReturnRestOfNodes(Node<char> originalLinkedList, char targetValue) {
            var dict = new Dictionary<int, char>();
            var inc = 0;
            Node<char> newLinkedList = new Node<char>();
            while (originalLinkedList.next.next != null) {
                dict.Add(inc++, originalLinkedList.value); //i choose the value because if there are repeated chars, i dont want it to be impacted by a dupicate key error
            }
            for (int i = 0; i < dict.Keys.Count(); i++) {
                if (!dict.Values.Contains(targetValue))
                    return null;
                if (dict.Values.Contains(targetValue)) {
                    newLinkedList.value = targetValue;
                    newLinkedList = newLinkedList.next;
                }
            }
        }
    }
}
