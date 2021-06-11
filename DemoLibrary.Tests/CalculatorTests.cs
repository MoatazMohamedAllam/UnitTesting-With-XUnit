using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLibrary.Tests
{
    
    public class CalculatorTests
    {
        [Theory]
        [InlineData(3,3,6)]
        [InlineData(3, 4, 7)]
        public void Add_SimpleValuesShouldCalculate(double x,double y,double expected)
        {
            //Act 
            double actual = Calculator.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(6, 4, 2)]
        public void Subtract_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            //Act 
            double actual = Calculator.Subtract(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(6, 4, 24)]
        public void Multiply_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            //Act 
            double actual = Calculator.Multiply(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }



        [Theory]
        [InlineData(8,4,2)]
        public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            //Act
            double actual = Calculator.Division(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivideByZero()
        {
            //Arrange 
            double expected = 0;

            //Act
            double actual = Calculator.Division(15,0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
