
using System;
using NUnit.Framework;

namespace EasyNetQTalk.Core.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        [TestCase(0, 0, "2")]
        [TestCase(250, 0, "1")]
        [TestCase(0, 250, "3")]
        [TestCase(250, 250, "4")]
        public void PointTest(int x, int y, String expectedQuadrant)
        {
            var point = new Point(x, y);
            Assert.That(point.GetQuadrant(), Is.EqualTo(expectedQuadrant));
        }
    }
}