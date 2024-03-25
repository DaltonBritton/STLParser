using BaseTypes;
using System.Numerics;

namespace STLParser.Tests;

public static class ExpectedTestFileValues
{
    public readonly static Triangle[] TestCube =
    [
        new Triangle(-Vector3.UnitZ, new(-10, -10, 0), new Vector3(-10, 10, 0), new(10, -10, 0)),
        new Triangle(-Vector3.UnitZ, new(-10, 10, 0), new Vector3(10, 10, 0), new(10, -10, 0)),
        
        new Triangle(Vector3.UnitZ, new(-10, 10, 20), new Vector3(-10, -10, 20), new(10, 10, 20)),
        new Triangle(Vector3.UnitZ, new(-10, -10, 20), new Vector3(10, -10, 20), new(10, 10, 20)),
        
        new Triangle(-Vector3.UnitY, new(10, -10, 20), new Vector3(-10, -10, 20), new(10, -10, 0)),
        new Triangle(-Vector3.UnitY, new(-10, -10, 20), new Vector3(-10, -10, 0), new(10, -10, 0)),
        
        new Triangle(-Vector3.UnitX, new(-10, -10, 20), new Vector3(-10, 10, 20), new(-10, -10, 0)),
        new Triangle(-Vector3.UnitX, new(-10, 10, 20), new Vector3(-10, 10, 0), new(-10, -10, 0)),
        
        new Triangle(Vector3.UnitX, new(10, 10, 20), new Vector3(10, -10, 20), new(10, 10, 0)),
        new Triangle(Vector3.UnitX, new(10, -10, 20), new Vector3(10, -10, 0), new(10, 10, 0)),
        
        new Triangle(Vector3.UnitY, new(-10, 10, 20), new Vector3(10, 10, 20), new(-10, 10, 0)),
        new Triangle(Vector3.UnitY, new(10, 10, 20), new Vector3(10, 10, 0), new(-10, 10, 0)),
        
        
    ];
}
