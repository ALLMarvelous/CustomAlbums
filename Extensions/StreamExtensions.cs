using System.Security.Cryptography;

namespace CustomAlbums.Extensions;

internal static class StreamExtensions
{
    public static MemoryStream ToMemoryStream(this Stream stream)
    {
        var ms = new MemoryStream();
        try
        {
            stream.CopyTo(ms);
            ms.Position = 0; // Reset the position to the beginning of the stream
            return ms;
        }
        catch
        {
            ms.Dispose();
            throw; // Re-throw the exception to handle it upstream
        }
        finally
        {
            stream.Dispose(); // Ensure the original stream is disposed
        }
    }

    public static string ComputeMd5(this Stream stream)
    {
        if (stream is not MemoryStream ms)
        {
            ms = stream.ToMemoryStream();
        }

        var hash = MD5.Create().ComputeHash(ms.ToArray());
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}
