using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle4 : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
    public GameObject vela;
    public GameObject prateleira;
    public GameObject luz;
    public GameObject fogo_vela;
    public GameObject cameraPrateleira;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("livro_on") == 1)
        {
            posiPerson = personagem.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && posiPerson.x > 30 && posiPerson.z < 15 && posiPerson.z > -6)
                {
                    if (hit.transform.name == "vela_mesa1")
                    {
                        PlayerPrefs.SetInt("fire_on", 0);
                        SceneManager.LoadScene("Puzzle 4");
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("fire_on") == 1)
        {
            fogo_vela.SetActive(true);
            luz.SetActive(true);
            prateleira.GetComponent<Animator>().enabled = true;
            if (PlayerPrefs.GetInt("animation1_on") == 1)
            {
                cameraPrateleira.GetComponent<Animator>().enabled = true;
            }
            PlayerPrefs.SetInt("animation1_on", 0);
            Invoke("espera", 2.0f);
            vela.GetComponent<puzzle4>().enabled = false;
        }
        
    }
    void espera()
    {
        cameraPrateleira.GetComponent<Animator>().enabled = false;
    }
    //public void OnTriggerEnter(Collider other) { 
    //
    //    if (other.gameObject.tag == "player")
    //    {
    //        SceneManager.LoadScene("Puzzle 2");
    //    }
    //}
}
