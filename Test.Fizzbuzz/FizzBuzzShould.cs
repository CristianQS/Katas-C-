using System;
using NUnit.Framework;
using FizzBuzz;

namespace Test.Fizzbuzz
{
    [TestFixture]
    public class FizzBuzzShould {
        private FizzBuzzClass fizzBuzz;
        [SetUp]
        public void Setup() {
            fizzBuzz = new FizzBuzzClass();
        }

        [Test]
        public void get_fizz_when_num_is_multiply_of_3() {
            var lengthArray = 3;

            var result = fizzBuzz.GetFizzBuzzArray(lengthArray);
            var expected = new[] {"1", "2", "Fizz"};
            Assert.AreEqual(expected,result);
        }        
        
        [Test]
        public void get_fizz_when_num_is_multiply_of_5() {
            var lengthArray = 10;

            var result = fizzBuzz.GetFizzBuzzArray(lengthArray);

            var expected = new[] {"1", "2", "Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz"};
            Assert.AreEqual(expected,result);
        }
    }
}