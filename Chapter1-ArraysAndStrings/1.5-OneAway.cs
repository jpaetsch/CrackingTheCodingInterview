// Question:
// Three types of edits can be performed on strings: insert a character, remove a character,
// or replace a character.  Given two strings, write a function to check if they are one or zero edits away


// Approach:
// Brute force could check all possible strings one edit away but is not very feasible
// For replacement: only different in one place
// For insertion: one shift is needed
// For removal: same as insertion inverted
// The length of the string can inform which of these operations need to be checked

// Solution 1 - branch logic based on length that informs if one of the operations can make the strings equal
static bool isOneAway(string str1, string str2) {
    if(str1.Equals(str2)) {
        // No edit is needed
        return true;
    } else if(str1.Length == str2.Length) {
        // Check if replacement edit is needed
        return checkForReplacement(str1, str2);
    } else if(str1.Length - 1 == str2.Length) {
        // Check if removal edit is needed
        return checkForRemoval(str1, str2);
    } else if(str1.Length + 1 == str2.Length) {
        // Check if insertion edit is needed
        return checkForInsertion(str1, str2);
    } else {
        return false;
    }
}

// Count the number of replacements that would be necessary on a char by char basis
static bool checkForReplacement(string str1, string str2) {
    int replacementCount = 0;
    for(int i = 0; i < str1.Length; ++i) {
        if(str1[i] != str2[i]) {
            replacementCount++;
            if(replacementCount > 1) {
                return false;
            }
        }
    }
    return true;
}

// Count the number of removals that would be necessary on a char by char basis,
// changing string pointers if necessary
static bool checkForRemoval(string str1, string str2) {
    int removalCount = 0;
    int j = 0;
    for(int i = 0; i < str2.Length; ++i) {
        if(removalCount == 1) {
            j = i - 1;
        } else {
            j = i;
        }
        if(str1[i] != str2[j]) {
            removalCount++;
            if(removalCount > 1) {
                return false;
            }
        }
    }
    return true;
}

// Count the number of removals that would be necessary on a char by char basis,
// changing string pointers if necessary
static bool checkForInsertion(string str1, string str2) {
    int insertionCount = 0;
    int j = 0;
    for(int i = 0; i < str1.Length; ++i) {
        if(insertionCount == 1) {
            j = i + 1;
        } else {
            j = i;
        }
        if(str1[i] != str2[j]) {
            insertionCount++;
            if(insertionCount > 1) {
                return false;
            }
        }
    }
    return true;
}



// Solution Time Complexity = O(n)
// where n is the size of the string, which dictates the runtime as 1 char difference doesn't really matter
// and a difference of more than 1 char will terminate in O(1) time


// Could easily combine the remove and insert checks into a single function as it just uses the
// length of the longest string to avoid array index errors - could also combine edit and replace as well
// for minor optimizations