using MelonLoader;
using MelonLoader.Logging;

namespace CustomAlbums.Utilities;

internal class Logger
{
    private readonly MelonLogger.Instance _logger;

    public Logger(string className)
    {
        _logger = new MelonLogger.Instance(className, ColorARGB.FromArgb(255, 0, 255, 150));
    }

    public void Msg(string message)
    {
        _logger.Msg(message);
    }

    public void Success(string message)
    {
        _logger.Msg(ConsoleColor.Green, "Success: " + message);
    }

    public void Warning(string message)
    {
        _logger.Msg(ConsoleColor.Yellow, "Warning: " + message);
    }

    public void Error(string message)
    {
        _logger.Msg(ConsoleColor.Red, "ERROR: " + message);
    }

    public void Failure(string message)
    {
        _logger.Msg(ConsoleColor.Red, "FAILURE: " + message);
    }
}
