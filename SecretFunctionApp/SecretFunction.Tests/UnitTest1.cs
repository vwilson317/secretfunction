using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;

namespace SecretFunction.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        public Func<int, int> SecerctFunction { get; set; }

        [SetUp]
        public void Setup()
        {
            SecerctFunction = Substitute.For<Func<int, int>>();

        }

        [Test]
        public void TestMethod1()
        {
        }
    }
}
