namespace ArchivatorUtils.fileUtils;

public interface IFileWriter
{
    public string WriteEncodedFile(IEnumerable<string> encodedData, string extention);

    public string WriteDecodedFile(string decodedData, string extention);
}
