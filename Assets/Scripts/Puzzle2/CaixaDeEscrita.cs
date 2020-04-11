using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaDeEscrita : MonoBehaviour
{
    public string lana = "Lana";
    public char[] enigma; 
    public char[] teste;
    void Start()
    {
        enigma = new char[] { 'a', 'b' }; //colocar para pegar em uma base de dados
        for(int i=0; i>0 ; i++)
        {

        }
        var input = gameObject.GetComponent<InputField>();
        input.onEndEdit.AddListener(SubmitName);

    }
    private void SubmitName(string arg0)
    {
        string lana = "Lana"; 
        Debug.Log(arg0);

        Debug.Log("    Is str1 equal to str2?: {0}" + string.Equals(arg0, lana));
    }
}
