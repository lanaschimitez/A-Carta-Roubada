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

    RaycastHit hit; //Armazena informação que pegou o objeto
    void Start()
    {
        control = GameObject.Find("LightsID");
    }
    void Update()
    {
        order = control.GetComponent<LightsID>().order;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                game = hit.collider.gameObject; //mudar para varios objetos
                game.GetComponent<SpriteRenderer>().color = Color.black;
                control.GetComponent<LightsID>().idLightsU[order] = game.GetComponent<LightsControl>().idButton;
            }
        }
    }
}
