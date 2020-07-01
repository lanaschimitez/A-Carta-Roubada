using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    public float speed = 5.0f;

    public Text textTempo;
    public float gameTimer;

    public GameObject colisor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barreira"))
        {
            colisor = other.gameObject;
        }

        if (other.CompareTag("Final"))
        {
            Debug.Log("Ganhou");
            PlayerPrefs.SetInt("quadro_on", 1);
            SceneManager.LoadScene("Sala Principal");
        }
    }
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

        Vector3 posi = gameObject.transform.position;
        if (colisor)
        {
            gameObject.transform.position = new Vector3(-8.2f, -4f, 0f);
            colisor = null;
        }
        else
        {
            gameObject.transform.position = new Vector3(posi.x, posi.y, 0);
        }
    }
    public void sairPuzzle()
    {
        SceneManager.LoadScene("Sala Principal");
    }
    public void fimdejogo()
    {
        GetComponent<AudioSource>().enabled = false;
        SceneManager.LoadScene("Menu Principal");
    }
}