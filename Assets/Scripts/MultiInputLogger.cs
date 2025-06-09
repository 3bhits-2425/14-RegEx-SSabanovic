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
