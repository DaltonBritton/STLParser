namespace STLParser
{
    /// <summary>
    /// provides functionality for parsing STL (stereolithography) files, supporting binary formats.
    /// It includes methods for reading and writing STL files, enabling seamless integration into your C# projects.
    /// </summary>
    public sealed class StlFile
    {
        private readonly byte[] _header = new byte[80];

        /// <summary>
        /// The number of triangles created in the file.
        /// </summary>
        public readonly uint NumTriangles;
        
        private readonly Triangle[] _triangles;

        /// <summary>
        /// Reads an STL File from an input stream.
        /// <para>
        ///     Important: Stream will be closed after executing this method.
        /// </para>
        /// </summary>
        /// <param name="inputStream"></param>
        /// <exception cref="ArgumentException">Thrown in the event the contents of the <paramref name="inputStream"/> could not be read.</exception>
        public StlFile(Stream inputStream)
        {
            using BinaryReader reader = new(inputStream);
            
            // Read Header
            int read = reader.Read(_header, 0, _header.Length);
            if (read != _header.Length)
                throw new ArgumentException("Unable to read File Header");

            // Get Num Triangles
            NumTriangles = reader.ReadUInt32();
            _triangles = new Triangle[NumTriangles];

            for (int i = 0; i < NumTriangles; i++)
            {
                _triangles[i] = TriangleExtensions.ParseBinary(reader);
            }
        }

        /// <summary>
        /// Constructs an STL File from a list of <see cref="Triangle">Triangles</see>
        /// </summary>
        /// <param name="triangles">A List of triangles included within the STL File</param>
        public StlFile(IEnumerable<Triangle> triangles)
        {
            _triangles = triangles.ToArray();
            NumTriangles = (uint) _triangles.Length;
        }

        /// <summary>
        /// Saves the STLFile to an <paramref name="outputStream"/>
        /// </summary>
        /// <param name="outputStream">The stream to save the STLFile to.</param>
        public void SaveFile(Stream outputStream)
        {
            BinaryWriter writer = new(outputStream);
            
            // Write Header
            writer.Write(_header);
            
            // WriteTriangles
            writer.Write((uint) _triangles.Length);
            foreach (var triangle in _triangles)
            {
                triangle.BinaryWrite(writer);
            }
            
            
        }
        
        /// <summary>
        /// Gets an iterator for all triangles within the STL File
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Triangle> GetTriangles()
        {
            return _triangles;
        }
    }
}
