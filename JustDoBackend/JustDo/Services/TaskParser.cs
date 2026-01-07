using System.Text.RegularExpressions;

namespace JustDo.Services;

public class TaskParser
{
    public ParsedTask Parse(string input)
    {
        var result = new ParsedTask
        {
            RawInput = input,
            Title = input
        };

        var lower = input.ToLower();

        if (lower.Contains("morgen"))
            result.DueDate = DateTime.Today.AddDays(1);

        if (lower.Contains("heute"))
            result.DueDate = DateTime.Today;

        var timeMatch = Regex.Match(lower, @"(\d{1,2})\s*uhr");
        if (timeMatch.Success)
        {
            var hour = int.Parse(timeMatch.Groups[1].Value);
            result.DueDate ??= DateTime.Today;
            result.DueDate = result.DueDate.Value.AddHours(hour);
        }

        result.Title = Regex
            .Replace(input, @"morgen|heute|\d{1,2}\s*uhr", "", RegexOptions.IgnoreCase)
            .Trim();

        return result;
    }
}

public class ParsedTask
{
    public string RawInput { get; set; } = "";
    public string Title { get; set; } = "";
    public DateTime? DueDate { get; set; }
}
}
