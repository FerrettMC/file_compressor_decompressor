using TextCopy;
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

      if (i >= compressed.Length || !char.IsLetter(compressed[i]))
      {
          Console.WriteLine("Invalid compressed format!");
          return;
      }

      int count = number == "" ? 1 : int.Parse(number);


      char letter = compressed[i];

      result.AddRange(Enumerable.Repeat(letter, count));
      i++;
      while (i < compressed.Length && char.IsLetter(compressed[i]))
      {
        result.Add(compressed[i]);
        i++;
      }
    }
    string theResult = string.Join("", result);
    double percent = (double)(theResult.Length - compressed.Length) / compressed.Length * 100;
    int roundedPercent = (int)Math.Round(percent);
    Console.WriteLine($"---\nYour decompressed file is:\n{theResult}");
    
    Console.WriteLine($"Original file size: {compressed.Length} characters. New file size: {theResult.Length} characters. {roundedPercent}% increase.");
    try
      {
        ClipboardService.SetText(theResult); // If on [Arch] Linux, first run this: sudo pacman -S xclip xsel
        Console.WriteLine("Copied output to clipboard!");
      }
      catch
      {
        Console.WriteLine("Clipboard unavailable on this system.");
      }
  }
}