using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlMenu : MonoBehaviour
{
    public GameObject panel;
    public SpriteRenderer sprite_seta;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("zerado") == 0)
        {
            PlayerPrefs.SetFloat("time", 601f);
            PlayerPrefs.SetInt("quadro_on", 0);
            PlayerPrefs.SetInt("fire_on", 0);
            PlayerPrefs.SetInt("zerado", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
