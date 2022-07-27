// Question:
// Implement an algorithm to delete a node in the middle of a singly linked list, 
// given only access to that node


// Approach:
// Since there is no access to the head, we need to just copy over the next node's data to
// the current node, then delete the next node (which is now an identical copy)

// Solution 1
static bool deleteNode(LinkedListNode x) {

    // Edge Cases - may want to discuss with interviewer if it should be possible to
    // delete the last node in the list and how to handle it (mark as dummy, etc.)
    if(x == null || x.next == null) {
        return false;
    }

    LinkedListNode nextNode = x.next;
    x.data = nextNode.data;
    x.next = nextNode.next;
    return true;
}