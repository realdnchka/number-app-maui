namespace NumberApp.Functional;

public class NumGenerator: INumGenerator
{
    private int _resultNumber;
    private List<int> _answerNumbers;
    
    private void GenerateResultNumber()
    {
        _resultNumber = new Random().Next(20, 100);
    }

    private void GenerateAnswerNumbers()
    {
        //Generating amount of numbers, that will be solution for 100%
        var countOfAnswers = new Random().Next(2, 6);
        _answerNumbers = new List<int>();
        
        //TODO Add checking of minRange < maxRange
        for (var i = 0; i < countOfAnswers; i++)
        {
            //Weights are used to reduce the dispersion of the numbers
            var randomWeightMax = new Random().Next(2, 6);
            var randomWeightMin = new Random().Next(1, 10);

            var minRange = 1 * randomWeightMin;
            var maxRange = (_resultNumber - _answerNumbers.Sum()) / randomWeightMax;
            
            //Add a reminder(?) as last number
            if (i != countOfAnswers - 1)
            {
                _answerNumbers.Add(new Random().Next(minRange, maxRange));
            }
            else
            {
                _answerNumbers.Add(_resultNumber - _answerNumbers.Sum());
            }
        }
        
        //Add random numbers in range of result number as decoys :)
        for (var i = countOfAnswers; i < 5; i++)
        {
            _answerNumbers.Add(new Random().Next(1, _resultNumber));
        }
        
        //Shuffle the list
        _answerNumbers = _answerNumbers.OrderBy(a => new Random().Next()).ToList();
        
        //Add a result number as last number
        _answerNumbers.Add(_resultNumber);
    }

    public List<int> GetNumbers()
    {
        GenerateResultNumber();
        GenerateAnswerNumbers();
        return _answerNumbers;
    }
}