using CustomAlbums.Classes;
using CustomAlbums.Data;
using CustomAlbums.Utilities;

namespace CustomAlbums.Managers;

public static class AlbumManager
{
    public const int InternalId = 999;
    public const string SearchPath = "Custom_Albums";
    public const string SearchPattern = "*.mdm";

    public static Dictionary<string, Album> LoadedAlbums { get; } = new();
    private static readonly Logger _logger = new(nameof(AlbumManager));

    public static void LoadAlbums()
    {
        LoadedAlbums.Clear();

        var archives = Directory.GetFiles(SearchPath, SearchPattern);
        var folders = Directory.GetDirectories(SearchPath, "*");

        foreach (var archive in archives)
        {
            LoadAlbumArchive(archive);
        }

        foreach (var folder in folders)
        {
            LoadAlbumFolder(folder);
        }

        _logger.Success($"Loaded {LoadedAlbums.Count} albums from {SearchPath}.");
    }

    public static void LoadAlbumArchive(string path)
    {
        var fileName = Path.GetFileNameWithoutExtension(path);
        if (LoadedAlbums.ContainsKey(fileName))
        {
            _logger.Warning($"Key '{fileName}' present in LoadedAlbums, skipping load for {fileName}.");
        }

        var albumFile = new AlbumArchive(path);
        if (albumFile.Info == null)
        {
            _logger.Warning($"Album archive '{fileName}' has no valid info, skipping load.");
        }

        var album = new Album(albumFile);

        LoadedAlbums.Add($"{InternalId}-{album.Index}", album);
    }

    public static void LoadAlbumFolder(string path)
    {
        var folderName = Path.GetFileName(path);
        if (LoadedAlbums.ContainsKey(folderName))
        {
            _logger.Warning($"Key '{folderName}' present in LoadedAlbums, skipping load for {folderName}.");
            return;
        }

        var albumFile = new AlbumFolder(path);
        if (albumFile.Info == null)
        {
            _logger.Warning($"Album folder '{folderName}' has no valid info, skipping load.");
            return;
        }

        var album = new Album(albumFile);

        LoadedAlbums.Add($"{InternalId}-{album.Index}", album);
    }
}
