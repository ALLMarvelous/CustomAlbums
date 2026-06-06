using CustomAlbums.Data;
using System.Text.Json;
using UnityEngine;

namespace CustomAlbums.Classes;

public abstract class AlbumFile
{
    public string Path { get; }
    protected IEnumerable<string> Files { get; private set; }

    public AlbumInfo Info { get; private set; }
    public Sprite Cover { get; protected set; }
    public AudioClip Music { get; protected set; }
    public AudioClip Demo { get; protected set; }

    protected AlbumFile(string path)
    {
        Path = System.IO.Path.TrimEndingDirectorySeparator(path);
    }

    protected void Initialize()
    {
        Files = GetFiles();

        using var infoStream = ReadFile("info.json");
        Info = JsonSerializer.Deserialize<AlbumInfo>(infoStream)
               ?? throw new InvalidDataException("Invalid or missing info.json in album file.");
    }

    public abstract MemoryStream ReadFile(string fileName);
    protected abstract IEnumerable<string> GetFiles();
}
