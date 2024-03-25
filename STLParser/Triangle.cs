using System.Numerics;

namespace BaseTypes;

[Serializable]
public struct Triangle
{
    public Vector3 Normal;
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;

    public Triangle(Vector3 p1, Vector3 p2, Vector3 p3) { 
        P1 = p1;
        P2 = p2;
        P3 = p3;
        Normal = Vector3.Normalize(Vector3.Cross(p2 - p1, p3 - p1));
    }

    public Triangle(Vector3 normal, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Normal = normal;
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }
}
