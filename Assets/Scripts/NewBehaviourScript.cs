using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class RegExHelper
{
    private string input;

    public RegExHelper(string input)
    {
        this.input = input;
    }

    // 1) Zählt, wie oft das Muster im Text vorkommt
    // Beispiel: "Hallo Welt, hallo Sonne" -> pattern: "hallo" => gibt 2 zurück (case-insensitive optional)
    public int CountMatches(string pattern)
    {
        return Regex.Matches(input, pattern).Count;
    }

    // 2) Extrahiert alle Dateinamen mit bestimmten Endungen
    // RegEx: \b[\w\-]+\.(txt|jpg|png|pdf|docx)\b
    // \b = Wortgrenze
    // [\w\-]+ = Wortzeichen oder Bindestrich, mindestens einmal
    // \. = Punkt (Escape nötig)
    // (txt|jpg|...) = eine der Dateiendungen
    public List<string> ExtractFilenames()
    {
        var matches = Regex.Matches(input, @"\b[\w\-]+\.(txt|jpg|png|pdf|docx)\b");
        var list = new List<string>();
        foreach (Match match in matches)
            list.Add(match.Value);
        return list;
    }

    // 3) E-Mail-Adressen extrahieren
    // RegEx: \b[\w\.-]+@[\w\.-]+\.\w{2,}\b
    // [\w\.-]+ = Name-Teil vor dem @ (Buchstaben, Punkt oder Bindestrich)
    // @ = das @-Zeichen
    // [\w\.-]+ = Domainname (z. B. gmail, web, etc.)
    // \.\w{2,} = Punkt + mindestens 2 Buchstaben (z. B. ".com", ".de")
    public List<string> ExtractEmails()
    {
        var matches = Regex.Matches(input, @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b");
        var list = new List<string>();
        foreach (Match match in matches)
            list.Add(match.Value);
        return list;
    }

    // 4) Prüft, ob irgendwo im Text eine deutsche PLZ vorkommt
    // RegEx: \b\d{5}\b
    // \d{5} = genau 5 Ziffern (z. B. "10115")
    // \b = Wortgrenze davor und danach
    public bool ContainsGermanPostalCode()
    {
        return Regex.IsMatch(input, @"\b\d{5}\b");
    }

    // 5) Telefonnummern extrahieren (international oder national)
    // RegEx: (\+?\d{1,4}[\s\/]?\d{2,5}[\s\-]?\d{3,9})
    // \+? = optionales Pluszeichen
    // \d{1,4} = Landesvorwahl oder Vorwahl (z. B. +43 oder 0123)
    // [\s\/]? = optional Leerzeichen oder Schrägstrich
    // \d{2,5} = Ortsvorwahl (z. B. 12345)
    // [\s\-]? = optional Leerzeichen oder Bindestrich
    // \d{3,9} = eigentliche Rufnummer
    public List<string> ExtractPhoneNumbers()
    {
        var matches = Regex.Matches(input, @"(\+?\d{1,4}[\s\/]?\d{2,5}[\s\-]?\d{3,9})");
        var list = new List<string>();
        foreach (Match match in matches)
            list.Add(match.Value);
        return list;
    }
}
