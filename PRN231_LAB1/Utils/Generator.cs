namespace Utils;

public class Generator
{
    public static string IdGenerator()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 7)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}