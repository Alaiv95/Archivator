
using System.Text;

namespace ArchivatorUtils.fileUtils;

public class TextFileWriter : IFileWriter
{
    public string WriteDecodedFile(IEnumerable<char> decodedData, string extention)
    {
        throw new NotImplementedException();
    }

    public string WriteEncodedFile(IEnumerable<string> encodedData, string extention)
    {
        string fileName = "NewFile" + extention;

        var resultString = new StringBuilder();

        foreach (var c in encodedData)
        {
            resultString.Append(c);
        }

        File.WriteAllText("C:\\Users\\Alaiv\\source\\repos\\Archivator\\Archivator\\" + fileName, resultString.ToString());

        return fileName;
    }
}
