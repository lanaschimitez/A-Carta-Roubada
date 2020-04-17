using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class desafio1 : MonoBehaviour
{
    public GameObject Jogador;
    public GameObject Camera;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            SceneManager.LoadScene("Puzzle 1");
        }
    }
}
