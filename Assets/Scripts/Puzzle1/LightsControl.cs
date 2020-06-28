using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightsControl : MonoBehaviour
{
    public int idButton;
    private GameObject game;
    private GameObject objetoControle;
    public int order;
    public Color corOriginal;
    public bool mudançaCor;
    public AudioSource audioData;
    public bool mudarCor;


    RaycastHit hit; //Armazena informação que pegou o objeto
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        mudançaCor = true;
        objetoControle = GameObject.Find("LightsID");
        mudarCor = false;
    }
    void Update()
    {      

        mudarCor = false;
        if (objetoControle.GetComponent<LightsID>().liberado && order < 7)
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
                    game.GetComponent<SpriteRenderer>().color = Color.red;
                    game.GetComponent<LightsControl>().mudarCor = true;
                    game.GetComponent<LightsControl>().Sound();
                }
            }
            order = objetoControle.GetComponent<LightsID>().auxOrdem;
        }
    }

    public void MudançaCor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = corOriginal;
        mudançaCor = false;
    }
    public void Sound()
    {
        audioData.Play();
    }
    public void voltarSala()
    {
        SceneManager.LoadScene("Sala Principal");
    }

}
