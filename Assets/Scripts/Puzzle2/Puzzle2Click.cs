using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle2Click : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject gameObjectTodrag;
    public GameObject colisor;
    public Vector3 GOcenter; //Centro do objeto
    public Vector3 touchPosition; //Touch ou posição do Click
    public Vector3 offset;//vector entre touchpoint/mouseclick para o Centro do Objeto
    public Vector3 newGOCenter; //novo Centro do objeto
    RaycastHit hit; //Armazena informação que pegou o objeto
    public bool draggingMode = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barreira"))
        {
            colisor = other.gameObject;
        }

        if (other.CompareTag("Final"))
        {
            Debug.Log("Ganhou");
            PlayerPrefs.SetInt("quadro_on", 1);
            SceneManager.LoadScene("Sala Principal");
        }
    }

    public void Update()
    {
        //Quando usar click esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            //converte a posição do click para um ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Se o ray acertar (hit) o Collider (não 2DCollider)
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("player"))
                {
                    gameObjectTodrag = hit.collider.gameObject;
                    GOcenter = gameObjectTodrag.transform.position;
                    touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    offset = touchPosition - GOcenter;
                    draggingMode = true;
                }
            }
        }

        //Todo o frame quanto o click esquerdo estiver apertado
        if (Input.GetMouseButton(0))
        {
            if (draggingMode)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                if (colisor)
                {
                    gameObject.transform.position = new Vector3(-8.2f, -4f, 0f);
                }
                else
                {
                    gameObject.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOcenter.z);
                }
            }
        }
        //Quando solta o click do mouse
        if (Input.GetMouseButtonUp(0))
        {
            draggingMode = false;
            colisor = null;
        }
    }

    public void SairPuzzle()
    {
        SceneManager.LoadScene("Sala Principal");
    }
}