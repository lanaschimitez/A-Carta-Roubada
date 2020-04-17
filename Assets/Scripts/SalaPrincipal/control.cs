using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void menuGame()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
