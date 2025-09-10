public static class MysteryStack1
{
    // this function receives a text
    public static string Run(string text)
    {
        // create a stack to hold characters
        var stack = new Stack<char>();

        // put each letter into the stack
        foreach (var letter in text)
            stack.Push(letter);

        // create empty result
        var result = "";

        // take letters from the stack and add to result
        while (stack.Count > 0)
            result += stack.Pop();

        // return the reversed text
        return result;
    }
}