using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1Touch : MonoBehaviour
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
        }
    }

    public void Update()
    {
       foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.SphereCast(ray, 0.3f, out hit))
                    {
                        gameObjectTodrag = hit.collider.gameObject; //mudar para varios objetos
                        GOcenter = hit.collider.gameObject.transform.position;
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
                        if (colisor)
                        {
                            gameObject.transform.position = new Vector3(-8.2f, -4f, 0f);
                        }
                        else
                        {
                            gameObject.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOcenter.z);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    draggingMode = false;
                    colisor = null;
                    break;
            }
        }
    }

    public void SairPuzzle()
    {
        SceneManager.LoadScene("Sala Principal");
    }
}