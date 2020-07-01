using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaixaDeEscrita : MonoBehaviour
{
    public string resultado;
    public string enigma;
    public GameObject _livro1;
    public GameObject _livro2;
    public GameObject _livro3;
    private GameObject livro;
    public string livro1 = "o gato preto";
    public string livro2 = "a mascara da morte escarlate";
    public string livro3 = "os assassinatos da rua morgue";
    public Vector3 posicao = new Vector3(-4.66f, 0.75f, 0f);
    public int aux;

    //public GameObject fire;

    void Start()
    {
        livro1 = "o gato preto";
        livro2 = "a mascara da morte escarlate";
        livro3 = "os assassinatos da rua morgue";
        aux = Random.Range(1, 4);
        if(aux == 1)
        {
            livro = _livro1;
            enigma = livro1;
        }
        else if(aux == 2)
        {
            livro = _livro2;
            enigma = livro2;
        }
        else if(aux == 3)
        {
            livro = _livro3;
            enigma = livro3;
        }
        Instantiate(livro, posicao, Quaternion.identity);
        var input = gameObject.GetComponent<InputField>(); //recebe o que o usuario digitar
        input.onEndEdit.AddListener(SubmitName);
    }
    public void SubmitName(string arg0)
    {
        arg0 = arg0.ToLower(); //tranformando a string em letras minusculas
        arg0 = arg0.Trim(); //apagando espaço em branco
        if (string.Equals(arg0, enigma))
        {
            Debug.Log("Correto");
            PlayerPrefs.SetInt("livro_on", 1);
            SceneManager.LoadScene("Sala Principal");
        }
    }
    
    public void Botao()
    {
        var input = gameObject.GetComponent<InputField>(); //recebe o que o usuario digitar
        input.onEndEdit.AddListener(SubmitName);
    }
}
