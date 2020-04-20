using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        if (PlayerPrefs.GetInt("inicio_on") == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Animacao Inicial");
        }

        if (PlayerPrefs.GetInt("inicio_on") == 1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Sala Principal");
        }
    }
}
