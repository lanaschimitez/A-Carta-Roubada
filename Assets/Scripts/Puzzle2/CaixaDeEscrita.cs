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

    public GameObject fire;

    public Text textTempo;
    public float gameTimer;

    void Start()
    {
        gameTimer = PlayerPrefs.GetFloat("time");

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
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0)
        {
            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            PlayerPrefs.SetFloat("time", gameTimer);

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            textTempo.text = timerString;
        }
        else
        {
            textTempo.color = Color.red;
            textTempo.text = "Acabou o tempo!";
            PlayerPrefs.SetInt("zerado", 0);
            Invoke("fimdejogo", 6.0f);
        }

        //Teste para voltar a sala principal
        if (Input.touchCount > 1)
        {
            PlayerPrefs.SetInt("fire_on", 1);
            PlayerPrefs.SetInt("animation1_on", 1);
            SceneManager.LoadScene("Sala Principal");            
        }
    }
    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        Debug.Log("    Is str1 equal to str2?: {0}" + string.Equals(arg0, enigma)); //verificar se o usuario acertou
    }
    public void fimdejogo()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
