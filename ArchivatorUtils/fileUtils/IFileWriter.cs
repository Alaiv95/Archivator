namespace ArchivatorUtils.fileUtils;

public interface IFileWriter
{
    public string WriteEncodedFile(IEnumerable<string> encodedData, string extention);

    public string WriteDecodedFile(IEnumerable<char> decodedData, string extention);
}
