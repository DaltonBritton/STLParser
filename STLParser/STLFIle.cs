namespace STLParser
{
    public sealed class StlFile
    {
        private readonly byte[] _header = new byte[80];
        public uint NumTriangles { get; }
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
            inputStream.Position = 0;
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
