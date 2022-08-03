// Question:
// You have two numbers represented by a linked list, where each node contains a single
// digit.  The digits are stored in reverse order such that the 1's digit is at the head
// of the list.  Write a function that adds the two numbers and returns the sum as a linked list.
// Follow up: suppose that the digits are stored in forward order. Repeat the same problem.

// Approach:
// Reverse order storage is fine, we just need to store the carries as we move along.

// Solution 1 - recursive function
static LinkedListNode sumReverseOrderLists(LinkedListNode list1, LinkedListNode list2, int carry) {
    if(list1 == null && list2 == null && carry == 0) {
        return null;
    }

    LinkedListNode result = new LinkedListNode();
    int value = carry;

    if(list1 != null) {
        value += list1.value;
    }
    if(list2 != null) {
        value += list2.value;
    }

    result.data = value % 10;

    if(list1 != null || list2 != null) {
        LinkedListNode next = addLists(list1 == null ? null : list1.next, list2 == null ? null : list2.next, value >= 10 ? 1 : 0);
        result.next = more;
    }
    
    return result;
} 


// For the follow up, the logic is essentially the same but we need to ensure the lists remain
// at the same place, wrapper class to pass the carry backwards, etc.