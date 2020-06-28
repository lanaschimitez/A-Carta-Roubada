using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlMenu : MonoBehaviour
{
    public GameObject panel;
    public SpriteRenderer sprite_seta;
    public Text opcoes;
    public Text creditos;
    void Start()
    {
        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            opcoes.text = "Options";
            creditos.text = "Credits";
        }

        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("zerado") == 0)
        {
            PlayerPrefs.SetFloat("time", 901f);
            PlayerPrefs.SetInt("piano_on", 0);
            PlayerPrefs.SetInt("quadro_on", 0);
            PlayerPrefs.SetInt("livro_on", 0);
            PlayerPrefs.SetInt("fire_on", 0);
            PlayerPrefs.SetInt("zerado", 1);
        }
    }
    public void startGame()
    {        
        panel.SetActive(true);        
    }
    public void colorSetaDown()
    {
        sprite_seta.color = Color.white;
    }
    public void colorSetaUp()
    {
        sprite_seta.color = new Color32(79, 9, 14, 255);
    }
    public void abreOpcoes()
    {
        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            PlayerPrefs.SetInt("confirmacao_jogo_ingles", 1);
        }
        PlayerPrefs.SetInt("jogo_portugues", 0);
        PlayerPrefs.SetInt("jogo_ingles", 0);
        SceneManager.LoadScene("Idioma");
    }
    public void abreCreditos()
    {
        SceneManager.LoadScene("Credits");
        PlayerPrefs.SetInt("credito_menu", 1);
    }
}
