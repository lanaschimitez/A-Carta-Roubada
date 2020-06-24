using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsControl : MonoBehaviour
{
    public int idButton;
    private GameObject game;
    private GameObject objetoControle;
    public int order;
    public Color corOriginal;
    public bool mudançaCor;
    private IEnumerator coresCoroutine;

    RaycastHit hit; //Armazena informação que pegou o objeto
    void Start()
    {
        mudançaCor = true;
        objetoControle = GameObject.Find("LightsID");
    }
    void Update()
    {
        if (objetoControle.GetComponent<LightsID>().liberado && order < 9)
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
                    objetoControle.GetComponent<LightsID>().ordemTeclasClicadas[order] = game.GetComponent<LightsControl>().idButton; // vai passar para o lightsID a tecla clicada
                    coresCoroutine = CorTecla(2.0f, game);
                    StartCoroutine(coresCoroutine);
                }
            }
            order = objetoControle.GetComponent<LightsID>().auxOrdem;
        }
    }

    IEnumerator CorTecla(float waitTime, GameObject game)
    {
        while (true)
        {
            waitTime -= Time.deltaTime;
            game.GetComponent<SpriteRenderer>().color = Color.red;
            if (waitTime < 0.1)
            {
                game.GetComponent<SpriteRenderer>().color = game.GetComponent<LightsControl>().corOriginal;
            }
            yield return null;
        }
    }
}
