namespace ArchivatorUtils.fileUtils;

public interface IFileReader
{
    public IEnumerable<char> GetFileDataAsEnumerable(string path);
}
