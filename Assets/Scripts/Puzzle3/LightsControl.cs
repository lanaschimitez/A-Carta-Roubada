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
    public float tempo = 2.0f;
    public Color newColor;
    public Color corOriginal;
    public bool mudançaCor;

    RaycastHit hit; //Armazena informação que pegou o objeto
    void Start()
    {
        mudançaCor = true;
        control = GameObject.Find("LightsID");
        newColor = new Vector4(0.9716981f, 0.9569415f, 0.9166963f, 1.0f);

    }
    void Update()
    {
        if (control.GetComponent<LightsID>().liberado && order < 9)
        {
            if (mudançaCor)
            {
                gameObject.GetComponent<SpriteRenderer>().color = corOriginal;
                mudançaCor = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    game = hit.collider.gameObject; //mudar para varios objetos
                    control.GetComponent<LightsID>().ordemTeclasClicadas[order] = game.GetComponent<LightsControl>().idButton; // vai passar para o lightsID a tecla clicada
                    game.GetComponent<SpriteRenderer>().color = newColor;
                }
            }
            order = control.GetComponent<LightsID>().auxOrdem;
        }
    }
}
