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

        //Steps to be taken
        //Declare the double array with the same lenght of the length value
        //start a for loop where i variable will start from 0 and will end when it is less than the length variable
        //Each of the loops will save the result in the idex i of the double array, calculating i plus one (as we want to start from 1), times the number variable 
        //Return the array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = (i + 1) * number;
        }

        return result; // replace this return statement with your own
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


        // We can extract the values that will be rotated using GetRange method and saving those into a new list
        //The Get Range will have the index parameter as the number of items in the data list mines the amount variable value, and then the count parameter will be the amount value
        //We proceed to eliminate those values from the original data List with the RemoveRange method, having the same parameters as the GetRange method we used before
        //Then, we can use the InsertRange method to insert the new rotated list into the beginning of the data list using 0 as the index

        List<int> rotated = new();

        rotated = data.GetRange(data.Count - amount, amount);

        data.RemoveRange(data.Count - amount, amount);

        data.InsertRange(0,rotated);



    }
}
