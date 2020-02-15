﻿namespace FizzBuzz {
    public class FizzBuzzClass {
        private string[] arrayResult;
        public FizzBuzzClass() {
        }

        public string[] GetFizzBuzzArray(int lengthArray) {
            arrayResult = new string[lengthArray];
            for (int count = 0; count < arrayResult.Length; count++) {
                arrayResult[count] = (count+1).ToString();
                if(MultiplyOfThree(count)) arrayResult[count] = "Fizz";
                if(MultiplyOfFive(count)) arrayResult[count] = "Buzz";
            }
            return arrayResult;
        }

        private bool MultiplyOfFive(int count) {
            return (count + 1) % 5 == 0;
        }

        private static bool MultiplyOfThree(int count) {
            return (count + 1) % 3 == 0;
        }
    }
}