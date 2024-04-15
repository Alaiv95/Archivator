namespace ArchivatorUtils.archivators;

public interface IArchivator
{
    public IEnumerable<string> Encode(IEnumerable<char> fileData);

    public string Decode(IEnumerable<string> encodedData);
}
