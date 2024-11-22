//var file = new FileInfo(@"MyFiles\test.txt");
FileInfo root = AppDomain.CurrentDomain.BaseDirectory;
var file = root / "MyFiles" / "test.txt";

Console.WriteLine(File.ReadAllText(file.FullName));