// Question:
// Write a function to sort a stack such that the smallest items are on the top.
// Can use an additional temporary stack but cannot copy the elements into another data structure
// Stack supports push, pop, peek, isempty


// Approach:
// Find the place where the value belongs, push back and forth as necessary
// Insert each element from s1 in order into s2 rather than iterating through for the minimum value
// for every item


// Solution 1
void sort(Stack s) {
    Stack r = new Stack<int>();
    while(s.Count > 0) {
        int temp = s.Pop();
        while(r.Count > 0 && r.Peek() > temp) {
            s.Push(r.Pop());
        }
        r.Push(temp);
    }

    while(r.Count > 0) {
        s.Push(r.Pop());
    }

}

// Solution Time Complexity = O(N^2)
// Solution Space Complexity = O(N)

// If unlimited stacks were allowed, could implement a modified quicksort (two additional stacks per 
// level of recursion, divide elements into these based on a pivot element, recursively sort, merge back 
// into original stack) OR mergesort (two additional stacks per level of recursion, divide in half, recursively
// sort, and merge back in sorted order into the original stack)