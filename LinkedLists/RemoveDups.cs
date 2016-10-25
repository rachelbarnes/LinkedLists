using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework; 

namespace LinkedLists {
    //Write code to remove duplicates from an unsoted linked list
    //FOLLOW UP: How would you solve this problem if a temporary buffer is not allowed?
    public class RemoveDups {

        /*
            Where I'm leaving off: have to assign newList.next to the next next. I'm not sure if what I did here is correct or not. 
        */
        public Node<char> RemoveDuplicateNodes(Node<char> originalLinkedList) {
            var dict = new Dictionary<char, int>();
            while (originalLinkedList.next != null) {
                if (!dict.Keys.Contains(originalLinkedList.value)) {
                    dict.Add(originalLinkedList.value, 1);
                }
                if (dict.Keys.Contains(originalLinkedList.value)) {
                    dict[originalLinkedList.value] = dict[originalLinkedList.value] + 1;
                }
            }
            Node<char> newList = new Node<char>();
            foreach (KeyValuePair<char, int> pair in dict) {
                //create a new linked list: 
                //assign the value the key, assign the next? 
                newList.value = pair.Key;
                newList.next = newList.next.next;  
            }
            return newList;
        }
    }
}
