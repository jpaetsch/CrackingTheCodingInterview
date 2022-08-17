// Question:
// If a stack of plates gets too high, it may topple.  Implement a data structure SetOfStacks that
// starts a new stack when the previous one exceeds some threshold capacity.  Push and pop should
// behave identically to a single stack.
// Follow up - implement a function popAt(int index) which performs a pop operation on a specific sub-stack


// Solution 1
public class SetOfStacks {

    public int capacity;
    public ArrayList stacks = new ArrayList();

    public SetOfStacks(int capacity) {
        this.capacity = capacity;
    }

    public void push(int value) {
        Stack last = getLastStack();
        if(last != null && !(last.Count == capacity)) {
            last.Push(value);
        } else {
            Stack newStack = new Stack(capacity);
            newStack.Push(value);
            stacks.Add(newStack);
        }
    }

    public int pop() {
        Stack last = getLastStack();
        if(last == null) {
            throw new Exception("Stack is empty");
        }
        int value = (int) last.Pop();
        if(last.Count == 0) {
            stacks.Remove(stacks.Count - 1);
        }
        return value;
    }

    public Stack getLastStack() {
        if(stacks.Count == 0) {
            return null;
        }
        return (Stack) stacks[stacks.Count - 1];
    }

    public Boolean isEmpty() {
        Stack last = getLastStack();
        return last == null || (last.Count == 0);
    }
}


// For the followup we need to imagine a rollover system.  If an element is popped from
// stack 1, we need to remove the bottom of stack 2 to push to stack 1, then continue rolling
// additional stracks over.
// This is a bit tricky to implement (requires quite a bit of code) but another approach is to
// just be okay with some stacks not being at full capacity