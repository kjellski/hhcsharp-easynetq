
using System;
using NUnit.Framework;

namespace EasyNetQTalk.Core.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        [TestCase(0, 0, "II")]
        [TestCase(250, 0, "I")]
        [TestCase(0, 250, "III")]
        [TestCase(250, 250, "IV")]
        public void PointTest(int x, int y, String expectedQuadrant)
        {
            var point = new Point(x, y);
            Assert.That(point.GetQuadrant(), Is.EqualTo(expectedQuadrant));
        }
    }
}