﻿namespace ArchivatorUtils.fileUtils;

public interface IFileReader
{
    public IEnumerable<char> GetFileDataAsEnumerable(string path);

    public IEnumerable<string> GetFileDataAsEnumerable(string path, string delimeter);
}
