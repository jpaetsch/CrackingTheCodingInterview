// Question:
// Given a directed graph, design an algorithm to find out whether there
// is a route between two nodes


// Approach:
// Simple graph traversal (such as depth-first or breadth-first search)
// Mark nodes found during the course of the algorithm as 'visited' to avoid cycles/repetition

// Solution 1 - Iterative
enum State {
    Unvisited,
    Visited,
    Visiting
}

static boolean search(Graph g, Node start, Node end) {
    if(start == end) {
        return true;
    }

    // Operate as a queue
    LinkedList<Node> q = new LinkedList<Node>();

    foreach(Node n in g.getNodes()) {
        n.state = State.Unvisited;
    }

    start.state = state.Visiting;
    q.add(start);
    Node u;
    while(!q.isEmpty()) {
        u = q.removeFirst();  // dequeue
        if(u != null) {
            foreach(Node v in u.getAdjacentNodes()) {
                if(v.state == State.Unvisited) {
                    if(v == end) {
                        return true;
                    } else {
                        v.state = State.Visiting;
                        q.add(v);
                    }
                }
            }
            u.state = State.Visited;
        }
    }
    return false;
}


// Depth first search is a bit simpler to implement (can be done with simple recursion)
// while breadth first search can be useful to find the shortest path