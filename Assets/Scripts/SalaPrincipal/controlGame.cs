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

    void Start()
    {
        PlayerPrefs.SetInt("inicio_on", 1);
        panel.SetActive(false);
        gameTimer = PlayerPrefs.GetFloat("time");
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
            textTempo.text = "Acabou o tempo!";
            PlayerPrefs.SetInt("zerado", 0);
            Camera.GetComponent<rotacao>().enabled = false;
            this.GetComponent<JoystickPlayer>().enabled = false;
            Invoke("fimdejogo", 6.0f);
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        Camera.GetComponent<rotacao>().enabled = false;
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        Camera.GetComponent<rotacao>().enabled = true;
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
        SceneManager.LoadScene("Menu Principal");
    }
}
