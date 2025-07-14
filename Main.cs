using CustomAlbums.Utilities;
using MelonLoader;

namespace CustomAlbums
{
    public class Main : MelonMod
    {
        internal const string MelonName = "CustomAlbums";
        internal const string MelonVersion = "5.0.0";
        internal const string MelonAuthor = "Two Fellas";

        private readonly Logger _logger = new(MelonName);

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            _logger.Success($"Initialized {MelonName} v{MelonVersion}.");
        }
    }
}
