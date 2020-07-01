using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controlDicas : MonoBehaviour
{
    public GameObject panel;
    public Text dica1;
    public Text dica11;
    public Text dica2;
    public Text dica22;
    public Text dica3;
    public Text dica33;
    public Text dica4;
    public Text dica44;
    public GameObject dicaObject1;
    public GameObject dicaObject2;
    public GameObject dicaObject3;
    public GameObject dicaObject4;
    public GameObject carta;
    public GameObject joystickMovimentacao;
    public GameObject joystickCamera;
    public GameObject Camera;
    public Sprite dicaIngles;
    public Text txtVoltarJogo;
    
    void Start()
    {
       if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            dica1.text = "INY YOUR ABSENCE, SILENCE BECOMES KING, IN YOUR PRESENCE, SILENCIE BECOMES PART OF YOUR PROCESS.";
            dica11.text = "INY YOUR ABSENCE, SILENCE BECOMES KING, IN YOUR PRESENCE, SILENCIE BECOMES PART OF YOUR PROCESS.";
            dica2.text = "WHEN YOU'RE LOST, STOP AND LOOK. SOME WINDOWS, YOU CAN SHOW THE PATH.";
            dica22.text = "WHEN YOU'RE LOST, STOP AND LOOK. SOME WINDOWS, YOU CAN SHOW THE PATH.";
            dica3.text = "HERE YOU WILL FIND THE ANSWER WARMING UP IN THE COMPANY OF MAQUIAVEL AND CAMPANELLA.";
            dica33.text = "HERE YOU WILL FIND THE ANSWER WARMING UP IN THE COMPANY OF MAQUIAVEL AND CAMPANELLA.";
            dica4.text = "IN YOUR PRESENCE, YOU WILL BE ABLE TO SEE WHAT YOU ARE LOOKING FOR.";
            dica44.text = "IN YOUR PRESENCE, YOU WILL BE ABLE TO SEE WHAT YOU ARE LOOKING FOR.";

            txtVoltarJogo.text = "Return";

            this.GetComponent<Image>().sprite = dicaIngles;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("piano_on") == 1)
        {
            dica1.color = new Color32(255, 255, 255, 100);
        }
        if (PlayerPrefs.GetInt("quadro_on") == 1)
        {
            dica2.color = new Color32(255, 255, 255, 100);
        }
        if (PlayerPrefs.GetInt("livro_on") == 1)
        {
            dica3.color = new Color32(255, 255, 255, 100);
        }
        if (PlayerPrefs.GetInt("fire_on") == 1)
        {
            dica4.color = new Color32(255, 255, 255, 100);
            dicaObject1.SetActive(false);
            dicaObject2.SetActive(false);
            dicaObject3.SetActive(false);
            dicaObject4.SetActive(false);
            carta.SetActive(true);
        }    
    }
    public void abreDicas()
    {
        panel.SetActive(true);
        joystickMovimentacao.SetActive(false);
        joystickCamera.SetActive(false);
        Camera.GetComponent<JoystickDynamicSala>().enabled = false;
    }
    public void fechaDicas()
    {
        panel.SetActive(false);
        joystickMovimentacao.SetActive(true);
        joystickCamera.SetActive(true);
        Camera.GetComponent<JoystickDynamicSala>().enabled = true;
    }
}
