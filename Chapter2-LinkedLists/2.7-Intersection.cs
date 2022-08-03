// Question:
// Given two singly linked lists, determine if the two lists intersect. Return the intersecting node.
// Intersection is defined based on refferenced not value.


// Approach:
// Could use a hash table and reference by memory location (not value)
// However all intersecting lists will have the same final node - to actually find where the intersection
// is we can't traverse at the same speed (may not be the same length).  Therefore we could
// get the lengths of each and then 'chop off' the extra nodes on the longer list

// Solution 1
public class Result {
    public int listLength;
    public LinkedListNode tail;

    public Result(int listLength, LinkedListNode tail) {
        this.listLength = listLength;
        this.tail = tail;
    }
}

static LinkedListNode getIntersectionNode(LinkedListNode listOneHead, LinkedListNode listTwoHead) {
    
    if(listOneHead == null || listTwoHead == null) {
        return null;
    }

    Result resultOne = getTailAndSize(listOneHead);
    Result resultTwo = getTailAndSize(listTwoHead);

    if(resultOne.tail != resultTwo.tail) {
        return null;
    }

    LinkedListNode shorter = resultOne.listLength < resultTwo.listLength ? listOneHead : listTwoHead;
    LinkedListNode longer = resultOne.listLength < resultTwo.listLength ? listTwoHead : listOneHead;

    // After this function the longer list node is advanced so that both pointers are at the same point
    // in their respective lists
    longer = getKthNode(longer, abs(resultOne.listLength - resultTwo.listLength));

    while(shorter != longer) {
        shorter = shorter.next;
        longer = longer.next;
    }

    return shorter; // Could return either one...

}


// Would need to implement get Kth node (advance pointer for the longer list by the
// difference in lengths) and the getTailAndSize to return a filled result value (length and tail node) after
// iterating through a linked list, but a fairly clean and straightforward solution