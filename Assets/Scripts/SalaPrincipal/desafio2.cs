using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class desafio2 : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "desafio2")
                {
                    SceneManager.LoadScene("Puzzle 2");
                }
            }
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
