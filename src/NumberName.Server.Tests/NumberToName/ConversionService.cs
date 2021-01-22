using NumberName.Server.NumberToName.Model;
using Xunit;
using SUT = NumberName.Server.NumberToName.Services;

namespace NumberName.Server.Tests.NumberToName
{
    public class ConversionService
    {

        [Fact]
        public void MinValue()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = uint.MinValue;
            var inputInWords = "Zero";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MaxValue()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = uint.MaxValue;
            var inputInWords = "Four billion two hundred ninety four million nine hundred sixty seven thousand two hundred ninety five";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void BillionBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000000000;
            var inputInWords = "One billion";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void BillionPlusSingleDigitBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000000001;
            var inputInWords = "One billion one";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000000;
            var inputInWords = "One million";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusSingleDigitBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000001;
            var inputInWords = "One million one";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusSingleDigitEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000009;
            var inputInWords = "One million nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusDoubleDigitBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000010;
            var inputInWords = "One million ten";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusDoubleDigitEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000099;
            var inputInWords = "One million ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusTripleDigitBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000100;
            var inputInWords = "One million one hundred";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionPlusTripleDigitEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000999;
            var inputInWords = "One million nine hundred ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionAndThousands()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1100999;
            var inputInWords = "One million one hundred thousand nine hundred ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void MillionEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 999999999;
            var inputInWords = "Nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void ThousandBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 1000;
            var inputInWords = "One thousand";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void ThousandAndHundred()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 100100;
            var inputInWords = "One hundred thousand one hundred";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void ThousandEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 999999;
            var inputInWords = "Nine hundred ninety nine thousand nine hundred ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void HundredBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 100;
            var inputInWords = "One hundred";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void HundredAndTen()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 110;
            var inputInWords = "One hundred ten";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void HundredEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 999;
            var inputInWords = "Nine hundred ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void TenBegin()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 10;
            var inputInWords = "Ten";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void TenAndUnit()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 21;
            var inputInWords = "Twenty one";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void TenEnd()
        {
            // Arrange
            var service = new SUT.ConversionService();
            uint inputInNumbers = 99;
            var inputInWords = "Ninety nine";
            var input = new NumberNameInput() { Value = inputInNumbers };

            // Act
            var result = service.ConvertFrom(input);

            // Assert
            Assert.Equal(inputInNumbers, result.Value);
            Assert.Equal(inputInWords, result.ValueInWords);
        }

        [Fact]
        public void TenMultiples()
        {
            // Arrange
            var service = new SUT.ConversionService();

            uint inputInNumbers1 = 10;
            var inputInWords1 = "Ten";
            var input1 = new NumberNameInput() { Value = inputInNumbers1 };

            uint inputInNumbers2 = 20;
            var inputInWords2 = "Twenty";
            var input2 = new NumberNameInput() { Value = inputInNumbers2 };

            uint inputInNumbers3 = 30;
            var inputInWords3 = "Thirty";
            var input3 = new NumberNameInput() { Value = inputInNumbers3 };

            uint inputInNumbers4 = 40;
            var inputInWords4 = "Forty";
            var input4 = new NumberNameInput() { Value = inputInNumbers4 };

            uint inputInNumbers5 = 50;
            var inputInWords5 = "Fifty";
            var input5 = new NumberNameInput() { Value = inputInNumbers5 };

            uint inputInNumbers6 = 60;
            var inputInWords6 = "Sixty";
            var input6 = new NumberNameInput() { Value = inputInNumbers6 };

            uint inputInNumbers7 = 70;
            var inputInWords7 = "Seventy";
            var input7 = new NumberNameInput() { Value = inputInNumbers7 };

            uint inputInNumbers8 = 80;
            var inputInWords8 = "Eighty";
            var input8 = new NumberNameInput() { Value = inputInNumbers8 };

            uint inputInNumbers9 = 90;
            var inputInWords9 = "Ninety";
            var input9 = new NumberNameInput() { Value = inputInNumbers9 };

            // Act
            var result1 = service.ConvertFrom(input1);
            var result2 = service.ConvertFrom(input2);
            var result3 = service.ConvertFrom(input3);
            var result4 = service.ConvertFrom(input4);
            var result5 = service.ConvertFrom(input5);
            var result6 = service.ConvertFrom(input6);
            var result7 = service.ConvertFrom(input7);
            var result8 = service.ConvertFrom(input8);
            var result9 = service.ConvertFrom(input9);

            // Assert
            Assert.Equal(inputInNumbers1, result1.Value);
            Assert.Equal(inputInWords1, result1.ValueInWords);

            Assert.Equal(inputInNumbers2, result2.Value);
            Assert.Equal(inputInWords2, result2.ValueInWords);

            Assert.Equal(inputInNumbers3, result3.Value);
            Assert.Equal(inputInWords3, result3.ValueInWords);

            Assert.Equal(inputInNumbers4, result4.Value);
            Assert.Equal(inputInWords4, result4.ValueInWords);

            Assert.Equal(inputInNumbers5, result5.Value);
            Assert.Equal(inputInWords5, result5.ValueInWords);

            Assert.Equal(inputInNumbers6, result6.Value);
            Assert.Equal(inputInWords6, result6.ValueInWords);

            Assert.Equal(inputInNumbers7, result7.Value);
            Assert.Equal(inputInWords7, result7.ValueInWords);

            Assert.Equal(inputInNumbers8, result8.Value);
            Assert.Equal(inputInWords8, result8.ValueInWords);

            Assert.Equal(inputInNumbers9, result9.Value);
            Assert.Equal(inputInWords9, result9.ValueInWords);
        }

        [Fact]
        public void Teens()
        {
            // Arrange
            var service = new SUT.ConversionService();

            uint inputInNumbers13 = 13;
            var inputInWords13 = "Thirteen";
            var input13 = new NumberNameInput() { Value = inputInNumbers13 };

            uint inputInNumbers14 = 14;
            var inputInWords14 = "Fourteen";
            var input14 = new NumberNameInput() { Value = inputInNumbers14 };

            uint inputInNumbers15 = 15;
            var inputInWords15 = "Fifteen";
            var input15 = new NumberNameInput() { Value = inputInNumbers15 };

            uint inputInNumbers16 = 16;
            var inputInWords16 = "Sixteen";
            var input16 = new NumberNameInput() { Value = inputInNumbers16 };

            uint inputInNumbers17 = 17;
            var inputInWords17 = "Seventeen";
            var input17 = new NumberNameInput() { Value = inputInNumbers17 };

            uint inputInNumbers18 = 18;
            var inputInWords18 = "Eighteen";
            var input18 = new NumberNameInput() { Value = inputInNumbers18 };

            uint inputInNumbers19 = 19;
            var inputInWords19 = "Nineteen";
            var input19 = new NumberNameInput() { Value = inputInNumbers19 };

            // Act
            var result13 = service.ConvertFrom(input13);
            var result14 = service.ConvertFrom(input14);
            var result15 = service.ConvertFrom(input15);
            var result16 = service.ConvertFrom(input16);
            var result17 = service.ConvertFrom(input17);
            var result18 = service.ConvertFrom(input18);
            var result19 = service.ConvertFrom(input19);

            // Assert
            Assert.Equal(inputInNumbers13, result13.Value);
            Assert.Equal(inputInWords13, result13.ValueInWords);

            Assert.Equal(inputInNumbers14, result14.Value);
            Assert.Equal(inputInWords14, result14.ValueInWords);

            Assert.Equal(inputInNumbers15, result15.Value);
            Assert.Equal(inputInWords15, result15.ValueInWords);

            Assert.Equal(inputInNumbers16, result16.Value);
            Assert.Equal(inputInWords16, result16.ValueInWords);

            Assert.Equal(inputInNumbers17, result17.Value);
            Assert.Equal(inputInWords17, result17.ValueInWords);

            Assert.Equal(inputInNumbers18, result18.Value);
            Assert.Equal(inputInWords18, result18.ValueInWords);

            Assert.Equal(inputInNumbers19, result19.Value);
            Assert.Equal(inputInWords19, result19.ValueInWords);
        }

        [Fact]
        public void OneUntilTeens()
        {
            // Arrange
            var service = new SUT.ConversionService();

            uint inputInNumbers1 = 1;
            var inputInWords1 = "One";
            var input1 = new NumberNameInput() { Value = inputInNumbers1 };

            uint inputInNumbers2 = 2;
            var inputInWords2 = "Two";
            var input2 = new NumberNameInput() { Value = inputInNumbers2 };

            uint inputInNumbers3 = 3;
            var inputInWords3 = "Three";
            var input3 = new NumberNameInput() { Value = inputInNumbers3 };

            uint inputInNumbers4 = 4;
            var inputInWords4 = "Four";
            var input4 = new NumberNameInput() { Value = inputInNumbers4 };

            uint inputInNumbers5 = 5;
            var inputInWords5 = "Five";
            var input5 = new NumberNameInput() { Value = inputInNumbers5 };

            uint inputInNumbers6 = 6;
            var inputInWords6 = "Six";
            var input6 = new NumberNameInput() { Value = inputInNumbers6 };

            uint inputInNumbers7 = 7;
            var inputInWords7 = "Seven";
            var input7 = new NumberNameInput() { Value = inputInNumbers7 };

            uint inputInNumbers8 = 8;
            var inputInWords8 = "Eight";
            var input8 = new NumberNameInput() { Value = inputInNumbers8 };

            uint inputInNumbers9 = 9;
            var inputInWords9 = "Nine";
            var input9 = new NumberNameInput() { Value = inputInNumbers9 };

            uint inputInNumbers10 = 10;
            var inputInWords10 = "Ten";
            var input10 = new NumberNameInput() { Value = inputInNumbers10 };

            uint inputInNumbers11 = 11;
            var inputInWords11 = "Eleven";
            var input11 = new NumberNameInput() { Value = inputInNumbers11 };

            uint inputInNumbers12 = 12;
            var inputInWords12 = "Twelve";
            var input12 = new NumberNameInput() { Value = inputInNumbers12 };

            // Act
            var result1 = service.ConvertFrom(input1);
            var result2 = service.ConvertFrom(input2);
            var result3 = service.ConvertFrom(input3);
            var result4 = service.ConvertFrom(input4);
            var result5 = service.ConvertFrom(input5);
            var result6 = service.ConvertFrom(input6);
            var result7 = service.ConvertFrom(input7);
            var result8 = service.ConvertFrom(input8);
            var result9 = service.ConvertFrom(input9);
            var result10 = service.ConvertFrom(input10);
            var result11 = service.ConvertFrom(input11);
            var result12 = service.ConvertFrom(input12);

            // Assert
            Assert.Equal(inputInNumbers1, result1.Value);
            Assert.Equal(inputInWords1, result1.ValueInWords);

            Assert.Equal(inputInNumbers2, result2.Value);
            Assert.Equal(inputInWords2, result2.ValueInWords);

            Assert.Equal(inputInNumbers3, result3.Value);
            Assert.Equal(inputInWords3, result3.ValueInWords);

            Assert.Equal(inputInNumbers4, result4.Value);
            Assert.Equal(inputInWords4, result4.ValueInWords);

            Assert.Equal(inputInNumbers5, result5.Value);
            Assert.Equal(inputInWords5, result5.ValueInWords);

            Assert.Equal(inputInNumbers6, result6.Value);
            Assert.Equal(inputInWords6, result6.ValueInWords);

            Assert.Equal(inputInNumbers7, result7.Value);
            Assert.Equal(inputInWords7, result7.ValueInWords);

            Assert.Equal(inputInNumbers8, result8.Value);
            Assert.Equal(inputInWords8, result8.ValueInWords);

            Assert.Equal(inputInNumbers9, result9.Value);
            Assert.Equal(inputInWords9, result9.ValueInWords);

            Assert.Equal(inputInNumbers10, result10.Value);
            Assert.Equal(inputInWords10, result10.ValueInWords);

            Assert.Equal(inputInNumbers11, result11.Value);
            Assert.Equal(inputInWords11, result11.ValueInWords);

            Assert.Equal(inputInNumbers12, result12.Value);
            Assert.Equal(inputInWords12, result12.ValueInWords);
        }
    }
}