namespace LibiadaMusic.Tests
{
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The system data.
    /// </summary>
    public static class SystemData
    {
        /// <summary>
        /// The bin folder path.
        /// </summary>
        public static readonly string BinFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", string.Empty);
    }
}
