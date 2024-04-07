using ArchivatorUtils.constants;

namespace ArchivatorUtils.archivators;

public class VarLengthArchivator : IArchivator
{
    public IEnumerable<char> Decode(IEnumerable<string> encodedData)
    {
        throw new NotImplementedException();
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

        return chunkedString.Select(s => BinaryToHex(s));
    }

    private string BinaryToHex(string binaryString)
    {
        string hex = Convert.ToInt32(binaryString, 2).ToString("X");

        return hex;
    }
}
