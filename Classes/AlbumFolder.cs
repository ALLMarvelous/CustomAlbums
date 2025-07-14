using CustomAlbums.Extensions;

namespace CustomAlbums.Classes
{
    internal class AlbumFolder : AlbumFile
    {
        public AlbumFolder(string path) : base(path) { }

        public override MemoryStream ReadFile(string fileName)
        {
            if (!Files.Contains(fileName)) return null;

            var fullPath = Path + "/" + fileName;
            if (!File.Exists(fullPath)) return null;

            return new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read)
                .ToMemoryStream();
        }

        internal override IReadOnlyList<string> GetFiles()
        {
            return Directory.GetFiles(Path, "*", SearchOption.TopDirectoryOnly)
                .ToList()
                .AsReadOnly();
        }
    }
}
