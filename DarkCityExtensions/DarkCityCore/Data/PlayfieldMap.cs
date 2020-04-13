using System;

namespace DarkCity.Data
{
    public class PlayfieldMap
    {
        // A few pre-calculated lookups to use when translating between map and playfield coordinates.
        private static readonly int[] classWidthSize = new int[] { 0, 2000, 4000, 8000, 16000, 32000, 64000 };
        private static readonly int[] classHeightSize = new int[] { 0, 1000, 2000, 4000, 8000, 16000, 32000 };
        private static readonly int[] classWidthOffset = new int[] { 0, 1000, 2000, 4000, 8000, 16000, 32000 };
        private static readonly int[] classHeightOffset = new int[] { 0, 500, 1000, 2000, 4000, 8000, 16000 };

        /// <summary>
        /// The name of the playfield.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Size class of the playfield. Each class has the following coordinate bounds.
        ///   2 -> X: ( -4000,  4000) Z: (-2000, 2000)
        ///   3 -> X: ( -8000,  8000) Z: (-4000, 4000)
        ///   4 -> X: (-16000, 16000) Z: (-8000, 8000)
        /// </summary>
        public int SizeClass { get; set; }

        /// <summary>
        /// Resolution of the map. This number is the divisor of the playfield coordinates to get map coordinates. A higher resolution number results in
        /// a smaller height map. A resolution of 1 result in a 1:1 height map. A resolution of 5 results in a 1:5 height map,
        /// where 1 unit on the map is 5 units on the playfield. This resolution applies to all axis.
        /// </summary>
        public float Resolution { get; set; }

        /// <summary>
        /// A 2-dimensional array of the playfield's terrain. First index is the x coordinate and second index is the z coordinate.
        /// The value is the y coordinate of the natural terrain height in map coordinates. This does not take into account modifications to the terrain.
        /// Translate the return value to playfield coordinates by multiplying by <see cref="Resolution"/>.
        /// </summary>
        public float[,] HeightMap { get; set; }

        /// <summary>
        /// Size of the height map along the x-axis in map coordinates.
        /// </summary>
        public int MapWidth
        {
            get { return this.HeightMap?.GetLength(0) ?? 0; }
        }

        /// <summary>
        /// Size of the height map along the z-axis in map coordinates.
        /// </summary>
        public int MapHeight
        {
            get { return this.HeightMap?.GetLength(1) ?? 0; }
        }

        /// <summary>
        /// Gets the width of the playfield based on its size class.
        /// </summary>
        public int PlayfieldWidth
        {
            get { return classWidthSize[this.SizeClass]; }
        }

        /// <summary>
        /// Gets the height of the playfield based on its size class.
        /// </summary>
        public int PlayfieldHeight
        {
            get { return classHeightSize[this.SizeClass]; }
        }

        /// <summary>
        /// Gets the terrain height at a specific map coordinate. This height is in map coordinates; multiply by <see cref="Resolution"/> to get playfield coordinates.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <returns>Terrain height at the given coordinate.</returns>
        public float this[int x, int z]
        {
            get { return this.HeightMap[x, z]; }
            set { this.HeightMap[x, z] = value; }
        }

        /// <summary>
        /// Gets the terrain height at a specific map coordinate. This height is in map coordinates; multiply by <see cref="Resolution"/> to get playfield coordinates.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <returns>Terrain height at the given coordinate.</returns>
        public float this[float x, float z]
        {
            get { return this.HeightMap[(int)x, (int)z]; }
            set { this.HeightMap[(int)x, (int)z] = value; }
        }

        public PlayfieldMap() { }

        public PlayfieldMap(string Name, int Width, int Height)
        {
            this.Name = Name;
            this.HeightMap = new float[Width, Height];
        }

        /// <summary>
        /// Translates a position from playfield coordinates to map coordinates.
        /// </summary>
        /// <param name="position">Playfield coordinates.</param>
        /// <returns>Map coordinates.</returns>
        public Vector3 PlayfieldToMap(Vector3 position)
        {
            return new Vector3(
                (position.x + classWidthOffset[this.SizeClass]) / this.Resolution,
                position.y / this.Resolution,
                (position.z + classHeightOffset[this.SizeClass]) / this.Resolution);
        }

        /// <summary>
        /// Translates a position from map coordinates to playfield coordinates.
        /// </summary>
        /// <param name="position">Map coordinates.</param>
        /// <returns>Playfield coordinates.</returns>
        public Vector3 MapToPlayfield(Vector3 position)
        {
            return new Vector3(
                (position.x * this.Resolution) - classWidthOffset[this.SizeClass],
                position.y * this.Resolution,
                (position.z * this.Resolution) - classHeightOffset[this.SizeClass]);
        }

        public override string ToString()
        {
            return $"{Name} ({MapWidth}x{MapHeight})";
        }
    }
}
