// Question:
// Assume you have a method to check if one word is a substring of another. Given two strings,
// s1 and s2, check if s2 is a rotation of s1 using only one call to the method


// Approach:
// Just need to find the rotation part, break into two parts and re-arrange into the original
// Even simpler, just concatenate string s1 + s1 and test if that is a substring! Easy

// Solution 1

// Trivial to do in C#, depending on isSubstring implementation may have to be careful
// of string buffer or length but this is unlikely


// Additional Notes
// Don't overthink some problems!