// Question:
// Implement an algorithm to determine if a string has all unique characters.
// What if you cannot use additional data structures?


// Approach:
// Ask about encoding type (ASCII, Unicode, etc.)
// Array of boolean values based on the alphabet, flag at index i indicates if i is in the string
// Return false the second time you see a character based on the flag, or if string length exceeds
// the number of unique characters in the alphabet (ex. ASCII has 128 characters, extended ASCII has 256, etc.)


// Solution 1 - use boolean array data structure to flag seen characters
	// Solution 1 - use boolean array data structure to flag seen characters
static bool isUniqueChars(string str) {
    // Check if length exceeds unique characters in the set
    if (str.Length > 128) { return false; }

    // Set up an boolean array data structure and iterate over all characters in the input string,
    // setting flag values once a new character is seen
    bool[] setOfChars = new bool[128];
    for(int i = 0; i < str.Length; ++i) {
        int value = str[i];
        if(setOfChars[value]) {
            return false;
        }
        setOfChars[value] = true;
    }
    return true;
}


// Solution Time Complexity = O(n)
// n being the length of the string in character, could argue O(1) due to the initial check of character set
// so never more than that amount of characters will be iterated to
// Solution space complexity is O(1)
// the space of the input string itself


// Could also state O(c) space and O(min(c, n)) time if the character set size is non-fixed
// Could also use a bit vector, int if string only uses lowercase letters


// For no additional data structures we could brute force by comparing every character to every
// other character (O(n^2) time and O(1) space).
// Another approach is sorting the string in O(n*log(n)) time and then linearly checking neighbours of each
// but this also involves being aware of additional space taken up by the chosen sorting algorithm