// Question:
// Given a circular linked list, implement an algorithm that returns the node
// at the beginning of the loop


// Approach:
// A twist on the classic 'detect if a linked list has a cycle' using fast/slow pointers approach.
// To find the collision location, a little math is needed... will meet after loop size - k turns
// where they will both be k nodes from the front of the loop and the head of the linked list
// will also be k nodes from the front of the loop

// Solution 1
static LinkedListNode findCollisionNode(LinkedListNode head) {
    LinkedListNode slow = head;
    LinkedListNode fast = head;

    while(fast != null && fast.next != null) {
        slow = slow.next;
        fast = fast.next.next;
        if(slow == fast) { // Collision
            break;
        }
    }

    // Edge case - the linked list is not cyclical
    if(fast == null || fast.next == null) {
        return null;
    }

    // Move slow to the head, keep fast at the meeting point.  Each are k steps
    // from the loop start, so if they move at the same pace they will meet at the loop start
    slow = head;
    while(slow != fast) {
        slow = slow.next;
        fast = fast.next;
    }

    return slow; // Could return either as they both point to the start of the loop
}


// Solution Time Complexity = O(??)
// explain
// Solution Space Complexity = O(??)
// explain


// Additional Notes