namespace UnitTests;

public class CoreLogic
{
    [Fact]
    public void OutputWithSixNumbers()
    {
        var numGenerator = new NumGenerator();
        Assert.True(numGenerator.GetNumbers().Count == 6);
    }

    [Fact]
    public void OutputContainSum()
    {
        var numGenerator = new NumGenerator();
        var result = numGenerator.GetNumbers();
        var suggestedNumbers = new List<int>();
        var sum = result.Last();
        result.RemoveAt(5);
        var isContain = false;
        
        foreach (var r in result)
        {
            suggestedNumbers.Add(r);
        }

        //If any combination of the sum of the numbers in the 'suggestedNumbers' list equals the variable 'sum', change 'isContains' to 'true'
        CheckCombination(suggestedNumbers, 0, sum, ref isContain);
        
        Assert.True(isContain);
    }
    
    private void CheckCombination(List<int> numbers, int index, int remainingSum, ref bool isContains)
    {
        // If remainingSum is 0, a valid combination is found
        if (remainingSum == 0)
        {
            isContains = true;
            return;
        }

        // If remainingSum is negative or all numbers are processed, return
        if (remainingSum < 0 || index >= numbers.Count)
        {
            return;
        }

        // Include the current number in the combination and recursively check the rest of the numbers
        CheckCombination(numbers, index + 1, remainingSum - numbers[index], ref isContains);

        // Exclude the current number from the combination and recursively check the rest of the numbers
        CheckCombination(numbers, index + 1, remainingSum, ref isContains);
    }
}