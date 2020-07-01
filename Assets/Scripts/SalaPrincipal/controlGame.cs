using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controlGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject Camera;
    public Image imagem;

    public Text textTempo;
    public float gameTimer;

    public GameObject joystickMovimentacao;
    public GameObject joystickCamera;
    public GameObject tela_cofre;
    public GameObject pause;
    public GameObject dicas;
    public Text continuar;

    void Start()
    {
        PlayerPrefs.SetInt("inicio_on", 1);
        panel.SetActive(false);
        gameTimer = PlayerPrefs.GetFloat("time");

        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            continuar.text = "Continue";
        }
    }
    void Update()
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
            if (PlayerPrefs.GetInt("jogo_ingles") == 1)
            {
                textTempo.text = "You got caught!";
            }
            else
            {
                textTempo.text = "Você foi pego!";
            }            
            PlayerPrefs.SetInt("zerado", 0);
            Camera.GetComponent<JoystickDynamicSala>().enabled = false;
            this.GetComponent<JoystickPlayer>().enabled = false;
            pause.GetComponent<Button>().enabled = false;
            dicas.GetComponent<Button>().enabled = false;
            GetComponent<AudioSource>().enabled = true;
            Invoke("fimdejogo", 6.0f);
        }
    }

    public void pauseGame()
    {
        if (tela_cofre.activeSelf==false) {
            Time.timeScale = 0;
            panel.SetActive(true);
            joystickMovimentacao.SetActive(false);
            joystickCamera.SetActive(false);
            Camera.GetComponent<JoystickDynamicSala>().enabled = false;
        }
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        joystickMovimentacao.SetActive(true);
        joystickCamera.SetActive(true);
        Camera.GetComponent<JoystickDynamicSala>().enabled = true;
    }
    public void menuGame()
    {
        SceneManager.LoadScene("Menu Principal");
    }
    public void colorSetaDown()
    {
        imagem.color = Color.white;
    }
    public void colorSetaUp()
    {
        imagem.color = new Color32(79, 9, 14, 255);
    }
    public void fimdejogo()
    {
        GetComponent<AudioSource>().enabled = false;
        SceneManager.LoadScene("Menu Principal");
    }
}
