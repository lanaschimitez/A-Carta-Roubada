using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    public string lana = "Lana";
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        input.onEndEdit.AddListener(SubmitName);  // This also works

    }
    private void SubmitName(string arg0)
    {
        string lana = "Lana";
        Debug.Log(arg0);

        Debug.Log("    Is str1 equal to str2?: {0}" + string.Equals(arg0, lana));
    }
}
