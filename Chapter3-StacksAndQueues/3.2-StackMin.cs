// Question:
// How would you design a stack which, in addition to push and pop, has a function min which
// returns the minimum element?  Push, pop, and min should all operate in O(1) time


// Approach:
// Minimums only change when a smaller element is added, however if this minimum value is 
// popped from the stack we need to search through the stack to find the new minimum
// This breaks the constraint that push() and pop() operate in O(1) time

// Keep track of the minimum at each state - each node records what the minimum 'beneath itself' is
// Then to find the minimum you just look at what the top element thinks is the minimum

// Push() - element is given the current minimum

// Could potentially do better with storage by keeping an additional stack that keeps track of mins
// instead of every node remembering state