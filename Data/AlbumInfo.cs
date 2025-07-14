namespace CustomAlbums.Data;

public class AlbumInfo
{
    public string Name { get; } = string.Empty;
    public string NameRomanized { get; } = string.Empty;
    public string Author { get; } = string.Empty;
    public string LevelDesigner { get; } = string.Empty;
    public string LevelDesigner1 { get; } = string.Empty;
    public string LevelDesigner2 { get; } = string.Empty;
    public string LevelDesigner3 { get; } = string.Empty;
    public string LevelDesigner4 { get; } = string.Empty;
    public string LevelDesigner5 { get; } = string.Empty;
    public string Bpm { get; } = "0";
    public string Scene { get; } = "scene_01";

    public string Difficulty1 { get; } = "0";
    public string Difficulty2 { get; } = "0";
    public string Difficulty3 { get; } = "0";
    public string Difficulty4 { get; } = "0";
    public string Difficulty5 { get; } = "0";

    public Dictionary<int, string> Difficulties
    {
        get
        {
            var dict = new Dictionary<int, string>();
            if (Difficulty1 != "0") dict.Add(1, Difficulty1);
            if (Difficulty2 != "0") dict.Add(2, Difficulty2);
            if (Difficulty3 != "0") dict.Add(3, Difficulty3);
            if (Difficulty4 != "0") dict.Add(4, Difficulty4);
            if (Difficulty5 != "0") dict.Add(5, Difficulty5);
            return dict;
        }
    }

    public string HideBmsMode { get; } = "CLICK";
    public string HideBmsDifficulty { get; } = "0";
    public string HideBmsMessage { get; } = string.Empty;

    public IEnumerable<string> SearchTags { get; } = Array.Empty<string>();
}
