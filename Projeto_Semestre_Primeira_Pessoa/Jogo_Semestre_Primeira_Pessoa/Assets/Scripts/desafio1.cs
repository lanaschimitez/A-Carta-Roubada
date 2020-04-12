using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class desafio1 : MonoBehaviour
{
    public GameObject Painel;
    public GameObject Jogador;
    public GameObject Camera;

    void Start()
    {
        Painel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Painel.gameObject.SetActive(true);
            Jogador.transform.position = new Vector3(14.2f, 5.8f, 51.58476f);
            Time.timeScale = 0;
            Camera.GetComponent<rotacao>().enabled = false;
        }
    }

    public void OnClickVolta()
    {
        Painel.gameObject.SetActive(false);
        Time.timeScale = 1;
        Camera.GetComponent<rotacao>().enabled = true;
    }
}
