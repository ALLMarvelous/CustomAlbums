using CustomAlbums.Managers;

namespace CustomAlbums.Extensions;

public static class HelperExtensions
{
    // Avoid new string allocation every time custom UID is checked
    private static readonly string InternalIdStr = $"{AlbumManager.InternalId}";
    
    public static bool IsCustomUid(this string uid) => 
        uid.StartsWith(InternalIdStr);
    
}