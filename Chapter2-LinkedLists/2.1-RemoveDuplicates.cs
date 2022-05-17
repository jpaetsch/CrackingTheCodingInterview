// Question:
// First write code to remove duplicates from an unsorted linked list
// Then write code to solve this problem if a temporary buffer is not allowed


// Approach:
// Iterate through and add elements to a simple hash table - one pass
// If no buffer is allowed, we can add two pointers - one iterates through and the other checks
// all subsequent nodes for duplicates


// Solution 1 - using pseudo-code
using System.Collections.Generic;

static void removeDuplicatesHashMap(LinkedListNode n) {
    Dictionary<int> nodes = new Dictionary<int>();
    LinkedListNode previousNode = null;

    while(n != null) {
        if(nodes.ContainsValue(n.value)) {
            previousNode.next = n.next;
        } else {
            nodes.Add(n.value);
            previousNode = n;
        }
        n = n.next;
    }
}

// Solution 2

static void removeDuplicatesNoBuffer(LinkedListNode head) {
    LinkedListNode current = head;
    while(current != null) {
        LinkedListNode runner = current;
        while(runner.next != null) {
            if(runner.next.value == current.value) {
                runner.next = runner.next.next;
            } else {
                runner = runner.next;
            }
        }
        current = current.next;
    }
}

// Solution Time Complexity
// For the first solution, the time complexity is O(N) where N is the number of nodes in the linked list
// For the second solution, the time complexity is O(N^2) - tradeoff for less space

// Solution Space Complexity
// For the first solution, the space complexity can be up an additional O(N) for the buffer - no element with duplicates
// For the second solution, the space complexity is O(1)