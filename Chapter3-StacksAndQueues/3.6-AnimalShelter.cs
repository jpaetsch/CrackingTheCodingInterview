// Question:
// An animal shelter holds cats and dogs and operates on a first in, first out basis.
// People can choose either dog or cat and adopt the oldest of that type.
// Create data structures to maintain this system and implement operations
// such as enqueue, dequeueAny, dequeueDog, dequeueCat
// May use the built-in LinkedList data structure

// Approach:
// One approach is to use seperate queues for dogs and cats and then wrap in an animal queue class
// Then some sort of timestamp marks when each animal is enqueued and the dequeueAny() call will
// peek at the heads of both the dog and cat queue and return the oldest