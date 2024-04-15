using ArchivatorUtils.constants;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchivatorUtils.archivators;

public class VarLengthArchivator : IArchivator
{
    public string Decode(IEnumerable<string> encodedData)
    {
        var decodingTable = Constants.DecodingTable;

        var binaryData = ConvertListOfHexToBinary(encodedData);
        var result = ConvertBinaryToText(decodingTable, binaryData);

        return NormalizeText(result.ToString());
    }

    private string ConvertBinaryToText(Dictionary<string, char> decodingTable, IEnumerable<string> binaryData)
    {
        var binaryString = string.Join("", binaryData);

        var builder = new StringBuilder();
        var result = new StringBuilder();

        foreach (var value in binaryString)
        {
            builder.Append(value);
            bool isFullValue = decodingTable.TryGetValue(builder.ToString(), out var fullValue);

            if (isFullValue)
            {
                result.Append(fullValue);
                builder.Clear();
            }
        }

        return result.ToString();
    }

    private string NormalizeText(string text)
    {
        if (text is null)
        {
            throw new Exception("Input string was empty");
        }

        string pattern = @"!(\S)";
        string normalized = Regex.Replace(text, pattern, m => m.Groups[1].Value.ToUpper());

        return normalized;
    }

    private IEnumerable<string> ConvertListOfHexToBinary(IEnumerable<string> encodedData)
    {
        var res = new List<string>();

        foreach ( var c in encodedData)
        {
            var val = string.Concat(c.Select(c =>
            {
                return Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
            }));

            res.Add(val);
        }

        return res;
    }


    public IEnumerable<string> Encode(IEnumerable<char> fileData)
    {
        var charCodes = Constants.EncodingTable;
        var data = fileData.Select(d => charCodes[d]);

        if (!data.Any())
        {
            return Enumerable.Empty<string>();
        }

        var encodedString = string.Join("", data);
        var chunkedString = ChunkString(encodedString, 8);
        var hexData = ConvertListOfBinaryToHex(chunkedString);

        return hexData;
    }

    private IEnumerable<string> ChunkString(string encodedString, int chunkLength)
    {
        var chunkedString = encodedString.Chunk(chunkLength).Select(c =>
        {
            var chunkAsString = new string(c);
            var res = chunkAsString;

            if (chunkAsString.Length < chunkLength)
            {
                var extraZeroes = new string('0', chunkLength - chunkAsString.Length);
                res += extraZeroes;
            }

            return res;
        });

        return chunkedString;
    }

    private IEnumerable<string> ConvertListOfBinaryToHex(IEnumerable<string> chunkedString)
    {
        if (chunkedString is null)
        {
            return Enumerable.Empty<string>();
        }

        return chunkedString.Select(BinaryToHex);
    }

    private string BinaryToHex(string binaryString)
    {
        string hex = Convert.ToInt32(binaryString, 2).ToString("X");

        return hex;
    }
}
