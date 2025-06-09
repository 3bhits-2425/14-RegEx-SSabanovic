using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class RegexTest : MonoBehaviour
{
    void Start()
    {
        string input = "test.txt, bild.jpg, info@example.com, Tel: +43 660 1234567, PLZ: 1010 Wien";

        // Beispiel 1: Dateien erkennen
        string pattern1 = @"\b[\w\-]+\.(txt|jpg|png|pdf|docx)\b";
        MatchCollection fileMatches = Regex.Matches(input, pattern1);
        foreach (Match match in fileMatches)
        {
            Debug.Log("Datei gefunden: " + match.Value);
        }

        // Beispiel 2: Emails erkennen
        string pattern2 = @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b";
        MatchCollection emailMatches = Regex.Matches(input, pattern2);
        foreach (Match match in emailMatches)
        {
            Debug.Log("E-Mail gefunden: " + match.Value);
        }

        // Beispiel 3: Telefonnummer
        string pattern3 = @"(\+?\d{1,4}[\s\/]?\d{2,5}[\s\-]?\d{3,9})";
        MatchCollection phoneMatches = Regex.Matches(input, pattern3);
        foreach (Match match in phoneMatches)
        {
            Debug.Log("Telefonnummer gefunden: " + match.Value);
        }

        // Beispiel 4: PLZ
        string pattern4 = @"\b\d{5}\b";
        if (Regex.IsMatch(input, pattern4))
        {
            Debug.Log("PLZ erkannt!");
        }
    }
}
