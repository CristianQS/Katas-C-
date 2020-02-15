using NUnit.Framework;
using System;

namespace OddTimesNumber {
    [TestFixture]
      public class OddTimesNumberShould {
          [Test]
          public void Tests()
          {
              Assert.AreEqual(5, new OddTimesNumber().find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
          }
      }

}