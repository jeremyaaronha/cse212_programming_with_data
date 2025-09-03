public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // create an array with the size of length
        var result = new double[length];

        // loop through each position in the array
        for (int i = 0; i < length; i++)
        {
            // store the number times (i + 1) in the array
            result[i] = number * (i + 1);
        }

        // return the array
        return result;
    }

public static void RotateListRight(List<int> data, int amount)
{
    // get the last part of the list
    List<int> lastPart = data.GetRange(data.Count - amount, amount);

    // remove the last part from the list
    data.RemoveRange(data.Count - amount, amount);

    // insert the last part at the beginning of the list
    data.InsertRange(0, lastPart);
}
}