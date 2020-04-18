using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class desafio1 : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        posiPerson = personagem.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && posiPerson.x > 29 && posiPerson.z > 40)
            {
                if (hit.transform.name == "quadro")
                {
                    SceneManager.LoadScene("Puzzle 1");
                }
            }
        }
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //   if (other.gameObject.tag == "player")
    //    {
    //        SceneManager.LoadScene("Puzzle 1");
    //    }
    //}
}
