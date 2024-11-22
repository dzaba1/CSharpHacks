namespace System.IO;

class FileInfo(string current)
{
    public string FullName { get; } = current;

    public static implicit operator FileInfo(string s) => new FileInfo(s);

    public static FileInfo operator /(FileInfo prev, string next)
    {
        return new FileInfo(Path.Combine(prev.FullName, next));
    }
}
