// Question:
// Write an algorithm such that if an element in an MxN matrix is 0,
// its entire row and column are set to 0


// Approach:
// Can't iterate through elements and change immediately since otherwise
// by the end the entire matrix will be 0
// Passthroughs to store locations of 0's and then apply changes
// Could have a second matrix to flag 0 locations but O(MN) space is unnecessary
// as we just need to flag rows and columns if they have a zero... two arrays, one O(M) and one O(N)

// Solution 1
static bool zeroMatrix(int[,] matrix) {

    // Print the input array
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for(int j = 0; j < matrix.GetLength(1); ++j) {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }

    bool[] isRowZero = new bool[matrix.GetLength(0)];
    bool[] isColZero = new bool[matrix.GetLength(1)];

    // Flag rows and columns to change to 0 using the two arrays
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for(int j = 0; j < matrix.GetLength(1); ++j) {
            if(matrix[i, j] == 0) {
                isRowZero[i] = true;
                isColZero[j] = true;
            }
        }
    }

    // Use the row flag array to set the matrix values to 0
    for(int i = 0; i < isRowZero.Length; ++i) {
        if(isRowZero[i] == true) {
            for(int j = 0; j < matrix.GetLength(1); ++j) {
                matrix[i, j] = 0;
            }
        }
    }

    // Use the col flag array to set the matrix column values to 0
    for(int i = 0; i < isColZero.Length; ++i) {
        if(isColZero[i] == true) {
            for(int j = 0; j < matrix.GetLength(0); ++j) {
                matrix[j, i] = 0;
            }
        }
    }

    // Print the output array
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for(int j = 0; j < matrix.GetLength(1); ++j) {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }

    return true;

}

// Should break up into functional components for better testability

// Solution Space Complexity = O(M) + O(N)
// for the boolean array, could additionally optimize to O(1) space by using the first row and col of the
// matrix array as the comparison or use bit vector for O(N)


// Additional Notes