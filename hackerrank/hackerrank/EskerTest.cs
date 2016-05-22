namespace hackerrank
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NFluent;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EskerTest
    {
        [TestMethod]
        public void CheckEnvironnemment()
        {
            var enumerable = string.Empty.Select(c => c.ToString());
            // throw new NotImplementedException();
            Check.That(true).IsTrue();
        }
    }
}
