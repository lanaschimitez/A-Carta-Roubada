using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle1 : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
 
    // Start is called before the first frame update
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
            if (Physics.Raycast(ray, out hit) && posiPerson.x < -14 && posiPerson.z > 20)
            {
                if (hit.transform.name == "piano")
                {
                    PlayerPrefs.SetInt("piano_on", 0);
                    SceneManager.LoadScene("Puzzle 1");
                }
            }
        }
        if (PlayerPrefs.GetInt("piano_on") == 1)
        {
            this.gameObject.GetComponent<puzzle1>().enabled = false;
        }
    }
}
