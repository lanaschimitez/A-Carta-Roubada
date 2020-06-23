using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsControl : MonoBehaviour
{
    public int idButton;
    public GameObject game;
    public GameObject control;
    public int order;
    public bool teste;

    RaycastHit hit; //Armazena informação que pegou o objeto
    void Start()
    {
        control = GameObject.Find("LightsID");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                game = hit.collider.gameObject; //mudar para varios objetos
                game.GetComponent<SpriteRenderer>().color = Color.black;
                control.GetComponent<LightsID>().ordemTeclasClicadas[order] = game.GetComponent<LightsControl>().idButton; // vai passar para o lightsID a tecla clicada
            }
        }
        order = control.GetComponent<LightsID>().auxOrdem;
    }
}
