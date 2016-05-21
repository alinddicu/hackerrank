using NFluent;

namespace hackerrank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoveLetterMysteryTests
    {
        [TestMethod]
        public void LoveLetterMysteryTest()
        {
            Check.That(new LoveLetterMystery().CountReduces("abc")).ContainsExactly(new[] { 2 });
            Check.That(new LoveLetterMystery().CountReduces("abcba")).ContainsExactly(new[] { 0 });
            Check.That(new LoveLetterMystery().CountReduces("abcd")).ContainsExactly(new[] { 4 });
            Check.That(new LoveLetterMystery().CountReduces("cba")).ContainsExactly(new[] { 2 });
        }

        private class LoveLetterMystery
        {
            public IEnumerable<int> CountReduces(params string[] words)
            {
                foreach (var word in words)
                {
                    var lettersOfWord = word.ToCharArray().Select(c => c.ToString()).ToArray();
                    var wordLength = lettersOfWord.Length;
                    var symetricsOfWord = new List<SymetricPair>();
                    for (var i = 0; i < wordLength; i++)
                    {
                        var left = lettersOfWord[i];
                        var right = lettersOfWord[wordLength - 1 - i];
                        symetricsOfWord.Add(new SymetricPair(left, right));
                    }

                    yield return symetricsOfWord.Sum(s => s.GetReduceCount()) / 2;
                }
            }
        }

        private class SymetricPair
        {
            private static readonly string[] Letters = new[]
            {
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
            };

            private readonly string _left;
            private readonly string _right;

            public SymetricPair(string left, string right)
            {
                _left = left;
                _right = right;
            }

            public int GetReduceCount()
            {
                return Math.Abs(GetIndexOfLetter(_left) - GetIndexOfLetter(_right));
            }

            private static int GetIndexOfLetter(string letter)
            {
                return Letters.Select((l, index) => new { l, index }).Single(o => o.l == letter).index;
            }
        }
    }
}
