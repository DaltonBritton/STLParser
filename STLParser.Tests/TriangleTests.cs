using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement

namespace STLParser.Tests;

[TestClass]
public class TriangleTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidNormal1()
    {
        new Triangle(new(1, 0, 0), new(0, 0, 0), new(1, 0, 0), new(1, 1, 0));
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidNormal2()
    {
        new Triangle(new(0, 0, 5), new(0, 0, 0), new(1, 0, 0), new(1, 1, 0));
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestDuplicatePoint1()
    {
        new Triangle(new(0, 0, 0), new(0, 0, 0), new(1, 1, 0));
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestDuplicatePoint2()
    {
        new Triangle(new(0, 0, 5),new(0, 0, 0), new(0, 0, 0), new(1, 1, 0));
    }
}