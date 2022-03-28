// Question:
// Write a method to replace all spaces in a string with '%20'.  Assume string has sufficient space
// to hold additional characters and you are given the true length of the string.
// Ex.  Input = "Mr John Smith    ", 13
// Ex.  Output = "Mr%20John%20Smith"


// Approach:
// May be an easier method in C#, but accounting for other languages where a string
// is a character array or buffer - if using string type could implement in
// one pass by copying over new string for each space char
// Edit the string starting from the end and work backwards - extra buffer at the end allows
// character changes without overwriting
// For this algorithm use a two scan approach - count the number of spaces, triple this number (get the number
// of extra characters required), and edit the string

// Solution 1 - code with comments
static char[] replaceSpaces(char[] str, int trueLength) {
    
    int spaceCount = 0;
    for(int i = 0; i < trueLength; ++i) {
        if(str[i] == ' ') {
            spaceCount++;
        }
    }
    int index = trueLength + spaceCount * 2;
    for(int i = trueLength - 1; i >= 0; --i) {
        if(str[i] == ' ') {
            str[index - 1] = '0';
            str[index - 2] = '2';
            str[index - 3] = '%';
            index = index - 3;
        } else {
            str[index - 1] = str[i];
            index--;
        }
    }
	return str;
}