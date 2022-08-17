// Question:
// Implement a MyQueue class which implements a queue using two stacks


// Approach:
// Queue is FIFO while stack is LIFO.  So we need to modify peek and pop to go in reverse order
// Use the second stack to reverse the order of the elements (popping stack 1 and pushing elements on to stack 2)
// Make a 'newest' stack with newest elements on top and an 'oldest' stack with oldest elements on top
// When dequeing an element, remove oldest first so dequeue from oldest stack
// If oldest stack is empty, transfer all elements from stack newest into this stack in reverse order
// To insert an element, push onto stack newest