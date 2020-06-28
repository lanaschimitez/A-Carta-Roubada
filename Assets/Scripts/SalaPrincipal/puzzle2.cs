using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle2 : MonoBehaviour
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
        if (PlayerPrefs.GetInt("piano_on") == 1)
        {
            posiPerson = personagem.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && posiPerson.x > 14 && posiPerson.z > 35)
                {
                    if (hit.transform.name == "quadro")
                    {
                        PlayerPrefs.SetInt("quadro_on", 0);
                        SceneManager.LoadScene("Puzzle 2");
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("quadro_on") == 1)
        {
            this.gameObject.GetComponent<Renderer>().material = materialFinal;
            this.gameObject.GetComponent<puzzle2>().enabled = false;
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
