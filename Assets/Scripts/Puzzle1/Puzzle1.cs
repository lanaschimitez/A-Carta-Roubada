using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{
    public float speed = 5.0f;

    public Text textTempo;
    public float gameTimer;
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
            textTempo.text = "Acabou o tempo!";
            PlayerPrefs.SetInt("zerado", 0);
            this.GetComponent<JoystickPlayerPuzzle>().enabled = false;
            Invoke("fimdejogo", 6.0f);
        }

        Movimento();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barreira")
            transform.position = new Vector3(-5.704f, -2.833f, 0f);
        if (other.tag == "Final")
        {
            Debug.Log("Ganhou");
            PlayerPrefs.SetInt("quadro_on", 1);
            SceneManager.LoadScene("Sala Principal");
        }
    }
    public void Movimento()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //o jogador ira mover cada vez que prescioonar 
        transform.Translate(horizontal, 0, 0);
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime; //o jogador ira mover cada vez que prescioonar 
        transform.Translate(0, vertical, 0);
    }
    public void sairPuzzle()
    {
        SceneManager.LoadScene("Sala Principal");
    }
    public void fimdejogo()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}