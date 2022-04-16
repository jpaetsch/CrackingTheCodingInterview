// Question:
// Implement a method to perform basic string compression using the counts of repeated characters
// Ex. aabbccccaaa would become a2b2c5a3.  If the 'compressed' string would not become smaller
// than the original string the method should return the original string.  Assume the string
// only has uppercase and lowercase letters.


// Approach:
// List thought/action approach(es)
// Assumptions

// Solution 1
static string compressString(string str) {

    string compressed = "";
    char currentChar = str[0];
    int currentCount = 0;
    for(int i = 0; i < str.Length; ++i) {
        if(currentChar != str[i]) {
            compressed += currentChar.ToString() + currentCount.ToString();
            currentCount = 1;
            currentChar = str[i];
            if(compressed.Length > str.Length) {
                return str;
            }
        } else if(i == str.Length - 1) { 
			currentCount += 1;
			compressed += currentChar.ToString() + currentCount.ToString();
			if(compressed.Length > str.Length) {
                return str;
            }
		} else {
            currentCount++;
        }
    }
	return compressed;
}


// Due to C#'s ability to handle some string operations better (similar to Java StringBuilder())
// this problem deviated from other solutions, but it still optimizes by checking
// the length as the compressed string goes so it will terminate as soon as the length exceeds
// the original string ... however string concatenation is still a slow operation for runtime
// about O(p + k^2) where p is the length of the original string and k^2 is the number of character
// sequences ie. concatenation operations required