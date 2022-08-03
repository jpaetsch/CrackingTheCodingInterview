// Question:
// Implement a function to check if a linked list is a palindrome


// Approach:
// Could reverse the list and compare to the original - must be identical
// Could also just detect if the front half of the list is the reverse of the second half
// (use a stack and fast/slow pointer methodology to find the halfway point)
// Can also do it recursively but then need a special class to pass values or a double
// pointer in C/C++

// Solution 1 - clone and reverse method
static boolean isPalindromeOne(LinkedListNode head) {
    LinkedListNode reversedHead = reverseAndClone(head);
    return isEqual(head, reversedHead);
}

static boolean reverseAndClone(LinkedListNode node) {
    LinkedListNode head = null;
    while(node != null) {
        LinkedListNode n = new LinkedListNode(node.data);
        n.next = head;
        head = n;
        node = node.next;
    }
    return head;
}

static boolean isEqual(LinkedListNode nodeOne, LinkedListNode nodeTwo) {
    while(nodeOne != null && nodeTwo != null) {
        if(nodeOne.data != nodeTwo.data) {
            return false;
        }
        nodeOne = nodeOne.next;
        nodeTwo = nodeTwo.next;
    }
    return nodeOne == null && nodeTwo == null;  // Both nodes should be null at this point, otherwise not palindrome
}


// Solution 2 - halfway method
static boolean isPalindromeTwo(LinkedListNode head) {
    LinkedListNode fast = head;
    LinkedListNode slow = head;

    Stack<int> stack = new Stack<int>();

    while(fast != null && fast.next != null) {
        stack.push(slow.data);
        slow = slow.next;
        fast = fast.next.next;
    }

    // If there's an odd number of elements, skip the comparison of the middle element
    if(fast != null) {
        slow = slow.next;
    }

    while(slow != null) {
        int top = stack.pop();

        if(top != slow.data) {
            return false
        }

        slow = slow.next;
    }

    return true;
}

// Check the textbook for the recursive approach...