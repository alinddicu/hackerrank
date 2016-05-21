


namespace hackerrank
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;
    using System.Collections.Generic;

    [TestClass]
    public class InsertionSortTest
    {
        [TestMethod]
        public void CheckInsertionSort()
        {
            Check.That(new InsertionSort().Sort(new[] { 2, 4, 6, 8, 3 }))
                .ContainsExactly(new[]
                {
                    "2 4 6 8 8", 
                    "2 4 6 6 8",
                    "2 4 4 6 8",
                    "2 3 4 6 8" 
                });
        }
    }

    public class InsertionSort
    {
        public IEnumerable<string> Sort(int[] array)
        {
            var output = new List<string>();

            var length = array.Length;
            var numberToInsert = array[length - 1];
            var position = length - 2;

            while (array[position] > numberToInsert && position >= 0)
            {
                array[position + 1] = array[position];
                position--;
                output.Add(string.Join(" ", array));
            }

            array[position + 1] = numberToInsert;
            output.Add(string.Join(" ", array));

            return output;
        }
    }
}
