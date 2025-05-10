public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //decalre an array for doubles
        double[] numbers = new double[length];

       //use for loop to iterate through the numbers
        for (int i = 0; i < length; i++)
        {
            //This will add the number to the index. This is figured out by multiplying the number by i(since that will keep going up)
            numbers[i] = number * (i + 1);
        }
        //return my array here
        return numbers;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        //declare left and right lists
        List<int> rightList = new();
        List<int> leftList = new();

        //slice right list to get right side
        rightList = data.GetRange(data.Count - amount, amount);

        //slice left part of list to get the left side
        leftList = data.GetRange(0, data.Count - amount);

        //declare new list
        List<int> newList =
        [
            //add ranges to the new list(This was added by a "quick fix" option in visual studio, not using AI)
            .. rightList,
            .. leftList,
        ];

        //clear old data list
        data.Clear();

        //make newlist the data list
        data.AddRange(newList);

        

    }
}
