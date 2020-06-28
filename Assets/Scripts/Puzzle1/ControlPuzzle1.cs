using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPuzzle1 : MonoBehaviour
{

    public Text textTempo;
    public float gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = PlayerPrefs.GetFloat("time");
    }

    // Update is called once per frame
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
            GetComponent<AudioSource>().enabled = true;
            Invoke("fimdejogo", 6.0f);
        }
    }
    public void fimdejogo()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
