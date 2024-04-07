using Archivator.controllers;

namespace Archivator;

internal class Program
{
    private static ArchivatorController _archivatorController = new ArchivatorController();
    private static HashSet<string> archivatorTypes = new HashSet<string>
        {
            "varlen",
        };
    private static HashSet<string> actionTypes = new HashSet<string>
        {
            "encode",
            "decode"
        };

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to simple archivator");

        string? filePath = GetFilePathFromUser();
        string archivatorType = GetUserInput(archivatorTypes, "archivator type (varlen)");
        string actionType = GetUserInput(actionTypes, "action type (decode/encode)");

        // TODO - implement encoding
        string? fileName = actionType == "encode"
            ? _archivatorController.ZipFile(filePath, archivatorType)
            : null;

        Console.WriteLine($"File succesfuly got {actionType}. Its name is {fileName}");
    }

    private static string GetUserInput(HashSet<string> types, string inputType)
    {
        string? userInput;
        bool inputValid;

        do {
            Console.Write("Please enter " + inputType + ": ");
            userInput  = Console.ReadLine();
            inputValid = userInput != null && types.Contains(userInput);
        } while (!inputValid);

        return userInput!;
    }
    private static string GetFilePathFromUser()
    {  
        string? filePath;
        bool isTypeValid;

        do {
            Console.Write("Please enter filepath: ");
            filePath = Console.ReadLine();
            isTypeValid = filePath != null && filePath != string.Empty;
        } while (!isTypeValid);

        ValidateFilePath(filePath!);

        return filePath!;
    }
    private static void ValidateFilePath(string path)
    {
        bool fileExists = File.Exists(path);

        if (!fileExists)
        {
            throw new Exception($"File with given path {path} not found.");
        }
    }
}
