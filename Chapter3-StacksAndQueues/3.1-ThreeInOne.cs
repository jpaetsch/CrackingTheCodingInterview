// Question:
// Describe how you could use a single array to implement three stacks


// Approach:
// Could allocate a fixed amount of space for each stack
// Could also be flexible in space allocation


// Solution 1 - Fixed division, where Stack 1 = [0, n/3), Stack 2 = [n/3, 2n/3), Stack 3 = [2n/3, n)

// Keep track of each stack's size, capacity, pointer etc.
// Functions include push, pop, peek, isfull, isempty, index of top, etc.


// Solution 2 - Flexible division, when one stack exceeds its initial capacity
// the allowable capacity grows and other elements are shifted.

// Design the array to be circular, a complex implementation where
// psuedocode may be required but true implementation is more complex than an interview would require