# 🧠 RegEx Input Checker – Unity Projekt

Dieses Unity-Projekt dient zur praktischen Anwendung und Visualisierung von regulären Ausdrücken (RegEx) in C#. Nutzer:innen können verschiedene Eingaben machen (z. B. Name, E-Mail, Telefonnummer, Adresse), die automatisch erkannt und klassifiziert werden.

---

## 🎯 Funktionen

- 📝 5 frei beschreibbare Eingabefelder (InputFields)
- 🔍 Automatische RegEx-Erkennung für:
  - ✅ E-Mail-Adressen
  - ✅ Vor- und Nachnamen
  - ✅ Telefonnummern
  - ✅ Straßenadressen
- 💬 Ausgabe in der Unity-Konsole mit Beschreibung des erkannten Typs
- ♻️ Leicht erweiterbar für neue Eingabetypen (z. B. IBAN, URLs, Postleitzahl, etc.)

---

## 🛠️ Projektstruktur & Einrichtung

### 1. Benutzeroberfläche (UI)

- Erstelle ein Canvas in deiner Szene
- Füge 5x `InputField - TextMeshPro` hinzu
- Füge 1x `Button - TextMeshPro` hinzu
- Erstelle ein leeres GameObject und benenne es z. B. `InputManager`

### 2. Skript hinzufügen

Erstelle ein neues C#-Skript mit dem Namen `MultiInputLogger.cs` und füge folgenden Code ein:

```csharp
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class MultiInputLogger : MonoBehaviour
{
    public TMP_InputField field1;
    public TMP_InputField field2;
    public TMP_InputField field3;
    public TMP_InputField field4;
    public TMP_InputField field5;

    public void LogInputs()
    {
        Debug.Log(CheckInput(1, field1.text));
        Debug.Log(CheckInput(2, field2.text));
        Debug.Log(CheckInput(3, field3.text));
        Debug.Log(CheckInput(4, field4.text));
        Debug.Log(CheckInput(5, field5.text));
    }

    private string CheckInput(int fieldNumber, string input)
    {
        string type = "Unbekannt";

        if (Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            type = "E-Mail";
        else if (Regex.IsMatch(input, @"^[A-ZÄÖÜ][a-zäöüß]+(?: [A-ZÄÖÜ][a-zäöüß]+)*$"))
            type = "Name";
        else if (Regex.IsMatch(input, @"^\+?\d{1,3}[\s-]?\d{2,4}[\s-]?\d{3,10}$"))
            type = "Telefonnummer";
        else if (Regex.IsMatch(input, @"^[A-Za-zäöüßÄÖÜ\s]+\s\d+[a-zA-Z]?$"))
            type = "Adresse";

        return $"Feld {fieldNumber}: {type} erkannt – {input}";
    }
}
