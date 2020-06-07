using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controlDicas : MonoBehaviour
{
    public GameObject panel;
    public Text dica1;
    public Text dica2;
    public GameObject joystick;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("quadro_on") == 1)
        {
            dica1.color = new Color32(255, 255, 255, 100);
        }
        if (PlayerPrefs.GetInt("fire_on") == 1)
        {
            dica2.color = new Color32(255,255,255,100);
        }
    }
    public void abreDicas()
    {
        panel.SetActive(true);
        joystick.SetActive(false);
        Camera.GetComponent<rotacao>().enabled = false;
    }
    public void fechaDicas()
    {
        panel.SetActive(false);
        joystick.SetActive(true);
        Camera.GetComponent<rotacao>().enabled = true;
    }
}
