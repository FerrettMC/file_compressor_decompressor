

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Compress or decompress?");
    string? type = Console.ReadLine();
    if (type is null)
    {
      return;
    }
    while (!new[] { "compress", "decompress" }
    .Contains(type, StringComparer.OrdinalIgnoreCase))
    {
      Console.WriteLine("Invalid type, try again:");
      type = Console.ReadLine();
    }
    if (type is null)
    {
      return;
    }
    if (type.ToLower() == "compress")
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


public class Compress
{
  public void CompressText()
  {
    Console.WriteLine("Enter what you want compressed!!");
    string? decompressed = Console.ReadLine();
    if (decompressed is null || decompressed.All(char.IsLetter) == false)
    {
      Console.WriteLine("Invalid entry!");
      return;
    }
    List<string> compressed = [];
    int appearances = 1;
    for (int i = 0; i < decompressed.Length; i++)
    {
      char letter = decompressed[i];
      bool isLast = i == decompressed.Length - 1;

      if (!isLast && letter == decompressed[i + 1])
      {
        appearances++;
      }
      else
      {
        compressed.Add($"{appearances}{letter}");
        appearances = 1;
      }
    }
    string result = string.Join("", compressed);
    Console.WriteLine(result);
  }
}

public class Decompress
{
  public void DecompressText()
  {
    Console.WriteLine("Enter what you want decompressed!!");
    string? compressed = Console.ReadLine();
    if (compressed is null || compressed.All(char.IsLetter) == false)
    {
      Console.WriteLine("Invalid entry!");
      return;
    }
    List<string> decompressed = [];
    int appearances = 1;
    for (int i = 0; i < compressed.Length; i++)
    {
      if (i != 0 && i % 2 == 1)
      {
        continue;
      }

    }
  }
}