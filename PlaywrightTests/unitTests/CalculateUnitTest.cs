using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace UnitTests;

[TestClass]
public class CalculateUnitTest : PageTest
{
    private Calculator _calculator;

    [TestInitialize]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    #region Addition Tests
    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(1, 1, 2)]
    [DataRow(-1, 1, 0)]
    [DataRow(100, -50, 50)]
    public void Addition(int firstNumber, int secondNumber, int expectedResult)
    {
        var actualResult = _calculator.Add(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }
    #endregion

    #region Subtraction Tests
    [TestMethod]
    [DataRow(10, 5, 5)]
    [DataRow(0, 0, 0)]
    [DataRow(-5, -3, -2)]
    [DataRow(100, 50, 50)]
    [DataRow(-10, 5, -15)]
    public void Subtraction(int firstNumber, int secondNumber, int expectedResult)
    {
        var actualResult = _calculator.Subtract(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }
    #endregion

    #region Multiplication Tests
    [TestMethod]
    [DataRow(5, 3, 15)]
    [DataRow(0, 10, 0)]
    [DataRow(-5, 3, -15)]
    [DataRow(-4, -5, 20)]
    [DataRow(1, 1, 1)]
    public void Multiplication(int firstNumber, int secondNumber, int expectedResult)
    {
        var actualResult = _calculator.Multiply(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }
    #endregion

    #region Division Tests
    [TestMethod]
    [DataRow(10, 2, 5)]
    [DataRow(9, 3, 3)]
    [DataRow(-20, 4, -5)]
    [DataRow(-10, -2, 5)]
    [DataRow(7, 2, 3)] // Integer division
    public void Division(int firstNumber, int secondNumber, int expectedResult)
    {
        var actualResult = _calculator.Divide(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Division_DivideByZero_ThrowsException()
    {
        _calculator.Divide(10, 0);
    }
    #endregion

    #region Decimal Input Tests (from Strings)
    [TestMethod]
    public void AddFromStrings_WithDecimalValues_ReturnsCorrectResult()
    {
        var result = _calculator.AddFromStrings("5.5", "2.3");
        Assert.AreEqual(7.8, result, 0.01);
    }

    [TestMethod]
    public void SubtractFromStrings_WithDecimalValues_ReturnsCorrectResult()
    {
        var result = _calculator.SubtractFromStrings("10.7", "3.2");
        Assert.AreEqual(7.5, result, 0.01);
    }

    [TestMethod]
    public void MultiplyFromStrings_WithDecimalValues_ReturnsCorrectResult()
    {
        var result = _calculator.MultiplyFromStrings("2.5", "4.0");
        Assert.AreEqual(10.0, result, 0.01);
    }

    [TestMethod]
    public void DivideFromStrings_WithDecimalValues_ReturnsCorrectResult()
    {
        var result = _calculator.DivideFromStrings("15.0", "2.5");
        Assert.AreEqual(6.0, result, 0.01);
    }
    #endregion

    #region Non-Numeric (NAN) Input Tests
    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void AddFromStrings_WithNonNumericFirstValue_ThrowsFormatException()
    {
        _calculator.AddFromStrings("abc", "5");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void AddFromStrings_WithNonNumericSecondValue_ThrowsFormatException()
    {
        _calculator.AddFromStrings("5", "xyz");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void SubtractFromStrings_WithNonNumericValue_ThrowsFormatException()
    {
        _calculator.SubtractFromStrings("10", "invalid");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void MultiplyFromStrings_WithNonNumericValue_ThrowsFormatException()
    {
        _calculator.MultiplyFromStrings("text", "5");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void DivideFromStrings_WithNonNumericValue_ThrowsFormatException()
    {
        _calculator.DivideFromStrings("10", "notanumber");
    }
    #endregion

    #region Blank/Null Input Tests
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddFromStrings_WithBlankFirstValue_ThrowsArgumentException()
    {
        _calculator.AddFromStrings("", "5");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddFromStrings_WithBlankSecondValue_ThrowsArgumentException()
    {
        _calculator.AddFromStrings("5", "");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddFromStrings_WithNullFirstValue_ThrowsArgumentException()
    {
        _calculator.AddFromStrings(null, "5");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddFromStrings_WithNullSecondValue_ThrowsArgumentException()
    {
        _calculator.AddFromStrings("5", null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SubtractFromStrings_WithBlankValue_ThrowsArgumentException()
    {
        _calculator.SubtractFromStrings("", "10");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void MultiplyFromStrings_WithWhitespaceValue_ThrowsArgumentException()
    {
        _calculator.MultiplyFromStrings("   ", "5");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DivideFromStrings_WithBlankSecondValue_ThrowsArgumentException()
    {
        _calculator.DivideFromStrings("20", "");
    }
    #endregion

    #region Division by Zero Tests (String Input)
    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void DivideFromStrings_DivideByZero_ThrowsException()
    {
        _calculator.DivideFromStrings("10", "0");
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void DivideFromStrings_DivideByZeroDecimal_ThrowsException()
    {
        _calculator.DivideFromStrings("10.5", "0.0");
    }
    #endregion
}