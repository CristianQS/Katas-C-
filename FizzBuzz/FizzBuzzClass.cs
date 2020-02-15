namespace FizzBuzz {
    public class FizzBuzzClass {
        private string[] fizzBuzzArray;
        public FizzBuzzClass() {
        }

        public string[] GetFizzBuzzArray(int lengthArray) {
            fizzBuzzArray = new string[lengthArray];
            for (int count = 0; count < fizzBuzzArray.Length; count++) {
                fizzBuzzArray[count] = (count+1).ToString();
                if(MultiplyOfThree(count)) fizzBuzzArray[count] = "Fizz";
                if(MultiplyOfFive(count)) fizzBuzzArray[count] = "Buzz";
                if(MultiplyOfFifteen(count)) fizzBuzzArray[count] = "FizzBuzz";
            }
            return fizzBuzzArray;
        }

        private bool MultiplyOfFifteen(in int count) {
            return (count + 1) % 15 == 0;
        }

        private bool MultiplyOfFive(int count) {
            return (count + 1) % 5 == 0;
        }

        private static bool MultiplyOfThree(int count) {
            return (count + 1) % 3 == 0;
        }
    }
}