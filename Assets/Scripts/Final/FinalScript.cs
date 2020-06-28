using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    public string[] frase, fraseIngles;
    public Text fala;
    public bool escolha;
    int fraseNumero;
    public GameObject opcoes;
    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        fraseNumero = 0;
        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            fala.text = fraseIngles[fraseNumero];
        }
        else
        {
            fala.text = frase[fraseNumero];
        }        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            passaTexto();
        }
    }

    void mudaFrase(int i)
    {
        if (i < frase.Length)
        {
            if (PlayerPrefs.GetInt("jogo_ingles") == 1)
            {
                fala.text = fraseIngles[i];
            }
            else
            {
                fala.text = frase[i];
            }          

            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            if(escolha == true)
            {
                if (PlayerPrefs.GetInt("jogo_ingles") == 1)
                {
                    fala.text = "1 - I want to use this power! \n2 - What is this letter about? Why is it so important for a letter? I will read it. \n3 - Dupin, you trusted me. You came to my help when I needed it. I will not break this I will return the letter and get the Reward. ";
                    next.SetActive(false);
                    opcoes.SetActive(true);                    
                    gameObject.GetComponent<AudioSource>().Play();
                }
                else
                {
                    fala.text = "1 - Quero usar este poder! \n2 - Do que se trata essa carta? Por que tanta importância por uma carta? Vou ler. \n3 - Dupin, confiou em mim. Veio ao meu auxílio quando precisei dele. Não vou quebrar essa confiança.Vou devolver a carta e pegar a Recompensa. ";
                    next.SetActive(false);
                    opcoes.SetActive(true);                    
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                SceneManager.LoadScene("Placar");
            }
        }
    }

    public void opcao1()
    {
        SceneManager.LoadScene("FinalUsarEstePoder");
    }
    public void opcao2()
    {
        SceneManager.LoadScene("FinalLerCarta");
    }
    public void opcao3()
    {
        SceneManager.LoadScene("FinalDevolverACarta");
    }
    public void passaTexto()
    {
        fraseNumero++;
        mudaFrase(fraseNumero);
    }
}
