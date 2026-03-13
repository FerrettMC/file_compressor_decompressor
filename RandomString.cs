using System.Numerics;
using TextCopy;

public class RandomString
{
  public void GetRandomString(int byteCount)
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
    string theResult = string.Join("", result);
    try
      {
        ClipboardService.SetText(theResult); // If on [Arch] Linux, first run this: sudo pacman -S xclip xsel
        Console.WriteLine("Large string copied output to clipboard!");
      }
      catch
      {
        Console.WriteLine("Clipboard unavailable on this system.");
      }

  }
}