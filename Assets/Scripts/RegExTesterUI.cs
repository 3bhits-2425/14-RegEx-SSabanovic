using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RegexTesterUI : MonoBehaviour
{
    public InputField inputField;
    public Dropdown regexDropdown;
    public Text outputText;

    public void TestRegex()
    {
        string input = inputField.text;
        string pattern = GetPatternFromDropdown();

        if (string.IsNullOrEmpty(pattern))
        {
            outputText.text = "❌ Kein Muster ausgewählt!";
            return;
        }

        MatchCollection matches;
        try
        {
            matches = Regex.Matches(input, pattern);
        }
        catch (System.Exception e)
        {
            outputText.text = "❌ Regex-Fehler: " + e.Message;
            return;
        }

        if (matches.Count == 0)
        {
            outputText.text = "⚠️ Keine Übereinstimmungen gefunden.";
        }
        else
        {
            outputText.text = $"✅ {matches.Count} Treffer:\n";
            foreach (Match match in matches)
            {
                outputText.text += $"- {match.Value}\n";
            }
        }
    }

    private string GetPatternFromDropdown()
    {
        switch (regexDropdown.value)
        {
            case 0: // E-Mail
                return @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b";
            case 1: // Dateiname
                return @"\b[\w\-]+\.(txt|jpg|png|pdf|docx)\b";
            case 2: // Telefonnummer
                return @"(\+?\d{1,4}[\s\/]?\d{2,5}[\s\-]?\d{3,9})";
            case 3: // PLZ
                return @"\b\d{5}\b";
            default:
                return "";
        }
    }
}
