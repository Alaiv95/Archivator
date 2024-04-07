namespace ArchivatorUtils.archivators;

public interface IArchivator
{
    public IEnumerable<string> Encode(IEnumerable<char> fileData);

    public IEnumerable<char> Decode(IEnumerable<string> encodedData);
}
