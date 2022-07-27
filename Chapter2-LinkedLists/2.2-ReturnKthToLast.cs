// Question:
// Implement an algorithm to find the kth to last element of a singly linked list


// Approach:
// Can be both a longer, more optimal non-recursive solution but also a cleaner, less-optimal recursive solution
// Assuming that k = 1 is the last element, k = 1 is the second last, etc.
// Also assuming that the size of the linked list is unknown (otherwise iterating to node length - k is trivial)

// Solution 1 - Recursive
static int returnKthToLastCount(LinkedListNode head, int k) {

    if(head == null) {
        return 0;
    }

    // Recursively count nodes until the desired node is reached
    // This count can then be used to iterate if the actual node is desired
    int index = 1 + returnKthToLastCount(head.next, k);
    if(index == k) {
        Console.WriteLine("Head Data " + head.value);
    }
    return index;
}


// Solution Time Complexity = O(N)
// Solution Space Complexity = O(N)

// This solution may only be valid depending on what the interviewer says, since it doesn't actually
// return the node itself   Otherwise we need to pass values by reference (update counter by passing
// a pointer to it), create a wrapper class for the counter, or use some solution to update both the node
// and the counter in a way that all levels of the recursive stack can see


// Solution 2 - Iterative
// Use two pointers; place one 'k' spots ahead of the other and then move in tandem
// so that the lagging one will be length - k steps into the list (k nodes from the end)
// when the other pointer hits the end of the linked list
static LinkedListNode returnKthToLastNode(LinkedListNode head, int k) {
    LinkedListNode ptrLagging = head;
    LinkedListNode ptrLeading = head;

    for(int i = 0; i < k; ++i) {
        if(ptrLeading == null) {
            return null;
        }
        ptrLeading = ptrLeading.next;
    }

    while(ptrLeading != null) {
        ptrLeading = ptrLeading.next;
        ptrLagging = ptrLagging.next;
    }

    return ptrLagging;
}

// Solution Time Complexity = O(N)
// Solution Space Complexity = O(1)