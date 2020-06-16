using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public float speed = 5.0f;
    public float reductionRadius = 1.0f;
    float velocidadeRotacao = 20;
    public Vector2 posicaoToque;
    public GameObject gameObjectTodrag; //Objeto que sera movido


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
                gameObjectTodrag = hit.collider.gameObject; //mudar para varios objetos
                GOcenter = gameObjectTodrag.transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - GOcenter;
                draggingMode = true;
                posicaoToque = Input.GetTouch(0).deltaPosition;

            }
        }
        if (Input.GetMouseButton(0))
        {
            if (draggingMode)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                gameObjectTodrag.transform.rotation = Quaternion.Euler(0, 0, GOcenter.z);
            }
        }
        //Quando solta o click do mouse
        if (Input.GetMouseButtonUp(0))
        {
            draggingMode = false;
        }
        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            posicaoToque = Input.GetTouch(0).deltaPosition;
            float z = posicaoToque.x * Mathf.Deg2Rad * velocidadeRotacao;
            float y = posicaoToque.y * Mathf.Deg2Rad * velocidadeRotacao;
            //transform.RotateAround(Vector3.zero, Vector3.forward, z);
            transform.rotation = Quaternion.Euler(0, 0, posicaoToque.magnitude);
        }*/
    }
}
