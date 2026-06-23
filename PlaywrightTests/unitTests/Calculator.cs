namespace UnitTests;

public class Calculator
{
    public int Add(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public int Subtract(int firstNumber, int secondNumber)
    {
        return firstNumber - secondNumber;
    }

    public int Multiply(int firstNumber, int secondNumber)
    {
        return firstNumber * secondNumber;
    }

    public int Divide(int firstNumber, int secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return firstNumber / secondNumber;
    }

    public double AddFromStrings(string firstNumber, string secondNumber)
    {
        ValidateAndParseInput(firstNumber);
        ValidateAndParseInput(secondNumber);
        return double.Parse(firstNumber) + double.Parse(secondNumber);
    }

    public double SubtractFromStrings(string firstNumber, string secondNumber)
    {
        ValidateAndParseInput(firstNumber);
        ValidateAndParseInput(secondNumber);
        return double.Parse(firstNumber) - double.Parse(secondNumber);
    }

    public double MultiplyFromStrings(string firstNumber, string secondNumber)
    {
        ValidateAndParseInput(firstNumber);
        ValidateAndParseInput(secondNumber);
        return double.Parse(firstNumber) * double.Parse(secondNumber);
    }

    public double DivideFromStrings(string firstNumber, string secondNumber)
    {
        ValidateAndParseInput(firstNumber);
        ValidateAndParseInput(secondNumber);
        
        double divisor = double.Parse(secondNumber);
        if (divisor == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return double.Parse(firstNumber) / divisor;
    }

    private void ValidateAndParseInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be null or empty", nameof(input));
        }

        if (!double.TryParse(input, out _))
        {
            throw new FormatException($"Input '{input}' is not a valid numeric value");
        }
    }
}
