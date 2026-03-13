// My first C# project

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Compress or decompress? (c, d)");
    string? type = Console.ReadLine();
    if (type is null)
    {
      return;
    }
    while (!new[] { "compress", "decompress", "c", "d" }
    .Contains(type, StringComparer.OrdinalIgnoreCase))
    {
      Console.WriteLine("Invalid input. Compress or decompress? (c, d)");
      type = Console.ReadLine();
    }
    if (type is null)
    {
      return;
    }
    if (type.ToLower() == "compress" || type.ToLower() == "c")
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
    int? appearances = 1;
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
        appearances = appearances == 1 ? null : appearances;
        compressed.Add($"{appearances}{letter}");
        appearances = 1;
      }
    }
    string result = string.Join("", compressed);
    Console.WriteLine($"Your compressed file is:\n{result}");
  }
}

public class Decompress
{
  public void DecompressText()
  {
    Console.WriteLine("Enter what you want decompressed!!");
    string? compressed = Console.ReadLine();
    if (compressed is null)
    {
      Console.WriteLine("Invalid entry!");
      return;
    }
    List<char> result = [];
    int i = 0;

    while (i < compressed.Length)
    {
      // Read number
      string number = "";
      while (i < compressed.Length && char.IsDigit(compressed[i]))
      {
        number += compressed[i];
        i++;
      }

      if (number == "" || i >= compressed.Length || !char.IsLetter(compressed[i]))
      {
        Console.WriteLine("Invalid compressed format!");
        return;
      }

      int count = int.Parse(number);
      char letter = compressed[i];

      result.AddRange(Enumerable.Repeat(letter, count));
      i++;
      while (i < compressed.Length && char.IsLetter(compressed[i]))
      {
        result.Add(compressed[i]);
        i++;
      }
    }

    Console.WriteLine($"Your decompressed file is:\n{new string(result.ToArray())}");
  }
}