namespace ArchivatorUtils.fileUtils;

public class TextFileReader : IFileReader
{
    public IEnumerable<char> GetFileDataAsEnumerable(string path)
    {
        string text = File.ReadAllText(path);

        return PrepareText(text);
    }

    public IEnumerable<string> GetFileDataAsEnumerable(string path, string delimeter)
    {
        string text = File.ReadAllText(path);

        return text.Split(delimeter);
    }

    private IEnumerable<char> PrepareText(string text)
    {
        var res = new List<char>();

        foreach (var item in text)
        {
            if (char.IsUpper(item))
            {
                res.Add('!');
                res.Add(char.ToLower(item));
            } else
            {
                res.Add(item);
            }
        }

        return res;
    }
}
