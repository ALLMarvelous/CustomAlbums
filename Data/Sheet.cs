using CustomAlbums.Extensions;

namespace CustomAlbums.Data;

public class Sheet
{
    public string Name { get; }
    public int Difficulty { get; }
    public Album Album { get; }
    public string Md5
    {
        get
        {
            using var stream = Album.File.ReadFile($"map{Difficulty}.bms");
            return stream.ComputeMd5();
        }
    }

    public Sheet(Album album, int difficulty)
    {
        Album = album;
        Difficulty = difficulty;
        Name = $"{album.Name}_map{difficulty}";
    }
}
