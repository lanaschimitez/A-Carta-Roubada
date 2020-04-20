using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class desafio1 : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
    public Material materialFinal;
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
                    PlayerPrefs.SetInt("quadro_on", 0);
                    SceneManager.LoadScene("Puzzle 1");
                }
            }
        }
        if (PlayerPrefs.GetInt("quadro_on") == 1)
        {
            this.gameObject.GetComponent<Renderer>().material = materialFinal;
            this.gameObject.GetComponent<desafio1>().enabled = false;
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
