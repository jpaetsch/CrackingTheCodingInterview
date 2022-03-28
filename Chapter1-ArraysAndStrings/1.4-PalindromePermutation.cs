// Question:
// Given a string, write a function to check if it is a permutation (same letters of a different order)
// of a palindrome (same word forwards and backwards).  Does not need to be limited to just dictionary words.


// Approach:
// Character count to see if there are even numbers of each character, but there can be one solo character ie.
// the center of the palindrome  ex. obolb could be bolob - a palindrome that is permutated

// Solution 1 - this could be optimized with minor tweaks and is accounting for other languages as it used
// a more base-level hashtable instead of some C# implemented data structures
// Assuming lowercase letters are used
static bool isPermutatedPalindrome(string findFrequency) {
    
    // Set the basic hashtable size to range of all lowercase characters
    int[] table = new int[Convert.ToInt32('z') - Convert.ToInt32('a') + 1];

    // Count the frequency of characters in the string in the table if they are valid
    foreach(char ch in findFrequency) {
        int num = Convert.ToInt32(ch);
        if(Convert.ToInt32('a') <= num  && Convert.ToInt32('z') >= num) {
            table[num - Convert.ToInt32('a')]++;
        }
    }

    // Iterate through the hashtable and ensure all character counts are even with the exception
    // of one single character allowed
    int singles = 0;
    foreach(int i in table) {
        if(i % 2 != 0) {
            singles++;
        }
        if(singles > 1) {
            return false;
        }
    }
    return true;
}

// Solution Time Complexity = O(n)
// n is the length of the string - we iterate over each element twice (building the frequency table)
// and checking the frequencies = O(2n) = O(n)
// Solution Space Complexity = O(n) + O(c)
// c being the number of characters required in character count table


// Heavily adapted this example from the textbook as the original example was
// using Java and functionally broke it up, but tested using online compiler

// Could optimize by checking singles as we go along, but this wouldn't reduce anything
// by an order of magnitude and could potentially make it slower if more checks are required

// Another optimization could use a bit vector and operations for the string