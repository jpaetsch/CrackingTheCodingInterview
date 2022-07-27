// Question:
// Write code to partition a linked list around a value x, such that all nodes
// less han x come before all nodes greater than or equal to x. If x is contained within the list,
// the values of x only need to be after the elements less than x.  Partition element x can appear
// anywhere in the 'right partition', it does not need to appear between the left and right partitions

// Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1  [partition = 5]
// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8

// Approach:
// Linked lists are cheaper than shifting/swapping elements like in an array
// Create two different linked lists and then merge them

// Solution 1 - code with comments
static LinkedListNode partitionLinkedList(LinkedListNode head, int partitionVal) {
    LinkedListNode smallHead = null;
    LinkedListNode smallTail = null;
    LinkedListNode bigHead = null;
    LinkedListNode bigTail = null;

    LinkedListNode node = head;
    while(node != null) {
        // Create next based off of original list but reset its link
        LinkedListNode next = node.next;
        next.next = null;

        // Insert node into the end of the small list
        if(node.val < partitionVal) {
            // If it's the first node in the small list,
            // Set up head and tail of the small list
            if(smallHead == null) {
                smallHead = node;
                smallTail = smallHead;
            // Otherwise set the small list tail to the node
            // and move it forward
            } else {
                smallTail.next = node;
                smallTail = node;
            }
        // Insert node into the end of the big list
        } else {
            // If it's the first node in the big list,
            // Set up head and tail of the big list
            if(bigHead == null) {
                bigHead = node;
                bigTail = bigHead;
            // Otherwise set the big list tail to the node
            // and move it forward
            } else {
                bigTail.next = node;
                bigTail = node;
            }
        }
        node = next;
    }

    // Catch the edge case where there is no small list
    if(smallHead == null) {
        return bigHead;
    }

    // Merge lists and return
    smallTail.next = bigHead;
    return smallHead;
}

// Many other optimal solutions exist, this approach keeps the 'stability' of the original
// list a bit better but this may not matter to the interviewer