// Question:
// Given two strings, write a method to decide if one is a permutation of the other


// Approach:
// Check if it is case sensitive, if whitespace is significant
// Know that characters will be the same, just in different order so sort and compare the strings
// Assuming it is case sensitive and whitespace is significant, know that strings of different lengths
// cannot be permutations


// Solution 1 - not necessarily optimal but straightforward, sort the strings and compare
// Sort and return the input string
static string sort(string s) {
    char[] toSort = s.ToCharArray();
    Array.Sort(toSort);
    return new String(toSort);
}

// Check sorted strings to see if they are equal
static bool isPermutation(string str1, string str2) {
    if(str1.Length != str2.Length) { return false; }

    return sort(str1).Equals(sort(str2));
}


// Solution 2 - more optimal using character counts assuming ASCII (128 character set)
static bool isPermutation(string str1, string str2) {
    if(str1.Length != str2.Length) { return false; }

    // Create an array of letter counts in the first string
    int[] letterCount = new int[128];
    char[] toCount = str1.ToCharArray();
    foreach (var c in toCount) {
        letterCount[c]++;
    }

    // Decrement the letter counts each time the letter is seen in the second string,
    // returning false if it does not match
    for(int i = 0; i < str2.Length; ++i) {
        int idx = str2[i];
        letterCount[idx]--;
        if(letterCount[idx] < 0) {
            return false;
        }
    }
    return true;
}