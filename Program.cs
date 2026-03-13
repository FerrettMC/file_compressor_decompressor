// My first C# project
using System.Numerics;
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
    if (type.ToLower() == "r")
    {
      var randomString = new RandomString();
      string rs = randomString.getRandomString(300); // <--- Change this value for a bigger/smaller random string (a few hundred for best results)
      try
      {
        ClipboardService.SetText(rs);
      }
      catch
      {
        Console.WriteLine("Clipboard unavailable on this system.");
      }

      ClipboardService.SetText(rs); // If on [Arch] Linux, first run this: sudo pacman -S xclip xsel
      Console.WriteLine("Copied output to clipboard!");
    }
    else if (type.ToLower() == "compress" || type.ToLower() == "c")
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
    Console.WriteLine($"---\nYour compressed file is:\n{result}");
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

    Console.WriteLine($"---\nYour decompressed file is:\n{new string(result.ToArray())}");
  }
}

public class RandomString
{
  public string getRandomString(int byteCount)
  {
    char[] alphabet =
    [
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    ];

    byte[] bytes = new byte[byteCount];
    Random rng = new();
    rng.NextBytes(bytes);
    BigInteger bigInteger = new(bytes, isUnsigned: true, isBigEndian: false);
    List<string> result = [];
    string bigIntString = bigInteger.ToString();
    for (int i = 0; i < bigIntString.Length; i++)
    {
      int value = rng.Next(0, 26);
      string letter = alphabet[value].ToString();
      int count = int.Parse(bigIntString[i].ToString());
      result.AddRange(Enumerable.Repeat(letter, count));
    }
    return string.Join("", result);

  }
}