using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace STLParser.Tests;

[TestClass]
[TestSubject(typeof(StlFile))]
public class StlFileTest
{
    private const string TestInputFilePath = "TestFiles/TestCube.stl";
    private const string TestFileOutputPath = "TestFiles/TestOutputFile.stl";

    [TestCleanup]
    public void CleanUpFiles()
    {
        if(File.Exists(TestFileOutputPath)) 
            File.Delete(TestFileOutputPath);
    }
    
    [TestMethod]
    public void TestReadFile()
    {
        // Read stlFile
        using FileStream fileStream = File.OpenRead(TestInputFilePath);
        StlFile stlFile = new StlFile(fileStream);

        Triangle[] triangles = stlFile.GetTriangles().ToArray();
        List<Triangle> expectedTriangles =
        [
            ..ExpectedTestFileValues.TestCube,
        ];
        
        
        Assert.AreEqual(expectedTriangles.Count, triangles.Length);
        foreach (var triangle in triangles)
        {
            if(!expectedTriangles.Contains(triangle))
                Assert.Fail("Doesn't contain triangle");

            Assert.IsTrue(expectedTriangles.Remove(triangle));
        }
    }

    [TestMethod]
    public void WriteReadTest()
    {
        // Read stlFile
        using FileStream fileStream = File.OpenRead(TestInputFilePath);
        StlFile stlFile1 = new StlFile(fileStream);
        
        // Save a copy of stlFile to Memory
        MemoryStream outputStream = new MemoryStream(new byte[1024]);
        stlFile1.SaveFile(outputStream);

        // Read Saved File
        StlFile stlFile2 = new StlFile(outputStream);
        
        
        List<Triangle> expectedTriangles = stlFile1.GetTriangles().ToList();
        Triangle[] triangles = stlFile2.GetTriangles().ToArray();
        
        Assert.AreEqual(expectedTriangles.Count, triangles.Length);
        foreach (var triangle in triangles)
        {
            if(!expectedTriangles.Contains(triangle))
                Assert.Fail("Doesn't contain triangle");

            Assert.IsTrue(expectedTriangles.Remove(triangle));
        }

    }
    
    
}