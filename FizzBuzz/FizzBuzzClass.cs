namespace FizzBuzz {
    public class FizzBuzzClass {
        private string[] arrayResult;
        public FizzBuzzClass() {
        }

        public string[] GetFizzBuzzArray(int lengthArray) {
            arrayResult = new string[lengthArray];
            for (int count = 0; count < arrayResult.Length; count++) {
                arrayResult[count] = (count+1).ToString();
                if((count + 1) % 3 == 0) arrayResult[count] = "Fizz";
            }
            return arrayResult;
        }
    }
}