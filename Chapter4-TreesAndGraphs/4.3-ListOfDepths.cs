// Question:
// Given a binary tree, design an algorithm which creates a linked list of
// all the nodes at each depth (tree with depth 'D' will have 'D' linked lists)


// Approach:
// Can traverse the graph any way, only thing that matters is we know what level we're
// on for the current node

// Solution 1 - depth first traversal
static void createLinkedLists(TreeNode root, List<LinkedList<TreeNode>> lists, int level) {
    // Base case
    if(root == null) {
        return;
    }

    LinkedList<TreeNode> list = null;
    if(lists.Count == level) {
        // Level not contained in list
        // Traversed in order so if this is the first time we've visited level i we must
        // have seen levels 0 through i - 1
        // Can then safely add the level at the end
        list = new LinkedList<TreeNode>();
        lists.add(list);
    } else {
        list = lists[level];
    }
    list.Add(root);
    createLinkedLists(root.left, lists, level + 1);
    createLinkedLists(root.right, lists, level + 1);
}

static List<LinkedList<TreeNode>> createLinkedLists(TreeNode root) {
    List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
    createLinkedLists(root, lists, 0);
    return lists;
}


// Solution 1 - breadth first traversal
static List<LinkedList<TreeNode>> createLinkedLists(TreeNode root) {
    List<LinkedList<TreeNode>> result = new List<LinkedList<TreeNode>>();
    LinkedList<TreeNode> current = new LinkedList<TreeNode>();
    if(root != null) {
        current.Add(root);
    }
    while(current.Count > 0) {
        result.Add(current);
        LinkedList<TreeNode> parents = current;
        current = new LinkedList<TreeNode>();
        foreach(TreeNode parent in parents) {
            if(parent.left != null) {
                current.Add(parent.left);
            }
            if(parent.right != null) {
                current.Add(parent.right);
            }
        }
    }
    return result;
}

// Both solutions run in O(N) time and require returning of O(N) data
// Technically the first must also have O(log(N)) extra space usage from
// recursive calls but they are equivalent in terms of big-O notation