using System;

namespace hackerrank
{
    using System.Collections.Generic;
    using System.Linq;

    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SherlockAndTheBeastTests
    {
        [TestMethod]
        public void CheckSherlockAndTheBeast()
        {
            Check.That(new SherlockAndTheBeast().GetDecentNumber(1)).IsEqualTo(-1);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(2)).IsEqualTo(-1);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(3)).IsEqualTo(555);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(4)).IsEqualTo(-1);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(5)).IsEqualTo(33333);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(6)).IsEqualTo(555555);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(7)).IsEqualTo(-1);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(8)).IsEqualTo(55533333);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(9)).IsEqualTo(555555555);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(10)).IsEqualTo(3333333333);
            Check.That(new SherlockAndTheBeast().GetDecentNumber(11)).IsEqualTo(55555533333);
        }
    }

    public class SherlockAndTheBeast
    {
        public long GetDecentNumber(int digitsNumber)
        {
            try
            {
                var candidates = new List<string>
                {
                    GetStartingWith5(digitsNumber),
                    GetStartingWith3(digitsNumber)
                };

                return candidates.Select(long.Parse).Max();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static string GetStartingWith5(int digitsNumber)
        {
            var numberOf5S = digitsNumber;
            var numbersOf3S = 0;

            while (numberOf5S % 3 != 0 || numbersOf3S % 5 != 0)
            {
                numberOf5S--;
                numbersOf3S++;
            }

            return string.Empty.PadRight(numberOf5S, '5').PadRight(digitsNumber, '3');
        }

        private static string GetStartingWith3(int digitsNumber)
        {
            var numbersOf3S = digitsNumber;
            var numberOf5S = 0;

            while (numberOf5S % 3 != 0 || numbersOf3S % 5 != 0)
            {
                numberOf5S++;
                numbersOf3S--;
            }

            return string.Empty.PadRight(numbersOf3S, '3').PadRight(digitsNumber, '5');
        }
    }
}
