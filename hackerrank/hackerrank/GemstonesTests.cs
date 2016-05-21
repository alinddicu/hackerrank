using System.Linq;
using NFluent;

namespace hackerrank
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GemstonesTests
    {
        [TestMethod]
        public void CheckGemStones()
        {
            var gemElementsCount = new Gemstones().CountGemElements("abcdde","baccd","eeabg");

            Check.That(gemElementsCount).IsEqualTo(2);
        }
    }

    public class Gemstones
    {
        public int CountGemElements(params string[] rocks)
        {
            var rocksWithReducedElements = rocks.
                Select(
                    rock =>
                        string.Join(string.Empty,
                            rock.ToCharArray().Distinct().OrderBy(s => s)))
                            .ToArray();

            var minimumGemElementsCount = rocksWithReducedElements.Min(r => r.Length);
            var minimumGemElementsCandidates = rocksWithReducedElements.First(r => r.Length == minimumGemElementsCount);

            var count = 0;
            foreach (var candidate in minimumGemElementsCandidates)
            {
                if (rocksWithReducedElements.All(r => r.Contains(candidate)))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
