using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class MovimentacaoPeca : MonoBehaviour
{
    public GameObject[] gameObjectTodrag = new GameObject[6]; //Objeto que sera movido
    public GameObject[] gameObjectList = new GameObject[6]; //Objeto que sera movido
    public GameObject _CartaFinal;
    private bool final = false;
    public bool[] lugarCorreto = new bool[6];
    private bool vitoria = false;
    private int ordem; //ordem do objeto
    

    private Vector3 GOcenter; //Centro do objeto
    private Vector3 touchPosition; //Touch ou posição do Click
    private Vector3 offset;//vector entre touchpoint/mouseclick para o Centro do Objeto
    private Vector3 newGOCenter; //novo Centro do objeto
    private RaycastHit hit; //Armazena informação que pegou o objeto
    private bool draggingMode = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ordem = hit.collider.gameObject.GetComponent<OrdemPedaco>().orderPedaco;
                ordem -= ordem;
                gameObjectTodrag[ordem] = hit.collider.gameObject; //mudar para varios objetos
                GOcenter = gameObjectTodrag[ordem].transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - GOcenter;
                draggingMode = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (draggingMode)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                gameObjectTodrag[ordem].transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOcenter.z);
            }
        }
        //Quando solta o click do mouse
        if (Input.GetMouseButtonUp(0))
        {
            draggingMode = false;
            ordem = 0;
        }

        for(int i = 0; i < 6; i++)
        {
            if (lugarCorreto[i] != true)
            {
                vitoria = false;
                break;
            }
            else
            {
                vitoria = true;
            }
        }
        if (vitoria){ 
            Debug.Log("Ganhou"); //inciar animacao da carta
            if (!final)
            {
                for (int i = 0; i < 6; i++)
                {
                    gameObjectList[i].SetActive(false);
                }
                    Instantiate(_CartaFinal, transform.position, Quaternion.identity);
                final = true;
            }
            PlayerPrefs.SetInt("fire_on", 1);
            PlayerPrefs.SetInt("animation1_on", 1);
            Invoke("fimDeJogo", 3);
        }
    }

    public void fimDeJogo()
    {
        SceneManager.LoadScene("Sala Principal");
    }
}