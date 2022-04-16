// Question:
// Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes,
// write a method to rotate the image by 90 degrees.  Can you do this in place?


// Approach:
// Implement the rotation in layers; circular type of pattern
// Could copy edges oto an array, but requires O(N) memory
// Instead swap index by index, moving outermost layer to inner

// Solution 1
static bool rotateMatrix(int[,] matrix) {		
    // Print the input matrix formatted
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }
    
    if(matrix.Length == 0 || matrix.GetLength(0) != matrix.GetLength(1)) {
        return false;
    }
    
    int x = matrix.GetLength(0);
    // odd numbers can be floored as the middle layer (single pixel) doesn't need to be rotated!
    for(int layer = 0; layer < x / 2; layer++) {
        int first = layer;
        int last = x - 1 - layer;
        for(int i = first; i < last; i++) {
            int offset = i - first;
            int top = matrix[first, i];  // save the top
            matrix[first, i] = matrix[last - offset, first];  // left -> top
            matrix[last - offset, first] = matrix[last, last - offset];  // bottom -> left
            matrix[last, last - offset] = matrix[i, last];  // right -> bottom
            matrix[i, last] = top;  // saved top -> right
        }
    }
    
    // Print the rotated output matrix formatted
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }
    return true;
}


// Solution Time Complexity = O(N^2)
// the best that can be done; any algorithm must touch all N^2 elements
// Solution Space Complexity = ?? O(N) since the top layer at most must be stored? or O(1) ?
// in place - no additional memory required


// Additional Notes

// This is a hard one for me to wrap my head around... conceptually makes sense just
// working out the offset and indices especially on the fly is difficult