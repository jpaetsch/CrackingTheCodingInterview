// Question:
// Given a sorted (increasing order) array with unique integer elements,
// write an algorithm to create a binary search tree with minimal height


// Approach:
// Need the left subtree nodes roughly equal to the right subtree nodes, so
// the root should be in the middle... similarly keep halving arrays to
// get an evenly distributed binary tree

// Solution 1
static TreeNode createMinimalBST(int[] array) {
    return createMinimalBST(array, 0, array.Length - 1);
}

static TreeNode createMinimalBST(int[] arr, int start, int end) {
    if(end < start) {
        return null;
    }
    int middle = (start + end) / 2  // C# is statically typed so 'int' will make this automatically floored
    TreeNode newNode = new TreeNode(arr[middle]);
    newNode.left = createMinimalBST(arr, start, mid - 1);
    newNode.right = createMinimalBST(arr, mid + 1, end);
    return newNode;
}