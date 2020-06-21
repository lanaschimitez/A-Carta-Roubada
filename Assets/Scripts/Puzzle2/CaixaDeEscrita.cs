using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaixaDeEscrita : MonoBehaviour
{
    public string lana = "Lana";
    public char[] enigmaArray;
    public string resultado;
    public string enigma;

    //public GameObject fire;

    void Start()
    {
        enigmaArray = new char[] { 'a', 'b' }; //colocar para pegar em uma base de dados
        enigma = string.Join("", enigmaArray); //transformando a array em string antes de misturar

        for (int i=0; i>0 ; i++)
        {
            //misturar as letras
        }
        resultado = string.Join("", enigmaArray); //transformando a array em string depois de misturar
        var input = gameObject.GetComponent<InputField>(); //recebe o que o usuario digitar
        input.onEndEdit.AddListener(SubmitName);

    }

    public void Update()
    {
        //Teste para voltar a sala principal
        if(Input.touchCount > 1)
        {
            PlayerPrefs.SetInt("fire_on", 1);
            SceneManager.LoadScene("Sala Principal");            
        }
    }
    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        arg0 = arg0.ToLower(); //tranformando a string em letras minusculas
        Debug.Log(arg0);
        Debug.Log("    Is str1 equal to str2?: {0}" + string.Equals(arg0, enigma)); //verificar se o usuario acertou
    }
}
