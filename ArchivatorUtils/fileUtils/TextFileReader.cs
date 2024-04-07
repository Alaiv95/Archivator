namespace ArchivatorUtils.fileUtils;

public class TextFileReader : IFileReader
{
    public IEnumerable<char> GetFileDataAsEnumerable(string path)
    {
        string text = File.ReadAllText(path);
        var exploded = text.ToCharArray();

        IEnumerable<char> res = new List<char>(exploded);

        return res;
    }
}
