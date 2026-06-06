using CustomAlbums.Extensions;
using System.IO.Compression;

namespace CustomAlbums.Classes;

internal class AlbumArchive : AlbumFile
{
    public AlbumArchive(string path) : base(path)
    {
        Initialize();
    }

    public override MemoryStream ReadFile(string fileName)
    {
        if (!Files.Contains(fileName)) return null;

        using var zip = ZipFile.OpenRead(Path);
        var entry = zip.GetEntry(fileName);

        return entry?.Open().ToMemoryStream();
    }

    protected override IEnumerable<string> GetFiles()
    {
        using var zip = ZipFile.OpenRead(Path);
        return zip.Entries.Select(e => e.FullName);
    }
}
