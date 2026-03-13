using TextCopy;
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
    double percent = (double)result.Length / decompressed.Length * 100;
    int roundedPercent = (int)Math.Round(percent);
    int percentDecrease = 100 - roundedPercent;


    Console.WriteLine($"---\nYour compressed file is:\n{result}");
    Console.WriteLine($"Original file size: {decompressed.Length} characters. New file size: {result.Length} characters. {percentDecrease}% decrease.");
    try
      {
        ClipboardService.SetText(result); // If on [Arch] Linux, first run this: sudo pacman -S xclip xsel
        Console.WriteLine("Copied output to clipboard!");
      }
      catch
      {
        Console.WriteLine("Clipboard unavailable on this system.");
      }
  }
}