using System.Numerics;

namespace STLParser;


/// <summary>
/// A class representing a Triangle in 3D space.
/// </summary>
public struct Triangle
{
    /// <summary>
    /// The Normal Direction of the triangle
    /// </summary>
    public Vector3 Normal;
    
    /// <summary>
    /// The first point of the triangle.
    /// </summary>
    public Vector3 P1;
    
    /// <summary>
    /// The second point of the triangle.
    /// </summary>
    public Vector3 P2;
    
    /// <summary>
    /// The third point of the triangle.
    /// </summary>
    public Vector3 P3;

    
    /// <summary>
    /// Creates a Triangle, Generates a valid Normal for the given points
    /// </summary>
    /// <param name="p1">The first point within the triangle</param>
    /// <param name="p2">The second point within the triangle</param>
    /// <param name="p3">The third point within the triangle</param>
    /// <exception cref="ArgumentException">Thrown in the case there is at least one duplicate point within the triangle.</exception>
    public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        if (p1 == p2 || p1 == p3 || p2 == p3)
            throw new ArgumentException("Triangles cannot have duplicate points.");
        
        P1 = p1;
        P2 = p2;
        P3 = p3;
        Normal = GenerateValidNormal(p1, p2, p3);
    }

    /// <summary>
    /// Creates a Triangle
    /// </summary>
    /// <param name="normal">The normal of the triangle, must be valid given the points <paramref name="p1"/>, <paramref name="p2"/>, <paramref name="p3"/></param>
    /// <param name="p1">The first point within the triangle</param>
    /// <param name="p2">The second point within the triangle</param>
    /// <param name="p3">The third point within the triangle</param>
    /// <exception cref="ArgumentException">Thrown in the case there is at least one duplicate point within the triangle.</exception>
    /// <exception cref="ArgumentException">Thrown in the case the provided normal is invalid.</exception>
    public Triangle(Vector3 normal, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        if (p1 == p2 || p1 == p3 || p2 == p3)
            throw new ArgumentException("Triangles cannot have duplicate points.");
        
        Vector3 validNormalDirection = GenerateValidNormal(p1, p2, p3);
        if(normal != validNormalDirection && normal !=-validNormalDirection)
            throw new ArgumentException($"Invalid normal provided. Expected {validNormalDirection} or {-validNormalDirection}, got {normal}.");
        
        P1 = p1;
        P2 = p2;
        P3 = p3;

        Normal = normal;

    }

    private Vector3 GenerateValidNormal(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        return Vector3.Normalize(Vector3.Cross(p2 - p1, p3 - p1));
    }
}
