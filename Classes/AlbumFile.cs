using CustomAlbums.Data;
using System.Text.Json;
using UnityEngine;

namespace CustomAlbums.Classes;

public abstract class AlbumFile
{
    public string Path { get; }
    public IReadOnlyList<string> Files { get; }

    public AlbumInfo Info { get; }
    public Sprite Cover { get; }
    public AudioClip Music { get; }
    public AudioClip Demo { get; }

    public AlbumFile(string path)
    {
        Path = System.IO.Path.TrimEndingDirectorySeparator(path.Replace('\\', '/'));
        Files = GetFiles();

        using var infoStream = ReadFile("info.json");
        Info = JsonSerializer.Deserialize<AlbumInfo>(infoStream)
            ?? throw new InvalidDataException("Invalid or missing info.json in album file.");

        //using var coverStream = ReadFile("cover.png");
        //var coverTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false)
        //{
        //    wrapMode = TextureWrapMode.MirrorOnce
        //};
    }

    public abstract MemoryStream ReadFile(string fileName);
    internal abstract IReadOnlyList<string> GetFiles();
}
