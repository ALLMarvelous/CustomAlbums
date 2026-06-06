using CustomAlbums.Extensions;

namespace CustomAlbums.Classes
{
    internal class AlbumFolder : AlbumFile
    {
        public AlbumFolder(string path) : base(path)
        {
            Initialize();
        }

        public override MemoryStream ReadFile(string fileName)
        {
            if (!Files.Contains(fileName)) return null;

            var fullPath = System.IO.Path.Combine(Path, fileName);
            if (!File.Exists(fullPath)) return null;

            return new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                .ToMemoryStream();
        }

        protected override IEnumerable<string> GetFiles() =>
            Directory.GetFiles(Path, "*", SearchOption.TopDirectoryOnly);
    }
}
