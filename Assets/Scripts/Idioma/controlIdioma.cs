using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlIdioma : MonoBehaviour
{
    public Text ingles;
    public Text portugues;
    public Text tituloNome;
    public Text tituloIdioma;
    public Text textInput;

    public InputField nomeJogador;
    public Button botaoIngles;
    public Button botaoPortugues;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("jogo_portugues") == 1 || PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            SceneManager.LoadScene("Menu Principal");
            //PlayerPrefs.SetInt("jogo_portugues", 0);
            //PlayerPrefs.SetInt("jogo_ingles", 0);
        }
    }

    public void Start()
    {
        if (PlayerPrefs.GetInt("confirmacao_jogo_ingles") == 1)
        {
            tituloNome.text = "WHAT'S YOUR NAME ?";
            tituloIdioma.text = "CHOOSE A LANGUAGE";
            textInput.text = "Write your name ...";
        }
        PlayerPrefs.SetInt("confirmacao_jogo_ingles", 0);
        
        nomeJogador.text = PlayerPrefs.GetString("nomeJogador");
    }

    //configurando inicio para a escolha do jogador
    public void inicioMenuPortugues()
    {
        if (nomeJogador.text == "")
        {
            tituloNome.color = Color.red;
        }
        else
        {
            PlayerPrefs.SetString("nomeJogador", nomeJogador.text);

            PlayerPrefs.SetInt("jogo_portugues", 1);
            PlayerPrefs.SetInt("jogo_ingles", 0);
            SceneManager.LoadScene("Menu Principal");
        }
    }
    public void inicioMenuIngles()
    {
        if (nomeJogador.text == "")
        {
            tituloNome.color = Color.red;
        }
        else
        {
            PlayerPrefs.SetString("nomeJogador", nomeJogador.text);

            PlayerPrefs.SetInt("jogo_ingles", 1);
            PlayerPrefs.SetInt("jogo_portugues", 0);
            SceneManager.LoadScene("Menu Principal");
        }
    }

    //controle efeito aumentar letra
    public void aumentaLetraIngl()
    {
        ingles.fontSize = 50;
    }
    public void diminuiLetraIngl()
    {
        ingles.fontSize = 34;
    }

    public void aumentaLetraPort()
    {
        portugues.fontSize = 50;
    }
    public void diminuiLetraPort()
    {
        portugues.fontSize = 34;
    }
}
