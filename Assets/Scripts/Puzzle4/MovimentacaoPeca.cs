using UnityEngine;
using System.Collections;
using System;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class MovimentacaoPeca : MonoBehaviour
{

    //Este codigo e para click/drag gameobject 2D
    //Cameraprojeção deve estar como Orthographic
    //Adicionar um Collider (não 2DCollider) no gameObject  
    public GameObject[] gameObjectTodrag = new GameObject[2]; //Objeto que sera movido
    public int ordem; //ordem do objeto


    public Vector3 GOcenter; //Centro do objeto
    public Vector3 touchPosition; //Touch ou posição do Click
    public Vector3 offset;//vector entre touchpoint/mouseclick para o Centro do Objeto
    public Vector3 newGOCenter; //novo Centro do objeto

    RaycastHit hit; //Armazena informação que pegou o objeto

    public bool draggingMode = false;

    void Update()
    {
        // necessario pegar qual a order do gameobjet para comparar com o lugar final (no scrip LugarPeca) e dizer se esta na posicao correta


        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                //Quando há um toque
                case TouchPhase.Began:
                    //converte a posição do toque para um Ray
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    //Se o ray acertar (hit) o Collider (não 2DCollider)
                    // if (Physics.Raycast(ray, out hit))
                    if (Physics.SphereCast(ray, 0.3f, out hit))
                    {
                        gameObjectTodrag[1] = hit.collider.gameObject; //mudar para varios objetos
                        GOcenter = gameObjectTodrag[1].transform.position;
                        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        offset = touchPosition - GOcenter;
                        draggingMode = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (draggingMode)
                    {
                        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newGOCenter = touchPosition - offset;
                        gameObjectTodrag[1].transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOcenter.z);
                    }
                    break;

                case TouchPhase.Ended:
                    draggingMode = false;
                    break;
            }
        }
    }
}