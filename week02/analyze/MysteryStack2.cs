public static class MysteryStack2
{
    // check if the text is a number
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    // main function to process input
    public static float Run(string text)
    {
        // create an empty stack
        var stack = new Stack<float>();

        // go through each part of the input
        foreach (var item in text.Split(' '))
        {
            // if it is an operator
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                // need at least two numbers
                if (stack.Count < 2)
                    throw new ApplicationException("invalid case 1");

                // take last two numbers
                var op2 = stack.Pop();
                var op1 = stack.Pop();

                float res;

                // do the correct operation
                if (item == "+")
                    res = op1 + op2;
                else if (item == "-")
                    res = op1 - op2;
                else if (item == "*")
                    res = op1 * op2;
                else
                {
                    // cannot divide by zero
                    if (op2 == 0)
                        throw new ApplicationException("invalid case 2");

                    res = op1 / op2;
                }

                // save the result in the stack
                stack.Push(res);
            }
            // if it is a number, save it
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            // if it is a space, skip it
            else if (item == "")
            {
            }
            // if it is something else, show error
            else
            {
                throw new ApplicationException("invalid case 3");
            }
        }

        // at the end, must be only one result
        if (stack.Count != 1)
            throw new ApplicationException("invalid case 4");

        // return the final number
        return stack.Pop();
    }
}