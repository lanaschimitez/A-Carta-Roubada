using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class desafio2 : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
    public GameObject vela;
    public GameObject luz;
    public GameObject fogo_vela;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posiPerson = personagem.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && posiPerson.x < -3 && posiPerson.z < -15)
            {
                if (hit.transform.name == "vela_mesa1")
                {
                    PlayerPrefs.SetInt("fire_on", 0);
                    SceneManager.LoadScene("Puzzle 2");
                }
            }
        }
        if (PlayerPrefs.GetInt("fire_on") == 1)
        {
            fogo_vela.SetActive(true);
            luz.SetActive(true);
            vela.GetComponent<desafio2>().enabled = false;
        }
    }
    //public void OnTriggerEnter(Collider other) { 
    //
    //    if (other.gameObject.tag == "player")
    //    {
    //        SceneManager.LoadScene("Puzzle 2");
    //    }
    //}
}
