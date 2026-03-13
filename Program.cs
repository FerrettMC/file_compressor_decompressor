// My first C# project
using TextCopy;
public class Program
{
  public static void Main()
  {
    Console.WriteLine("Compress or decompress? (c, d, r for random string)");
    string? type = Console.ReadLine();
    if (type is null)
    {
      return;
    }
    while (!new[] { "compress", "decompress", "c", "d", "r" }
    .Contains(type, StringComparer.OrdinalIgnoreCase))
    {
      Console.WriteLine("Invalid input. Compress or decompress? (c, d)");
      type = Console.ReadLine();
    }
    if (type is null)
    {
      return;
    }
    type = type.ToLower();
    if (type == "r")
    {
      var randomString = new RandomString();
      randomString.GetRandomString(300); // <--- Change this value for a bigger/smaller random string (a few hundred for best results)
      

    }
    else if (type == "compress" || type == "c")
    {
      var compressor = new Compress();
      compressor.CompressText();
    }
    else
    {
      var decompressor = new Decompress();
      decompressor.DecompressText();
    }
  }
}
