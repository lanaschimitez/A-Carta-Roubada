using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlPause : MonoBehaviour
{
    public GameObject panel;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("inicio_on", 1);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
