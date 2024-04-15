
using System.Text;

namespace ArchivatorUtils.fileUtils;

public class TextFileWriter : IFileWriter
{
    public string WriteDecodedFile(string decodedData, string extention)
    {
        string fileName = "DecodedFile" + extention;

        File.WriteAllText("C:\\Users\\Alaiv\\source\\repos\\Archivator\\Archivator\\" + fileName, decodedData);

        return fileName;
    }

    public string WriteEncodedFile(IEnumerable<string> encodedData, string extention)
    {
        string fileName = "NewFile" + extention;

        var resultString = new StringBuilder();

        foreach (var c in encodedData)
        {
            resultString.Append(c);
            resultString.Append(' ');
        }

        File.WriteAllText("C:\\Users\\Alaiv\\source\\repos\\Archivator\\Archivator\\" + fileName, resultString.ToString().Trim());

        return fileName;
    }
}
