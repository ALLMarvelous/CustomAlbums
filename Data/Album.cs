using CustomAlbums.Classes;
using CustomAlbums.Managers;

namespace CustomAlbums.Data;

public class Album
{
    public const string NamePrefix = "album_";

    public int Index { get; }
    public string Name { get; }
    public AlbumFile File { get; }

    public Album(AlbumFile file)
    {
        Index = AlbumManager.LoadedAlbums.Count + 1;
        File = file;
        Name = NamePrefix + Path.GetFileNameWithoutExtension(file.Path);
    }
}
