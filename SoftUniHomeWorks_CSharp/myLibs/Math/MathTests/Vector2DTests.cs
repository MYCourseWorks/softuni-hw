using System;
using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathTests
{
    [TestClass]
    public class Vector2DTests
    {
        [TestMethod]
        public void InitializationTest()
        {
            Vector2D v1 = new Vector2D();
            Vector2D v2 = new Vector2D(1, 2);
            Vector2D v3 = new Vector2D(v1);

            Assert.AreEqual((int)v1.X, 0);
            Assert.AreEqual((int)v1.Y, 0);
            Assert.AreEqual((int)v2.X, 1);
            Assert.AreEqual((int)v2.Y, 2);
            Assert.AreEqual((int)v3.X, 0);
            Assert.AreEqual((int)v3.Y, 0);
        }

        [TestMethod]
        public void AdditionTest() 
        {
            Vector2D v1 = new Vector2D(-1, 1234);
            Vector2D v2 = new Vector2D(101, 0);

            v1.Add(v2);
            Assert.AreEqual((int)v1.X, 100);
            Assert.AreEqual((int)v1.Y, 1234);

            Vector2D v3 = v1 + (new Vector2D(5, 5));
            Assert.AreEqual((int)v1.X, 100); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 1234); // v1.Y remains the same
            Assert.AreEqual((int)v3.X, 105);
            Assert.AreEqual((int)v3.Y, 1239);

            Vector2D v4 = Vector2D.Add(v1, (new Vector2D(5, 5)));
            Assert.AreEqual((int)v1.X, 100); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 1234); // v1.Y remains the same
            Assert.AreEqual((int)v4.X, 105);
            Assert.AreEqual((int)v4.Y, 1239);
        } 

        [TestMethod]
        public void SubtractionTest() 
        {
            Vector2D v1 = new Vector2D(10, 10);
            Vector2D v2 = new Vector2D(10, 10);

            v1.Sub(v2);
            Assert.AreEqual((int)v1.X, 0);
            Assert.AreEqual((int)v1.Y, 0);

            Vector2D v3 = v1 - (new Vector2D(5, 5));
            Assert.AreEqual((int)v1.X, 0); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 0); // v1.Y remains the same
            Assert.AreEqual((int)v3.X, -5);
            Assert.AreEqual((int)v3.Y, -5);

            Vector2D v4 = Vector2D.Sub(v1, (new Vector2D(5, 5)));
            Assert.AreEqual((int)v1.X, 0); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 0); // v1.Y remains the same
            Assert.AreEqual((int)v4.X, -5);
            Assert.AreEqual((int)v4.Y, -5);
        }

        [TestMethod]
        public void ScaleTest() 
        {
            Vector2D v1 = new Vector2D(1, 1);

            v1.Scale(5);
            Assert.AreEqual((int)v1.X, 5);
            Assert.AreEqual((int)v1.Y, 5);

            Vector2D v2 = Vector2D.Scale(v1, 5);
            Assert.AreEqual((int)v1.X, 5); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 5); // v1.Y remains the same
            Assert.AreEqual((int)v2.X, 25);
            Assert.AreEqual((int)v2.Y, 25);

            Vector2D v3 = v1 * 5;
            Assert.AreEqual((int)v1.X, 5); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 5); // v1.Y remains the same
            Assert.AreEqual((int)v3.X, 25);
            Assert.AreEqual((int)v3.Y, 25);

            Vector2D v4 = 5 * v1;
            Assert.AreEqual((int)v1.X, 5); // v1.X remains the same
            Assert.AreEqual((int)v1.Y, 5); // v1.Y remains the same
            Assert.AreEqual((int)v4.X, 25);
            Assert.AreEqual((int)v4.Y, 25);
        }
    }
}
