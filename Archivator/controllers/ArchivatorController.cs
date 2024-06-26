﻿using ArchivatorUtils.archivators;
using ArchivatorUtils.fileUtils;

namespace Archivator.controllers;

// TODO - implement other types of archivators and make strategy + factory pattern
public class ArchivatorController
{
    private static IFileReader _fileReader = new TextFileReader();
    private static IFileWriter _fileWriter = new TextFileWriter();
    private static IArchivator _archiver = new VarLengthArchivator();

    public string ZipFile(string filePath, string type)
    {
        var fileData = _fileReader.GetFileDataAsEnumerable(filePath);
        var archivedData = _archiver.Encode(fileData);
        string fileName = _fileWriter.WriteEncodedFile(archivedData, extention: ".varzip");

        return fileName;
    }

    public string UnzipFile(string filePath, string type)
    {
        var fileData = _fileReader.GetFileDataAsEnumerable(filePath, delimeter: " ");
        var archivedData = _archiver.Decode(fileData);
        string fileName = _fileWriter.WriteDecodedFile(archivedData, extention: ".txt");

        return fileName;
    }
}
