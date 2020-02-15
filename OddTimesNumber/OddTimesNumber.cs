using System.Linq;

namespace OddTimesNumber {
    public class OddTimesNumber {
        public OddTimesNumber() {
        }

        public int find_it(int[] seq)
        {
            var result = seq.Where((number) => appearTimes(number, seq) % 2 != 0);
            return result.ToArray()[0];
        }

        public int appearTimes(int numberTarget, int[] seq)
        {
            var numberTargetArray = seq.Where(number => number == numberTarget);
            return numberTargetArray.Count();
        }
    }
}