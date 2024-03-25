using BaseTypes;
using System.Numerics;

namespace STLParser;

internal static class TriangleExtensions
{
    public static Triangle ParseBinary(BinaryReader reader)
    {
        Vector3 normal = ParseVector3(reader);
        Vector3 p1 = ParseVector3(reader);
        Vector3 p2 = ParseVector3(reader);
        Vector3 p3 = ParseVector3(reader);

        // Read Triangle ID (Ignored)
        reader.ReadUInt16();

        return new Triangle(normal, p1, p2, p3);
    }

    private static Vector3 ParseVector3(BinaryReader reader)
    {
        float x = reader.ReadSingle();
        float y = reader.ReadSingle();
        float z = reader.ReadSingle();

        return new Vector3(x, y, z);
    }

    private static void BinaryWriteVector3(BinaryWriter writer, Vector3 vector3)
    {
        writer.Write(vector3.X);
        writer.Write(vector3.Y);
        writer.Write(vector3.Z);
    }

    public static void BinaryWrite(this Triangle triangle, BinaryWriter writer)
    {
        BinaryWriteVector3(writer, triangle.Normal);
        BinaryWriteVector3(writer, triangle.P1);
        BinaryWriteVector3(writer, triangle.P2);
        BinaryWriteVector3(writer, triangle.P3);

        writer.Write((ushort) 0);
    }
        
        
}