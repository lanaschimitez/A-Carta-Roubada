using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle3 : MonoBehaviour
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
        if (PlayerPrefs.GetInt("quadro_on") == 1)
        {
            posiPerson = personagem.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && posiPerson.x > 0 && posiPerson.z > 36 && posiPerson.x < 40)
                {
                    if (hit.transform.name == "livros_lareira")
                    {
                        PlayerPrefs.SetInt("livro_on", 0);
                        SceneManager.LoadScene("Puzzle 3");
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("livro_on") == 1)
        {
            this.gameObject.GetComponent<puzzle3>().enabled = false;
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
