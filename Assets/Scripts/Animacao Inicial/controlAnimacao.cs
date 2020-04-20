using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class controlAnimacao : MonoBehaviour
{
    public float tempoParaCarregar = 59;

    float cronometro = 0;

    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro > tempoParaCarregar)
        {
            SceneManager.LoadScene("Sala Principal");
        }
    }

}
    
